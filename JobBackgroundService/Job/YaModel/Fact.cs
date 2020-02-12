namespace Job.YaModel
{
    public class Fact
    {
        public int Temp { get; set; }
        public int Feels_like { get; set; }
        public string Icon { get; set; }
        public string Condition { get; set; }
        public double Wind_speed { get; set; }
        public double Wind_gust { get; set; }
        public string Wind_dir { get; set; }
        public double Pressure_mm { get; set; }
        public double Pressure_pa { get; set; }
        public double Humidity { get; set; }
        public string Daytime { get; set; }
        public bool Polar { get; set; }
        public string Season { get; set; }
        public int Obs_time { get; set; }
    }
}
