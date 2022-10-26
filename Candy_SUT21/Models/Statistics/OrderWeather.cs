using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Candy_SUT21.Models.Statistics
{
    public class OrderWeather
    {
        public int OrderWeatherId { get; set; }
        public float RainMean { get; set; }
        public float WeatherSymbol { get; set; }
        public float Temperature { get; set; }
        public int OrderId { get; set; }
        public Order Order { get; set; }
    }
}
