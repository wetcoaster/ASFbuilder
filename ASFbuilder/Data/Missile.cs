using System;
using System.Collections.Generic;
using ASFbuilder.Equipment;

namespace ASFbuilder.Data
{
    static class Missile
    {
        public static List<Weapon> populateMissiles()
        {
            List<Weapon> missiles = new List<Weapon>();

            // Level 1 weapons
            missiles.Add(new Weapon(45, 30000, 2m, "LRM 5", 5, 2, 24, "Long", "Missile"));
            missiles.Add(new Weapon(90, 100000, 5m, "LRM 10", 10, 4, 12, "Long", "Missile"));
            missiles.Add(new Weapon(136, 175000, 7m, "LRM 15", 15, 5, 8, "Long", "Missile"));
            missiles.Add(new Weapon(181, 250000, 10m, "LRM 20", 20, 6, 6, "Long", "Missile"));
            missiles.Add(new Weapon(21, 10000, 1m, "SRM 2", 4, 2, 50, "Short", "Missile"));
            missiles.Add(new Weapon(39, 60000, 2m, "SRM 4", 8, 3, 25, "Short", "Missile"));
            missiles.Add(new Weapon(59, 80000, 3m, "SRM 6", 12, 4, 15, "Short", "Missile"));

            // SL weapons
            missiles.Add(new Weapon(30, 15000, 1.5m, "Streak SRM 2", 4, 2, 50, "Short", "Missile"));
            missiles.Add(new Weapon(30, 100000, 3m, "NARC Missile Beacon", 0, 0, 6, "Short", "Missile"));
            return missiles;
        }
    }
}
