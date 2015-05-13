using System;
using System.Collections.Generic;
using ASFbuilder.Equipment;

namespace ASFbuilder.Data
{
    static class Energy
    {
        public static List<Weapon> populateBeams()
        {
            List<Weapon> beams = new List<Weapon>();

            // Level 1 weapons
            beams.Add(new Weapon(6, 7500, 0.5m, "Flamer", 2, 3, 0, "Short", "Energy"));
            beams.Add(new Weapon(124, 100000, 5m, "Large Laser", 8, 8, 0, "Medium", "Energy"));
            beams.Add(new Weapon(46, 40000, 1m, "Medium Laser", 5, 3, 0, "Short", "Energy"));
            beams.Add(new Weapon(9, 11250, 0.5m, "Small Laser", 3, 1, 0, "Short", "Energy"));
            beams.Add(new Weapon(176, 200000, 7m, "PPC", 10, 10, 0, "Medium", "Energy"));

            // Star League weapons
            beams.Add(new Weapon(163, 200000, 5m, "ER Large Laser", 8, 12, 0, "Long", "Energy"));
            beams.Add(new Weapon(119, 175000, 7m, "Large Pulse Laser", 9, 10, 0, "Medium", "Energy"));
            beams.Add(new Weapon(48, 60000, 2m, "Medium Pulse Laser", 6, 4, 0, "Short", "Energy"));
            beams.Add(new Weapon(12, 16000, 1m, "Small Pulse Laser", 3, 2, 0, "Short", "Energy"));
            beams.Add(new Weapon(229, 300000, 7m, "ER PPC", 10, 15, 0, "Long", "Energy"));
            return beams;
        }
    }
}
