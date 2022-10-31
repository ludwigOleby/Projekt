using System;
using System.Collections.Generic;

namespace Candy_SUT21.Models.APIModels
{


    public class Leg
    {
        public Summary summary { get; set; }
        public List<Point> points { get; set; }
    }

    public class Point
    {
        public double latitude { get; set; }
        public double longitude { get; set; }
    }

    public class Root
    {
        public string formatVersion { get; set; }
        public List<Route> routes { get; set; }
    }

    public class Route
    {
        public Summary summary { get; set; }
        public List<Leg> legs { get; set; }
        public List<Section> sections { get; set; }
    }

    public class Section
    {
        public int startPointIndex { get; set; }
        public int endPointIndex { get; set; }
        public string sectionType { get; set; }
        public string travelMode { get; set; }
    }

    public class Summary
    {
        public int lengthInMeters { get; set; }
        public int travelTimeInSeconds { get; set; }
        public int trafficDelayInSeconds { get; set; }
        public int trafficLengthInMeters { get; set; }
        public DateTime departureTime { get; set; }
        public DateTime arrivalTime { get; set; }
    }




}
