using System;
using System.Collections.Generic;
using System.Text;
using ASFbuilder.Equipment;
using ASFbuilder.Data;
using ASFbuilder.IO;
using ASFbuilder.Ships;

namespace ASFbuilder.Menus
{
    class AmmoMenu
    {
        private Fighter AeroFighter { get; set; }                                           // Fighter being modified
        private string InputError { get; set; }                                             // Default error string
        private bool IsLeave { get; set; }                                                  // Sentinel value for menu
        private ConsoleInput check;                                                         // Console Input checker object   

        // Constructor
        public AmmoMenu(Fighter newFighter)
        {
            AeroFighter = newFighter;                                                       // Set fighter to passed parameter
            check = new ConsoleInput();                                                     // Initialize error checker
            IsLeave = false;                                                                // Initialize quit sentinel
            InputError = check.ErrMsg;                                                      // Initialize error message
        }

        // Calls top level menu until sentinel value is flipped, then returns fighter
        public Fighter ChangeAmmo()
        {
            while (!IsLeave)                                                                // Until user decides to leave
            {
                ModAmmo();                                                                  // Call main ammo menu
            }
            return AeroFighter;
        }

        // Top level menu for ammo
        private void ModAmmo()
        {
            string[] options = new string[] { "1", "2", "3" };                              // Valid inputs
            bool isValid = false;                                                           // Sentinel value for valid input            
            string userInput = InputError;                                                  // Input string

            while (!isValid)                                                                // Until a valid input is entered...
            {
                DisplayAmmo(AeroFighter.Ammo);                                              // Display current ammo information
                PrintMainMenu();                                                            // Show menu options
                userInput = check.ParseInput(Console.ReadLine());                           // Read and parse user input
                isValid = check.Validate(userInput, options);                               // Validate input                
            }
            switch (userInput)
            {
                case "1":
                    AddAmmo();                                                              // Add ammo
                    break;
                case "2":
                    RemoveAmmo();                                                           // Remove ammo
                    break;
                case "3":
                    IsLeave = true;                                                         // Return to previous menu
                    break;
                default:
                    Console.WriteLine(InputError);                                          // Default case is an error
                    break;
            }
        }

        private void AddAmmo()
        {
            List<Equipment.Weapon> needAmmo = FindAmmoWeps();                               // Get list of weapons that need ammo
            bool isValid = false;                                                           // Sentinel value
            string userInput = InputError;                                                  // Input string
            Equipment.Weapon addAmmo = null;                                                // Ammo type being added
            decimal qtyAdded = 0m;                                                          // Quantity of ammo being added
            if (needAmmo.Count == 0)                                                        // Check if list is empty before proceeding
            {
                Console.WriteLine("None of your weapons require ammunition!");              // Notify use that no ammo weapons equipped
                isValid = true;
            }

            while (!isValid)                                                                // While input is invalid
            {
                int userChoice;                                                             // Variable holds user input                
                Console.WriteLine("\nPlease enter the number for the type of ammunition " + // User Prompt
                    "that you would like to add and press the Enter key.");
                PrintAmmoWeps(needAmmo);                                                    // Display ammo types
                Console.Write("Selection: ");                                               // User Prompt
                userInput = check.ParseInput(Console.ReadLine());                           // Read and parse user input as string

                if (Int32.TryParse(userInput, out userChoice))                              // Parse input into an int
                {
                    if (userChoice > 0 && userChoice <= needAmmo.Count)                     // Validate int is within parameters
                    {
                        addAmmo = needAmmo[userChoice - 1];                                 // Select weapon at specified parameter  
                        isValid = true;                                                     // Allocate weapon returns boolean for success                         
                    }
                    else
                    {
                        Console.WriteLine("\nNumber entered is not a valid option");        // Invalid value error message
                    }
                }
                else
                {
                    Console.WriteLine(InputError);                                          // Invalid input error message
                }

                Console.WriteLine("\nHow many tons of this ammo would you like to add?");   // Prompt user
                userInput = check.ParseInput(Console.ReadLine());                           // Read and parse user input as string

                if (decimal.TryParse(userInput, out qtyAdded))                              // Parse input into a decimal and assign to qtyAdded
                {
                    if (qtyAdded > 0 && qtyAdded < AeroFighter.Mass && addAmmo != null)     // Validate int is within parameters and weapon is not null
                    {                        
                        AeroFighter.Ammo.Add(new Equipment.Ammo(0, 0, qtyAdded,             // Create new ammo object of specified type and mass
                            (addAmmo.Name + " ammo"), addAmmo.AmmoPerTon));
                    }
                    else
                    {
                        Console.WriteLine("\nNumber entered is not a valid option");        // Invalid value error message
                    }
                }
                else
                {
                    Console.WriteLine(InputError);                                          // Invalid input error message
                }                
            }
        }

