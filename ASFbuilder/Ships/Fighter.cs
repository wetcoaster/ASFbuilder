using System;
using System.Collections.Generic;
using ASFbuilder.Data;
using ASFbuilder.Equipment;

namespace ASFbuilder.Ships
{
    class Fighter
    {
        public const int FREE_SINKS = 10;
        public const decimal CONTROL_SYSTEMS = 3m;       
        
        public string Name { get; set; }
        public string Designation { get; set; }
        public decimal Mass { get; set; }
        public List<Item> WingItems { get; set; }
        public List<Item> NoseItems { get; set; }
        public List<Item> AftItems { get; set; }
        public Equipment.Armor Armor { get; set; }
        public int NoseArmor { get; set; }
        public int WingArmor { get; set; }
        public int AftArmor { get; set; }
        public int ExtSinks { get; set; }
        public Equipment.HeatSinks HeatSink { get; set; }
        public Equipment.Engine Engine { get; set; }
        public List<Equipment.Ammo> Ammo { get; set; }
        public int Fuel { get; set; }
        public decimal ArmorMass { get; set; }
        public int SafeThrust { get; set; }
        public int MaxThrust { get; set; }
        public decimal Controls { get; set; }

        // Constructors

        public Fighter()
        {
            Mass = 100m;
            WingItems = new List<Item>();
            NoseItems = new List<Item>();
            AftItems = new List<Item>();
            Ammo = new List<Equipment.Ammo>();
            Designation = "Not Applicable";
            Name = "No Name";
            Armor = new Equipment.Armor(0, 10000, 1m, "Standard", 16, 1.0m);
            NoseArmor = 0;
            WingArmor = 0;
            AftArmor = 0;
            ExtSinks = 0;
            Fuel = 0;
            ArmorMass = 0;
            HeatSink = new Equipment.HeatSinks(0, 2000, 1m, "Single Heat Sinks", 1);
            Engine = new Equipment.Engine(100, 3.0m, "100 Standard", "SFE");
            SafeThrust = 3;
            MaxThrust = 5;
            Controls = CONTROL_SYSTEMS;
        }

        // Constructor for loading an already-created fighter
        public Fighter(int mass, string designation, string name,
            List<Item> noseItems, List<Item> wingItems, List<Item> aftItems, 
            Equipment.Armor armor, Equipment.Engine engine, List<Equipment.Ammo> ammo,
            Equipment.HeatSinks heatSink, int fuel, int sinks, decimal armorMass, 
            int noseArmor, int wingArmor, int aftArmor,
            int safeThrust, int maxThrust, int controls)
        {
            Mass = mass;
            Designation = designation;
            Name = name;
            NoseItems = noseItems;
            WingItems = wingItems;
            AftItems = aftItems;
            Armor = armor;
            Engine = engine;
            Ammo = ammo;
            Fuel = fuel;
            HeatSink = heatSink;
            ExtSinks = sinks;                       
            ArmorMass = armorMass;
            NoseArmor = noseArmor;
            WingArmor = wingArmor;
            AftArmor = aftArmor;
            SafeThrust = safeThrust;
            MaxThrust = maxThrust;
            Controls = controls;
        }

        // Methods
        public decimal FreeTons()
        {
            decimal wepMass = 0m;
            decimal ammoMass = 0m;

            foreach (Weapon wep in NoseItems)
            {
                wepMass += wep.Mass;
            }
            foreach (Weapon wep in WingItems)
            {
                wepMass += wep.Mass * 2;
            }
            foreach (Weapon wep in AftItems)
            {
                wepMass += wep.Mass;
            }
            foreach (Item ammo in Ammo)
            {
                ammoMass += ammo.Mass;
            }

            decimal freeTons = Mass;
            freeTons -= ArmorMass;
            freeTons -= Fuel;
            freeTons -= CONTROL_SYSTEMS;
            freeTons -= Engine.Mass;
            freeTons -= wepMass;
            freeTons -= ammoMass;
            freeTons -= ExtSinks;

            return freeTons;
        }

        public int HeatGenerated()
        {
            int heat = 0;
            foreach (Weapon wep in NoseItems)
            {
                heat += wep.Heat;
            }
            foreach (Weapon wep in WingItems)
            {
                heat += wep.Heat * 2;
            }
            foreach (Weapon wep in AftItems)
            {
                heat += wep.Heat;
            }

            return heat;        
        }

        public int TotalSinks()
        {
            return ExtSinks + FREE_SINKS;
        }

        public int GetStructure()
        {
            decimal byMass = Mass / 10;
            if ((int)byMass >= SafeThrust)
            {
                return (int)byMass;
            }
            else
            {
                return SafeThrust;
            }
        }
    }
}
