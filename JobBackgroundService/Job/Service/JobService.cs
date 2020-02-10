using System;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;

using Job.Context;
using Job.Helper;
using Job.Settings;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;

namespace Job.Service
{
    public class JobService : BackgroundService
    {
        public AppSettings _settings { get; }
        public DBLocalContext DB { get; }

        public JobService(IConfiguration opt, DBLocalContext dB)
        {
            _settings = ConfigurationHelper.GetAppSettings(opt);
            DB = dB;
        }
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while ( !stoppingToken.IsCancellationRequested )
            {
                Console.WriteLine("Hello World!");

                Console.WriteLine($"CanConnect = {DB.Database.CanConnect()}");

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
