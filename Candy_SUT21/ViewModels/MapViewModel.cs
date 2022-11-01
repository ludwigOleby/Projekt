using Candy_SUT21.Models.APIModels;
using System;

namespace Candy_SUT21.ViewModels
{
    public class MapViewModel
    {
        public double distance { get; set; }
        public DateTime departureTime { get; set; }
        public DateTime arrivalTime { get; set; }
        public string[] StorageCord { get; set; }
        public string[] CustomerCord { get; set; }
        public Guidance guidance{ get; set; }

    }
}
