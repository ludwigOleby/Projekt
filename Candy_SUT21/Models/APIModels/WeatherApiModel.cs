using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Candy_SUT21.Models.APIModels
{
    public class WeatherApiModel
    {
        public DateTime ApprovedTime { get; set; }
        public DateTime ReferenceTime { get; set; }
        public Geometry Geometry { get; set; }
        public WeatherTimes[] TimeSeries { get; set; }
    }


    public class Geometry
    {
        public string Type { get; set; }
        public float[][] Coordinates { get; set; }
    }

    public class WeatherTimes
    {
        public DateTime ValidTime { get; set; }
        public Parameter[] Parameters { get; set; }
    }

    public class Parameter
    {
        public string Name { get; set; }
        public string LevelType { get; set; }
        public int Level { get; set; }
        public string Unit { get; set; }
        public float[] Values { get; set; }
    }


}
