using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

using Job.Context;
using Job.Helper;
using Job.Settings;
using Job.YaHttpClient;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;

namespace Job.Service
{
    public class JobService : BackgroundService
    {
        public readonly AppSettings _settings;
        public readonly DBLocalContext _DB;
        public readonly YandexHttpClient _clientFactory;

        public JobService(IConfiguration opt, DBLocalContext dB, YandexHttpClient clientFactory)
        {
            _settings = ConfigurationHelper.GetAppSettings(opt);
            _DB = dB;
            _clientFactory = clientFactory;
        }
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while ( !stoppingToken.IsCancellationRequested )
            {
                Console.WriteLine("Hello World!");

                Console.WriteLine($"CanConnect = {_DB.Database.CanConnect()}");
                var place = _DB.Places.FirstOrDefault();

                var result = await _clientFactory.GetWeatherByPlace(place);

                if ( result is null )
                {
                    Console.WriteLine("Something is wrong");
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
    }
}
