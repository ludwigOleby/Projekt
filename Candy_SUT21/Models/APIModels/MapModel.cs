using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;

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
        public Guidance guidance { get; set; }
    }

    public class Guidance
    {
        public List<Instruction> instructions{ get; set; }
        public List<InstructionGroup> instructionGroups { get; set; }
    }

    public class InstructionGroup
    {
        public int firstInstructionIndex { get; set; }
        public int lastInstructionIndex { get; set; }
        public string groupMessage { get; set; }
        public int groupLengthInMeters { get; set; }
    }

    public class Instruction
    {
        public int routeOffsetInMeters { get; set; }
        public int travelTimeInSeconds { get; set; }
        public Point point { get; set; }
        public int pointIndex { get; set; }
        public string instructionType { get; set; }
        public string street { get; set; }
        public bool possibleCombineWithNext { get; set; }
        public string drivingSide { get; set; }
        public string maneuver { get; set; }
        public string message { get; set; }
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
        public double lengthInMeters { get; set; }
        public int travelTimeInSeconds { get; set; }
        public int trafficDelayInSeconds { get; set; }
        public int trafficLengthInMeters { get; set; }
        public DateTime departureTime { get; set; }
        public DateTime arrivalTime { get; set; }
    }




}
