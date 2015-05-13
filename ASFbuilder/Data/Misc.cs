using System;
using System.Collections.Generic;
using ASFbuilder.Equipment;

namespace ASFbuilder.Data
{
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