        // Shows all current ammo and removes the one at the specified index
        private void RemoveAmmo()
        {
            bool isValid = false;                                                           // Sentinel value
            string userInput = InputError;                                                  // Input string

            while (!isValid)                                                                // While input is invalid
            {
                int userChoice;                                                             // Variable holds user input                
                Console.WriteLine("\nPlease enter the number for the type of ammunition " + // User Prompt
                    "that you would like to remove and press the Enter key.");
                DisplayAmmo(AeroFighter.Ammo);                                              // Display ammo
                Console.Write("Selection: ");                                               // User Prompt
                userInput = check.ParseInput(Console.ReadLine());                           // Read and parse user input as string

                if (Int32.TryParse(userInput, out userChoice))                              // Parse input into an int
                {
                    if (userChoice > 0 && userChoice <= AeroFighter.Ammo.Count)             // Validate int is within parameters
                    {
                        AeroFighter.Ammo.RemoveAt(userChoice - 1);                          // Remove ammo at specified location  
                        isValid = true;                                                     // Toggle success                         
                    }
                    else
                    {
                        Console.WriteLine("\nNumber entered is not a valid option");        // Invalid value error message
                    }
                }
                else
                {
                    Console.WriteLine(InputError);                                          // Invalid input error message
                }
            }
        }

        // Returns a list of all ammunition using weapons
        private List<Weapon> FindAmmoWeps()
        {
            List<Weapon> needAmmo = new List<Weapon>();                                     // List to hold weapons that need ammo
            List<Item> allWeps = new List<Item>();                                          // List to hold all items on fighter
            allWeps.AddRange(AeroFighter.NoseItems);                                        // Adds nose items to allweps
            allWeps.AddRange(AeroFighter.WingItems);                                        // Adds wing items to allweps
            allWeps.AddRange(AeroFighter.AftItems);                                         // Adds aft items to allweps

            foreach (Equipment.Weapon wep in allWeps)                                       // Iterates through weapons in a location
            {
                if (!needAmmo.Contains(wep) && wep.AmmoPerTon != 0)                         // If weapon is not on list and needs ammo
                {
                    needAmmo.Add(wep);                                                      // Add it to the list
                }
            }
            return needAmmo;                                                                // Return list of weapons
        }

        // Prints a list of all the ammunition types that fighter uses
        private void PrintAmmoWeps(List<Weapon> needAmmo)
        {
            int i = 1;                                                                      // Counter
            foreach (Equipment.Weapon wep in needAmmo)                                      // Iterates through list of weapons
            {
                Console.WriteLine((i + ". ") + wep.Name.PadRight(20) +                      // Print item details
                    (wep.Damage.ToString() + " damage").PadRight(14) +                    
                    (wep.Range + " range").PadRight(14) +
                    (wep.AmmoPerTon).ToString().PadRight(4) + "shots/ton");
                i++;                                                                        // Increment counter
            }
        }
        
        // Prints main menu
        private void PrintMainMenu()
        {
            Console.WriteLine("\n1. Add ammo");
            Console.WriteLine("2. Remove ammo");
            Console.WriteLine("3. Return to previous menu");
            Console.Write("Selection: ");
        }

        // Displays current ammo
        private void DisplayAmmo(List<Equipment.Ammo> ammoList)
        {
            int i = 0;                                                                      // Index tracker
            foreach (Equipment.Ammo ammo in ammoList)
            {
                Console.WriteLine(((i + 1) + ".").PadRight(5) + ammo.Name.PadRight(20) +    // Print ammo information
                    (ammo.Mass.ToString("N2").PadRight(5) + "tons").PadRight(9) +
                    (((int)(ammo.AmmoPerTon * ammo.Mass)).ToString().PadRight(5) +
                    "shots").PadRight(12) + ammo.Cost.ToString() + " C-bills");
                i++;                                                                        // Increment tracker
            }
        }
    }
}