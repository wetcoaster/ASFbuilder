using System;
using System.Collections.Generic;
using System.Text;
using ASFbuilder.Equipment;
using ASFbuilder.Data;
using ASFbuilder.Ships;
using ASFbuilder.Menus;

namespace ASFbuilder.IO
{
    class ConsoleOutput
    {
        private Fighter AeroFighter { get; set; }                                           // Fighter being displayed
        private string InputError { get; set; }                                             // Default error string
        private bool IsLeave { get; set; }                                                  // Sentinel value for menu
        private ConsoleInput check;                                                         // Console input checker object

        // Constructor
        public ConsoleOutput(Fighter newFighter)
        {
            AeroFighter = newFighter;                                                       // Initialize new fighter
            check = new ConsoleInput();                                                     // Initialize error checker
            InputError = check.ErrMsg;                                                      // Initialize error message
            IsLeave = false;                                                                // Set sentinel boolean
        }

        public void PrintFighter()
        {
            Fighter AF = AeroFighter;                                                       // Shorthand notation
            WeaponMenu wep = new WeaponMenu(AF);                                            // New weapon menu object
            Console.WriteLine("\n===============================================================================");            
            Console.WriteLine("Model/Name:".PadRight(30) + AF.Designation + " " + AF.Name); // Print model number
            Console.WriteLine("Mass:".PadRight(30) + AF.Mass + " tons");                    // Print mass
            Console.WriteLine("\nEquipment:".PadRight(30) + "Mass");                        // Print headers
            Console.WriteLine("\n...............................................................................");
            Console.WriteLine("Power Plant:".PadRight(30) + (AF.Engine.Name +               // Print engine model and mass
                " Fusion").PadRight(40) + AF.Engine.Mass + " tons");
            Console.WriteLine("Safe Thrust".PadRight(30) + AF.SafeThrust);                  // Print safe thrust
            Console.WriteLine("Maximum Thrust:".PadRight(30) + AF.MaxThrust);               // Print max thrust
            Console.WriteLine("Structural Integrity:".PadRight(30) + AF.GetStructure());    // Print structural integrity
            Console.WriteLine("Total Heat Sinks:".PadRight(30) + (AF.TotalSinks() + " " +   // Print heat sinks and mass
                AF.HeatSink.Name).PadRight(40) + AF.ExtSinks.ToString("N2") + " tons");
            Console.WriteLine("Fuel:".PadRight(70) + AF.Fuel.ToString("N2") + " tons");     // Print fuel mass
            Console.WriteLine("Cockpit & Attitude Thruster:".PadRight(70) +                 // Print control systems mass
                AF.Controls.ToString("N2") + " tons\n");
            Console.WriteLine("Armor Type:".PadRight(30) + (AF.Armor.Name + " (" +          // Print armor name and mass
                (AF.NoseArmor + AF.WingArmor * 2 + AF.AftArmor) + 
                " total armor points)").PadRight(40) + (AF.ArmorMass.ToString("N2") + 
                " tons"));
            Console.WriteLine("Armor Distribution".PadLeft(10));                            // Print Armor distribution
            Console.WriteLine("Nose:".PadLeft(2).PadRight(20) + AF.NoseArmor + " points");  // Print nose armor
            Console.WriteLine("Left/Right Wings:".PadLeft(2).PadRight(20) +                 // Print wing armor
                (AF.WingArmor) + " points");  
            Console.WriteLine("Aft:".PadLeft(2).PadRight(20) + AF.AftArmor + " points");    // Print aft armor

            Console.WriteLine("\nWeapons and Equipment");                                   // Section heading
            Console.WriteLine("...............................................................................");
            wep.DisplayWeapons();                                                           // Print all weapons
            Console.WriteLine("...............................................................................");
            Console.WriteLine("\nAmmunition");                                              // Section heading
            foreach (Equipment.Ammo ammo in AeroFighter.Ammo)                               // Iterate through ammo
            {
                Console.WriteLine(ammo.Name.PadRight(30) +                                  // Print ammo details
                    ((ammo.AmmoPerTon * ammo.Mass) + " shots").PadRight(40) +
                    ammo.Mass + " tons");
            }
            Console.WriteLine("\n...............................................................................");
            Console.WriteLine("Total heat:".PadRight(50) + wep.TotalHeat() + " heat");      // Print total heat                       
            Console.WriteLine("Tons Left:".PadRight(70) + AF.FreeTons() + " tons");         // Print empty mass remaining
        }
    }
}