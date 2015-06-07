using System;
using System.Collections.Generic;
using ASFbuilder.Equipment;

namespace ASFbuilder.Data
{
    // Hard coded data to be used by default if external equipment file is not found
    static class Misc
    {
        public static List<Item> populateMisc()
        {
            List<Item> defaults = new List<Item>();
            defaults.Add(new Item(3m, "Cockpit & Attitude Thrusters"));
            return defaults;
        }
    }
}