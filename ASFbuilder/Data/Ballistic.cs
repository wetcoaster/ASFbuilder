using System;
using System.Collections.Generic;
using ASFbuilder.Equipment;

namespace ASFbuilder.Data
{
    static class Ballistic
    {
        public static List<Weapon> populateGuns(){
            List<Weapon> ballistics = new List<Weapon>();

            // Level 1 weapons
            ballistics.Add(new Weapon(37, 75000, 6m, "Autocannon/2", 2, 1, 45, "Long", "Ballistic"));
            ballistics.Add(new Weapon(70, 125000, 8m, "Autocannon/5", 5, 1, 20, "Medium", "Ballistic"));
            ballistics.Add(new Weapon(124, 200000, 12m, "Autocannon/10", 10, 3, 10, "Medium", "Ballistic"));
            ballistics.Add(new Weapon(178, 300000, 14m, "Autocannon/20", 20, 7, 5, "Short", "Ballistic"));
            ballistics.Add(new Weapon(5, 5000, 0.5m, "Machine Gun", 2, 0, 200, "Short", "Ballistic"));
            ballistics.Add(new Weapon(5, 75000, 0.5m, "Vehicle Flamer", 2, 3, 20, "Short", "Ballistic"));

            // Star League weapons
            ballistics.Add(new Weapon(113, 200000, 9m, "Ultra AC/5", 7, 2, 20, "Long", "Ballistic"));
            ballistics.Add(new Weapon(148, 400000, 11m, "LB 10-X AC", 6, 2, 10, "Medium", "Ballistic"));
            ballistics.Add(new Weapon(321, 300000, 15m, "Gauss Rifle", 15, 1, 8, "Long", "Ballistic"));
            return ballistics;
        }
    }
}
