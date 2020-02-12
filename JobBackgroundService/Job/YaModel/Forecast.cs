using System;
using System.Collections.Generic;
using System.Text;

namespace Job.YaModel
{
    public class Forecast
    {
        public string Date { get; set; }
        public int Date_ts { get; set; }
        public int Week { get; set; }
        public string Sunrise { get; set; }
        public string Sunset { get; set; }
        public int Moon_code { get; set; }
        public string Moon_text { get; set; }
        public List<Part> Parts { get; set; }
    }
}
