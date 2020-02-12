using System;
using System.Linq;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

using Job.Context;
using Job.Helper;
using Job.Settings;
using Job.YaHttpClient;
using Job.YaModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;

namespace Job.Service
{
    public class JobService : BackgroundService
    {
        public readonly AppSettings _settings;
        public readonly DBLocalContext _DB;
        public readonly YandexHttpClient _client;

        public JobService(IConfiguration opt, DBLocalContext dB, YandexHttpClient client)
        {
            _settings = ConfigurationHelper.GetAppSettings(opt);
            _DB = dB;
            _client = client;
        }
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while ( !stoppingToken.IsCancellationRequested )
            {
                if ( !_DB.Database.CanConnect() )
                {
                    Console.WriteLine("Do not have connect to the Database");
                }
                else
                {
                    var places = await _DB.Places.ToListAsync();

                    foreach ( var place in places )
                    {
                        var result = await _client.GetWeatherByPlace(place);

                        if ( result is null )
                        {
                            Console.WriteLine("Something is wrong");
                        }
                        YAWeatherRoot root = GetYAWeatherRoot(result);

                        DBModel.Fact newFact = new DBModel.Fact(root.Fact);
                        newFact.PlaceId = place.Id;

                        await _DB.Facts.AddAsync(newFact, stoppingToken);

                        if ( place.Url is null )
                        {
                            place.Url = root?.Info?.Url;

                            _DB.Places.Update(place);
                        }

                        await _DB.SaveChangesAsync(stoppingToken);
                    }
                }

                await Task.Delay(GetDelaySeconds(_settings.UpdateTimeSec), stoppingToken);
            }
        }

        private TimeSpan GetDelaySeconds(int confValue)
        {
            if ( confValue.Equals(0) )
            {
                return TimeSpan.FromSeconds(5);
            }
            return TimeSpan.FromSeconds(confValue);
        }

        private YAWeatherRoot GetYAWeatherRoot(string responseJson)
        {
            var serializeOpt = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
            };
            return JsonSerializer.Deserialize<YAWeatherRoot>(responseJson, serializeOpt);
        }
    }
}
