using System;
using System.Collections.Generic;
using System.IO;
using ASFbuilder.Equipment;
using ASFbuilder.Data;
using ASFbuilder.Ships;
using ASFbuilder.Menus;

namespace ASFbuilder.IO
{
    class TextWriter
    {
        private Fighter AeroFighter { get; set; }                                           // Fighter being printed
        private string InputError { get; set; }                                             // Default error string
        private string PrintLocation { get; set; }                                          // File path
        private ConsoleInput check;                                                         // Console Input checker object
        

        // Constructor
        public TextWriter(Fighter newFighter)
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
            return (FileLocation.LOCATION + AeroFighter.Name + ".txt");                     // Concatenates file name from fighter name
        }

        // Writes fighter to a text file
        public void WriteFighter()
        {
            StreamWriter sWriter = new StreamWriter(PrintLocation, false);                  // Creates a new streamwriter/overwrites existing txt
            DateTime printTime = DateTime.Now;                                              // Today's date
            Fighter AF = AeroFighter;                                                       // Shorthand notation
            WeaponMenu wep = new WeaponMenu(AF);                                            // New weapon menu object to hold all weapons

            sWriter.WriteLine("\n===============================================================================");
            sWriter.WriteLine("Model/Name:".PadRight(30) + AF.Designation + " " + AF.Name); // Print model number
            sWriter.WriteLine("Mass:".PadRight(30) + AF.Mass + " tons");                    // Print mass
            sWriter.WriteLine("\nEquipment:".PadRight(30) + "Mass");                        // Print headers
            sWriter.WriteLine("\n...............................................................................");

            sWriter.WriteLine("Power Plant:".PadRight(30) + (AF.Engine.Name +               // Print engine model and mass
                " Fusion").PadRight(40) + AF.Engine.Mass + " tons");
            sWriter.WriteLine("Safe Thrust".PadRight(30) + AF.SafeThrust);                  // Print safe thrust
            sWriter.WriteLine("Maximum Thrust:".PadRight(30) + AF.MaxThrust);               // Print max thrust
            sWriter.WriteLine("Structural Integrity:".PadRight(30) + AF.GetStructure());    // Print structural integrity
            sWriter.WriteLine("Total Heat Sinks:".PadRight(30) + (AF.TotalSinks() + " " +   // Print heat sinks and mass
                AF.HeatSink.Name).PadRight(40) + AF.ExtSinks.ToString("N2") + " tons");
            sWriter.WriteLine("Fuel:".PadRight(70) + AF.Fuel.ToString("N2") + " tons");     // Print fuel mass
            sWriter.WriteLine("Cockpit & Attitude Thruster:".PadRight(70) +                 // Print control systems mass
                AF.Controls.ToString("N2") + " tons\n");
            sWriter.WriteLine("Armor Type:".PadRight(30) + (AF.Armor.Name + " (" +          // Print armor name and mass
                (AF.NoseArmor + AF.WingArmor * 2 + AF.AftArmor) +
                " total armor points)").PadRight(40) + (AF.ArmorMass.ToString("N2") +
                " tons"));
            sWriter.WriteLine("Armor Distribution".PadLeft(10));                            // Print Armor distribution
            sWriter.WriteLine("Nose:".PadLeft(2).PadRight(20) + AF.NoseArmor + " points");  // Print nose armor
            sWriter.WriteLine("Left/Right Wings:".PadLeft(2).PadRight(20) +                 // Print wing armor
                (AF.WingArmor) + " points");
            sWriter.WriteLine("Aft:".PadLeft(2).PadRight(20) + AF.AftArmor + " points");    // Print aft armor

            sWriter.WriteLine("\nWeapons and Equipment");                                   // Section heading
            sWriter.WriteLine("...............................................................................");
            PrintWeapons(sWriter);                                                          // Print all weapons            
            sWriter.WriteLine("\nAmmunition");                                              // Section heading
            sWriter.WriteLine("...............................................................................");
            foreach (Equipment.Ammo ammo in AeroFighter.Ammo)                               // Iterate through ammo
            {
                sWriter.WriteLine(ammo.Name.PadRight(30) +                                  // Print ammo details
                    ((ammo.AmmoPerTon * ammo.Mass) + " shots").PadRight(40) +
                    ammo.Mass + " tons");
            }
            sWriter.WriteLine("\n...............................................................................");
            sWriter.WriteLine("Total heat:".PadRight(50) + wep.TotalHeat());                // Print total heat                       
            sWriter.WriteLine("Tons Left:".PadRight(70) + AF.FreeTons() + " tons");         // Print empty mass remaining

            Console.WriteLine("Fighter printed to " + PrintLocation);                       // Console confirmation
            Console.WriteLine("Printed on " + printTime);                                   // Console time stamp
            sWriter.WriteLine();                                                            // Blank space
            sWriter.WriteLine("Printed on " + printTime);                                   // Time stamp for text file

            sWriter.Close();                                                                // Close streamwriter
        }

        // Prints info on nose weapons
        private void PrintNose(StreamWriter sWriter)
        {
            sWriter.WriteLine("\nNose:");
            int i = 1;                                                                      // Nose item counter
            foreach (Weapon wep in AeroFighter.NoseItems)                                   // Iterate through nose weapons
            {
                sWriter.WriteLine(i + ". " + wep.Name.PadRight(20) +                        // Print item details
                    (wep.Damage.ToString() + " damage").PadRight(14) +
                    (wep.Heat.ToString() + " heat").PadRight(12) +
                    (wep.Range + " range").PadRight(14) +
                    wep.Mass.ToString().PadRight(4) + "tons");
                i++;                                                                        // Increment counter
            }
        }

        // Prints info on wing weapons
        private void PrintWing(StreamWriter sWriter)
        {
            Console.WriteLine("\nWing:");
            int j = 1;                                                                      // Wing item counter
            foreach (Weapon wep in AeroFighter.WingItems)                                   // Iterate through wing weapons
            {
                sWriter.WriteLine(j + ". " + wep.Name.PadRight(20) +                        // Print item details
                    (wep.Damage.ToString() + " damage").PadRight(14) +
                    (wep.Heat.ToString() + " heat").PadRight(12) +
                    (wep.Range + " range").PadRight(14) +
                    wep.Mass.ToString().PadRight(4) + "tons");
                j++;                                                                        // Increment counter
            }
        }

        // Prints info on aft weapons
        private void PrintAft(StreamWriter sWriter)
        {
            sWriter.WriteLine("\nAft:");
            int k = 1;                                                                      // Aft item counter
            foreach (Weapon wep in AeroFighter.AftItems)                                    // Iterate through aft weapons
            {
                Console.WriteLine(k + ". " + wep.Name.PadRight(20) +                        // Print item details
                    (wep.Damage.ToString() + " *2 damage").PadRight(14) +
                    (wep.Heat.ToString() + " *2 heat").PadRight(12) +
                    (wep.Range + " range").PadRight(14) +
                    wep.Mass.ToString().PadRight(4) + "tons");
                k++;                                                                        // Increment counter
            }
        }

        // Prints info on all weapons on fighter
        public void PrintWeapons(StreamWriter sWriter)
        {
            sWriter.WriteLine("\nCurrent Weapons:");                                        // Heading
            sWriter.WriteLine("...............................................................................");
            PrintNose(sWriter);                                                             // Show nose weapons
            PrintWing(sWriter);                                                             // Show wing weapons
            PrintAft(sWriter);                                                              // Show aft weapons
            sWriter.WriteLine("...............................................................................\n");
        }
    }
}
