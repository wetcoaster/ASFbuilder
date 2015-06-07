using System;
using System.Collections.Generic;
using ASFbuilder.Equipment;

namespace ASFbuilder.Data
{
    // Hard coded data to be used by default if external equipment file is not found
    static class Armor
    {
        public static List<Equipment.Armor> populateArmor()
        {
            List<Equipment.Armor> armors = new List<Equipment.Armor>();
            armors.Add(new Equipment.Armor(0, 10000, 1m, "Standard", 16, 1.0m));
            armors.Add(new Equipment.Armor(0, 20000, 1m, "Ferro-Aluminum", 16, 1.12m));
            armors.Add(new Equipment.Armor(0, 15000, 1m, "Light Ferro-Aluminum", 16, 1.06m));
            armors.Add(new Equipment.Armor(0, 25000, 1m, "Heavy Ferro-Aluminum", 16, 1.24m));
            armors.Add(new Equipment.Armor(0, 20000, 1m, "Clan Ferro-Aluminum", 16, 1.2m));
            return armors;
        }
    }
}