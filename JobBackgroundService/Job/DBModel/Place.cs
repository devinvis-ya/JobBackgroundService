using System;
using System.Collections.Generic;
using System.Text;

namespace Job.DBModel
{
    public class Place
    {
        public int Id { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }

    }
}
