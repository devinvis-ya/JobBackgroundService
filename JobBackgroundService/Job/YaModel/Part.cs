using System;
using System.Collections.Generic;
using System.Text;

namespace Job.YaModel
{
    public class Part
    {
        public string Part_name { get; set; }
        public int Temp_min { get; set; }
        public int Temp_max { get; set; }
        public int Temp_avg { get; set; }
        public int Feels_like { get; set; }
        public string Icon { get; set; }
        public string Condition { get; set; }
        public string Daytime { get; set; }
        public bool Polar { get; set; }
        public double Wind_speed { get; set; }
        public double Wind_gust { get; set; }
        public string Wind_dir { get; set; }
        public int Pressure_mm { get; set; }
        public int Pressure_pa { get; set; }
        public int Humidity { get; set; }
        public double Prec_mm { get; set; }
        public int Prec_period { get; set; }
        public int Prec_prob { get; set; }
    }
}
