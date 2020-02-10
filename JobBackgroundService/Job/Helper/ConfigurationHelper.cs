using System;
using System.Collections.Generic;
using System.Text;
using Job.Settings;
using Microsoft.Extensions.Configuration;

namespace Job.Helper
{
    public static class ConfigurationHelper
    {
        public static AppSettings GetAppSettings(IConfiguration conf)
        {
            return conf.GetSection("AppSettings")?.Get<AppSettings>();
        }
    }
}
