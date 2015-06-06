using System;
using System.Collections.Generic;
using System.IO;
using ASFbuilder.Equipment;
using ASFbuilder.Data;
using ASFbuilder.Ships;
using ASFbuilder.Menus;

namespace ASFbuilder.IO
{
    class FighterWriter
    {
        private Fighter AeroFighter { get; set; }                                           // Fighter being printed
        private string InputError { get; set; }                                             // Default error string
        private string PrintLocation { get; set; }                                          // File path
        private ConsoleInput check;                                                         // Console Input checker object
        

        // Constructor
        public FighterWriter(Fighter newFighter)
        {
            AeroFighter = newFighter;                                                       // Set fighter to passed parameter
            check = new ConsoleInput();                                                     // Initialize error checker
            InputError = check.ErrMsg;                                                      // Initialize error message
            PrintLocation = GenerateFileName();                                             // Initialize default file path
        }

        // Methods

        // Generates a file name using fighter name
        private string GenerateFileName()
        {
            return (FileLocation.LOCATION + AeroFighter.Name.Trim().ToLower() + ".csv");    // Concatenates file name from fighter name
        }

        // Writes fighter to a csv file
        public void WriteFighter()
        {
            StreamWriter sr = new StreamWriter(PrintLocation, false);                       // Creates a new streamwriter/overwrites existing txt
            Fighter AF = AeroFighter;                                                       // Shorthand notation

            sr.WriteLine("mass," + AF.Mass.ToString());                                     // Write mass
            sr.WriteLine("designation," + AF.Designation);                                  // Write designation
            sr.WriteLine("name," + AF.Name);                                                // Write name

            foreach (Equipment.Weapon wep in AF.NoseItems)                                  // Iterate through nose items
            {
                WriteWeapon(sr, "nose_item,", wep);                                         // Write weapon to file
            }

            foreach (Equipment.Weapon wep in AF.WingItems)                                  // Iterate through wing items
            {
                WriteWeapon(sr, "wing_item,", wep);                                         // Write weapon
            }

            foreach (Equipment.Weapon wep in AF.AftItems)                                   // Iterate through aft items
            {
                WriteWeapon(sr, "aft_item,", wep);                                          // Write weapon
            }

            foreach (Equipment.Ammo ammo in AF.Ammo)                                        // Iterate through ammo items
            {
                WriteAmmo(sr, "ammo,", ammo);                                               // Write ammo
            }

            WriteArmor(sr, "armor,", AF.Armor);                                             // Write Armor
            WriteEngine(sr, "engine,", AF.Engine);                                          // Write Engine
            WriteHeatSink(sr, "heat_sink,", AF.HeatSink);                                   // Write Heat sink type

            sr.WriteLine("fuel," + AF.Fuel.ToString());                                     // Write Fuel
            sr.WriteLine("sinks," + AF.ExtSinks.ToString());                                // Write external sinks
            sr.WriteLine("armor_mass," + AF.ArmorMass.ToString());                          // Write armor mass
            sr.WriteLine("nose_armor," + AF.NoseArmor.ToString());                          // Write nose armor points
            sr.WriteLine("wing_armor," + AF.WingArmor.ToString());                          // Write wing armor points
            sr.WriteLine("aft_armor," + AF.AftArmor.ToString());                            // Write aft armor points
            sr.WriteLine("safe_thrust," + AF.SafeThrust.ToString());                        // Write safe thrust
            sr.WriteLine("max_thrust," + AF.MaxThrust.ToString());                          // Write max thrust
            sr.WriteLine("controls," + AF.Controls.ToString());                             // Write control system mass

            sr.Close();                                                                     // Close stream writer
            Console.WriteLine("\nSuccessfully saved as " + PrintLocation);                  // Display completion message
        }

        // Writes a heat sink item to csv file
        private void WriteHeatSink(StreamWriter sr, string head, Equipment.HeatSinks heatsink)
        {
            sr.Write(head);                                                                 // Write row header
            sr.Write(heatsink.BV1.ToString() + ",");                                        // Write heatsink BV1
            sr.Write(heatsink.Cost.ToString() + ",");                                       // Write heatsink cost
            sr.Write(heatsink.Mass.ToString() + ",");                                       // Write heatsink mass
            sr.Write(heatsink.Name + ",");                                                  // Write heatsink name
            sr.WriteLine(heatsink.Dissipation.ToString());                                  // Write heatsink dissipation
        }

        // Writes an engine item to csv file
        private void WriteEngine(StreamWriter sr, string head, Equipment.Engine engine)
        {
            sr.Write(head);                                                                 // Write row header
            sr.Write(engine.EngineSize.ToString() + ",");                                   // Write engine size
            sr.Write(engine.Mass.ToString() + ",");                                         // Write engine mass
            sr.Write(engine.Name + ",");                                                    // Write engine name
            sr.WriteLine(engine.EngineType);                                                // Write engine type
        }

        // Writes an armor item to csv file
        private void WriteArmor(StreamWriter sr, string head, Equipment.Armor armor)
        {
            sr.Write(head);                                                                 // Write row header
            sr.Write(armor.BV1.ToString() + ",");                                           // Write armor BV1
            sr.Write(armor.Cost.ToString() + ",");                                          // Write armor cost
            sr.Write(armor.Mass.ToString() + ",");                                          // Write armor mass
            sr.Write(armor.Name + ",");                                                     // Write armor name
            sr.Write(armor.PointsPerTonne.ToString() + ",");                                // Write points per ton
            sr.WriteLine(armor.Multiplier.ToString());                                      // Write armor multiplier
        }

        // Writes an ammo item to csv file
        private void WriteAmmo(StreamWriter sr, string head, Equipment.Ammo ammo)
        {
            sr.Write(head);                                                                 // Write row header
            sr.Write(ammo.BV1.ToString() + ",");                                            // Write aamo BV1
            sr.Write(ammo.Cost.ToString() + ",");                                           // Write ammo cost
            sr.Write(ammo.Mass.ToString() + ",");                                           // Write ammo mass
            sr.Write(ammo.Name + ",");                                                      // Write ammo name
            sr.WriteLine(ammo.AmmoPerTon.ToString());                                       // Write ammo per ton
        }

        // Writes a weapon to csv file
        private void WriteWeapon(StreamWriter sr, string head, Equipment.Weapon wep)
        {
            sr.Write(head);                                                                 // Write weapon row header
            sr.Write(wep.BV1.ToString() + ",");                                             // Write weapon BV1
            sr.Write(wep.Cost.ToString() + ",");                                            // Write weapon cost
            sr.Write(wep.Mass.ToString() + ",");                                            // Write weapon mass
            sr.Write(wep.Name + ",");                                                       // Write weapon name
            sr.Write(wep.Damage.ToString() + ",");                                          // Write weapon damage
            sr.Write(wep.Heat.ToString() + ",");                                            // Write weapon heat
            sr.Write(wep.AmmoPerTon.ToString() + ",");                                      // Write weapon ammo per ton
            sr.Write(wep.Range + ",");                                                      // Write weapon range
            sr.WriteLine(wep.Type);                                                         // Write weapon type
        }
    }
}