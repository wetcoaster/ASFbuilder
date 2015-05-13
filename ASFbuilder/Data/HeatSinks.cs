using System;
using System.Collections.Generic;
using ASFbuilder.Equipment;

namespace ASFbuilder.Data
{
    static class HeatSinks
    {
        public static List<Equipment.HeatSinks> populateSinks()
        {
            List<Equipment.HeatSinks> sinks = new List<Equipment.HeatSinks>();
            sinks.Add(new Equipment.HeatSinks(0, 2000, 1m, "Single Heat Sinks", 1));
            sinks.Add(new Equipment.HeatSinks(0, 6000, 1m, "Double Heat Sinks", 2));
            return sinks;
        }
    }
}