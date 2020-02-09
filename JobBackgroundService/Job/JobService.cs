using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Job.Settings;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;

namespace Job
{
    public class JobService : BackgroundService
    {
        public AppSettings _settings { get; }
        public JobService(IConfiguration opt)
        {
            _settings = opt.GetSection("AppSettings").Get<AppSettings>();
        }
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while ( !stoppingToken.IsCancellationRequested )
            {
                Console.WriteLine("Hello World!");


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
