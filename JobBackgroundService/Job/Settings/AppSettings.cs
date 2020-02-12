using System;
using System.Collections.Generic;
using System.Text;

namespace Job.Settings
{
    public class AppSettings
    {
        public DB db { get; set; }
        public YAWeather YandexWeather { get; set; }
        public int UpdateTimeSec { get; set; }
    }
}
