using System;
using System.Collections.Generic;
using System.Text;

namespace Job.YaModel
{
    public class YAWeatherRoot
    {
        public int Now { get; set; }
        public DateTime Now_dt { get; set; }
        public Info Info { get; set; }
        public Fact Fact { get; set; }
        public Forecast Forecast { get; set; }
    }
}
