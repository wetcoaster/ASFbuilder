using System;
using System.Collections.Generic;
using ASFbuilder.Equipment;

namespace ASFbuilder.Data
{
    static class Ammo
    {
        public static List<Equipment.Ammo> PopulateAmmo()
        {
            List<Equipment.Ammo> ammo = new List<Equipment.Ammo>();
            ammo.Add(new Equipment.Ammo(5, 1000, 1m, "AC2 ammo", 45));
            ammo.Add(new Equipment.Ammo(9, 4500, 1m, "AC5 ammo", 20));
            ammo.Add(new Equipment.Ammo(15, 6000, 1m, "AC10 ammo", 10));
            ammo.Add(new Equipment.Ammo(20, 10000, 1m, "AC20 ammo", 5));
            ammo.Add(new Equipment.Ammo(1, 1000, 1m, "MG ammo", 200));
            ammo.Add(new Equipment.Ammo(1, 1000, 1m, "Veh. Flamer ammo", 20));
            ammo.Add(new Equipment.Ammo(6, 30000, 1m, "LRM 5 ammo", 24));
            ammo.Add(new Equipment.Ammo(11, 30000, 1m, "LRM 10 ammo", 12));
            ammo.Add(new Equipment.Ammo(17, 30000, 1m, "LRM 15 ammo", 8));
            ammo.Add(new Equipment.Ammo(23, 30000, 1m, "LRM 20 ammo", 6));
            ammo.Add(new Equipment.Ammo(3, 27000, 1m, "SRM 2 ammo", 50));
            ammo.Add(new Equipment.Ammo(5, 27000, 1m, "SRM 4 ammo", 25));
            ammo.Add(new Equipment.Ammo(7, 27000, 1m, "SRM 6 ammo", 15));
            return ammo;
        }
    }
}
