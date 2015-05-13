using System;
using System.Collections.Generic;
using System.Text;
using ASFbuilder.Equipment;
using ASFbuilder.Data;
using ASFbuilder.IO;
using ASFbuilder.Ships;

namespace ASFbuilder.Menus
{
    class WeaponMenu
    {
        const string INPUT_ERROR = "Invalid Entry\n";                                       // Default for initializing strings
        private Fighter AeroFighter { get; set; }                                           // Fighter being modified
        private List<Weapon> Beams { get; set; }                                            // List of available energy weapons
        private List<Weapon> Guns { get; set; }                                             // List of available ballistics
        private List<Weapon> Missiles { get; set; }                                         // List of available missiles
        private List<Equipment.Armor> ArmorType { get; set; }                               // List of available armor types
        private string InputError { get; set; }                                             // Default error string
        private bool IsLeave { get; set; }                                                  // Sentinel value for menu
        private ConsoleInput check;                                                         // Console Input checker object
        private int MaxNose { get; set; }                                                   // Max nose weapons (determined by armor)
        private int MaxWing { get; set; }                                                   // Max wing weapons (determined by armor)
        private int MaxAft { get; set; }                                                    // Max aft weapons (determined by armor)
        public WeaponMenu(Fighter newFighter)
        {
            check = new ConsoleInput();                                                     // Initialize error checker
            ArmorType = Data.Armor.populateArmor();                                         // Initialize list of available armor
            InputError = check.ErrMsg;                                                      // Set error message to checker message
            AeroFighter = newFighter;                                                       // Accept passed fighter
            Beams = Data.Energy.populateBeams();                                            // Initialize list of available energy weapons
            Guns = Data.Ballistic.populateGuns();                                           // Initialize list of available ballistics
            Missiles = Data.Missile.populateMissiles();                                     // Initialize list of available missiles 
            SetMaxWeapons();                                                                // Initialize weapon limits
        }

        // Calls top level menu until sentinel value is flipped, then returns fighter
        public Fighter ChangeWeapons()
        {
            while (!IsLeave)                                                                // Until user decides to quit
            {
                WeaponsMainMenu();                                                          // Call main menu
            }
            return AeroFighter;                                                             // Return modfied fighter when done
        }
        public Fighter WeaponsMainMenu()
        {
            //List of valid options for validation
            string[] options = new string[] { "1", "2", "3", "4", "5" };                    // Valid inputs
            bool isValid = false;                                                           // Sentinel value
            string userSelection = INPUT_ERROR;                                             // Input string

            while (!isValid)
            {
                WeaponsMenu();                                                              // Print weapon menu

                userSelection = check.ParseInput(Console.ReadLine());                       // Read and parse user input
                isValid = check.Validate(userSelection, options);                           // Validate input
                // Switch follows user input
                switch (userSelection)
                {
                    case "1":
                        AddBeams();                                                         // Add energy weapons
                        break;
                    case "2":
                        AddGuns();                                                          // Add ballistic weapons
                        break;
                    case "3":
                        AddMissiles();                                                      // Add missile weapons
                        break;
                    case "4":                                                               
                        RemoveWeapon();                                                     // Remove a weapon
                        break;
                    case "5":
                        IsLeave = true;                                                     // Return to previous menu                                    
                        break;  
                    default:
                        Console.WriteLine(INPUT_ERROR);                                     // Default case is an error
                        break;
                }               
            }
            return AeroFighter;                                                             // Return modified fighter
        }

        private void AddBeams()
        {
            bool isValid = false;                                                           // Sentinel value
            string userInput = InputError;                                                  // Input string

            while (!isValid)                                                                // While input is invalid
            {
                int userChoice;                                                             // Variable holds user input
                DisplayWeapons();                                                           // Display current weapon information
                Console.WriteLine("\nPlease enter the number for the type of weapon " +     // User Prompt
                    "you would like to select and press the Enter key.");
                Console.WriteLine("\n".PadRight(4) + "Name".PadRight(20) +                  // Display headers
                    "Damage".PadRight(7) + "Heat".PadRight(6) + 
                    "Ammo".PadRight(10) + "Range".PadRight(8) + 
                    "Mass".PadRight(9) + "Cost");
                
                for (int i = 0; i < Beams.Count; i++)                                       // Iterate through list of available weapon types
                {                                                                           // Print detail for each armor type
                    Console.WriteLine(((i + 1) + ". ").PadRight(3) +                        // Print option number
                        Beams[i].Name.PadRight(20) +                                        // Print weapon name
                        Beams[i].Damage.ToString().PadRight(7) +                            // Print weapon damage
                        Beams[i].Heat.ToString().PadRight(6) +                              // Print weapon heat
                        (checkInfinite(Beams[i].AmmoPerTon).PadRight(4) +                   // Print weapon ammo
                        "/ton").PadRight(10) + Beams[i].Range.PadRight(8) +
                        (Beams[i].Mass.ToString() + " tons").PadRight(9) +                  // Print weapon mass
                        Beams[i].Cost.ToString().PadRight(7) + " C-bills");                 // Print weapon cost
                }
                Console.Write("Selection: ");
                userInput = check.ParseInput(Console.ReadLine());                           // Read and parse user input as string
                
                if (Int32.TryParse(userInput, out userChoice))                              // Parse input into an int
                {
                    if (userChoice > 0 && userChoice <= Beams.Count)                        // Validate int is within parameters
                    {
                        Weapon newWep = Beams[userChoice - 1];                              // Set new weapon, index offset
                        isValid = AllocateWeapon(newWep);                                   // Allocate weapon returns boolean for success                         
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

        private void AddGuns()
        {
            bool isValid = false;                                                           // Sentinel value
            string userInput = InputError;                                                  // Input string

            while (!isValid)                                                                // While input is invalid
            {
                int userChoice;                                                             // Variable holds user input
                DisplayWeapons();                                                           // Display current weapon information
                Console.WriteLine("\nPlease enter the number for the type of weapon " +     // User Prompt
                    "you would like to select and press the Enter key.");
                Console.WriteLine("\n".PadRight(4) + "Name".PadRight(20) +                  // Display headers
                     "Damage".PadRight(7) + "Heat".PadRight(6) +
                     "Ammo".PadRight(10) + "Range".PadRight(8) +
                     "Mass".PadRight(9) + "Cost");

                for (int i = 0; i < Guns.Count; i++)                                        // Iterate through list of available weapon types
                {                                                                           // Print detail for each armor type
                    Console.WriteLine(((i + 1) + ". ").PadRight(3) +                        // Print option number
                        Guns[i].Name.PadRight(20) +                                         // Print weapon name
                        Guns[i].Damage.ToString().PadRight(7) +                             // Print weapon damage
                        Guns[i].Heat.ToString().PadRight(6) +                               // Print weapon heat
                        (checkInfinite(Guns[i].AmmoPerTon).PadRight(4) +                    // Print weapon ammo
                        "/ton").PadRight(10) + Guns[i].Range.PadRight(8) +
                        (Guns[i].Mass.ToString() + " tons").PadRight(9) +                   // Print weapon mass
                        Guns[i].Cost.ToString().PadRight(7) + " C-bills");                  // Print weapon cost                    
                }
                Console.Write("Selection: ");
                userInput = check.ParseInput(Console.ReadLine());                           // Read and parse user input as string

                if (Int32.TryParse(userInput, out userChoice))                              // Parse input into an int
                {
                    if (userChoice > 0 && userChoice <= Beams.Count)                        // Validate int is within parameters
                    {
                        Weapon newWep = Guns[userChoice - 1];                               // Set new weapon, index offset
                        isValid = AllocateWeapon(newWep);                                   // Allocate weapon returns boolean for success                         
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

        private void AddMissiles()
        {
            bool isValid = false;                                                           // Sentinel value
            string userInput = InputError;                                                  // Input string

            while (!isValid)                                                                // While input is invalid
            {
                int userChoice;                                                             // Variable holds user input
                DisplayWeapons();                                                           // Display current weapon information
                Console.WriteLine("\nPlease enter the number for the type of weapon " +     // User Prompt
                    "you would like to select and press the Enter key.");
                Console.WriteLine("\n".PadRight(4) + "Name".PadRight(20) +                  // Display headers
                     "Damage".PadRight(7) + "Heat".PadRight(6) +
                     "Ammo".PadRight(10) + "Range".PadRight(8) +
                     "Mass".PadRight(9) + "Cost");

                for (int i = 0; i < Missiles.Count; i++)                                    // Iterate through list of available weapon types
                {                                                                           // Print detail for each armor type
                    Console.WriteLine(((i + 1) + ". ").PadRight(3) +                        // Print option number
                        Missiles[i].Name.PadRight(20) +                                     // Print weapon name
                        Missiles[i].Damage.ToString().PadRight(7) +                         // Print weapon damage
                        Missiles[i].Heat.ToString().PadRight(6) +                           // Print weapon heat
                        (checkInfinite(Missiles[i].AmmoPerTon).PadRight(4) +                // Print weapon ammo
                        "/ton").PadRight(10) + Missiles[i].Range.PadRight(8) +
                        (Missiles[i].Mass.ToString() + " tons").PadRight(9) +               // Print weapon mass
                        Missiles[i].Cost.ToString().PadRight(7) + " C-bills");              // Print weapon cost
                }
                Console.Write("Selection: ");
                userInput = check.ParseInput(Console.ReadLine());                           // Read and parse user input as string

                if (Int32.TryParse(userInput, out userChoice))                              // Parse input into an int
                {
                    if (userChoice > 0 && userChoice <= Beams.Count)                        // Validate int is within parameters
                    {
                        Weapon newWep = Missiles[userChoice - 1];                           // Set new weapon, index offset
                        isValid = AllocateWeapon(newWep);                                   // Allocate weapon returns boolean for success                         
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

        private bool AllocateWeapon(Weapon newWep)
        {
            string[] options = new string[] { "1", "2", "3", "4"};                          // Valid inputs
            bool isValid = false;                                                           // Sentinel value for valid input
            bool success = false;                                                           // Sentinel value for success
            string userInput = InputError;                                                  // Input string

            while (!isValid)                                                                // Until a valid input is entered...
            {
                Console.WriteLine("\nChoose the location you would like to add the " +      // Prompt user
                    "weapon to");
                LocMenu();                                                                  // Show menu options
                userInput = check.ParseInput(Console.ReadLine());                           // Read and parse user input
                isValid = check.Validate(userInput, options);                               // Validate input                
            }

            switch (userInput)                                                              // Switch to determine location
            {
                case "1":
                    success = AddNose(newWep);                                              // Add weapon to fighter nose
                    break;
                case "2":
                    success = AddWing(newWep);                                              // Add weapon to fighter wings
                    break;
                case "3":
                    success = AddAft(newWep);                                               // Add weapon to fighter aft
                    break;
                case "4":
                    success = true;                                                         // Cancel weapon add
                    break;
                default:
                    Console.WriteLine("Weapon allocation error");                           // Error message
                    break;
            }
            return success;                                                                 // Return whether successful
        }

        // Adds weapon to nose location
        private bool AddNose(Weapon wep)
        {
            bool success = false;                                                           // Success boolean
            if (wep.Mass <= AeroFighter.FreeTons())                                         // Validate tonnage available
            {
                if (AeroFighter.NoseItems.Count < MaxNose)                                  // Validate item count
                {
                    AeroFighter.NoseItems.Add(wep);                                         // Add weapon to nose
                    success = true;                                                         // Set success to true
                }
                else
                {
                    Console.WriteLine("You are or past the item limit for this location."); // Item limit warning
                }
            }
            else
            {
                Console.WriteLine("Insufficient tonnage free to add item.");                // Insufficient tonnage message
                Console.WriteLine(wep.Mass + "free tons needed. " + 
                    AeroFighter.FreeTons() + " tons availalbe");
            }
            return success;                                                                 // Return success status
        }

        // Adds weapon to wing location
        private bool AddWing(Weapon wep)
        {
            bool success = false;                                                           // Success boolean
            if ((wep.Mass * 2) <= AeroFighter.FreeTons())                                   // Validate tonnage available
            {
                if (AeroFighter.WingItems.Count < MaxWing)                                  // Validate item count
                {
                    AeroFighter.WingItems.Add(wep);                                         // Add weapon to wings
                    success = true;                                                         // Set success to true
                }
                else
                {
                    Console.WriteLine("You are or past the item limit for this location."); // Item limit warning
                }
                
            }
            else
            {
                Console.WriteLine("Insufficient tonnage free to add item.");                // Insufficient tonnage message
                Console.WriteLine(wep.Mass + "free tons needed. " +
                    AeroFighter.FreeTons() + " tons availalbe");
            }
            return success;                                                                 // Return success status
        }

        // Adds weapon to aft location
        private bool AddAft(Weapon wep)
        {
            bool success = false;                                                           // Success boolean
            if (wep.Mass <= AeroFighter.FreeTons())                                         // Validate tonnage available
            {
                if (AeroFighter.AftItems.Count < MaxAft)                                    // Validate item count
                {
                    AeroFighter.AftItems.Add(wep);                                          // Add weapon to aft
                    success = true;                                                         // Set success to true
                }
                else
                {
                    Console.WriteLine("You are or past the item limit for this location."); // Item limit warning
                }
            }
            else
            {
                Console.WriteLine("Insufficient tonnage free to add item.");                // Insufficient tonnage message
                Console.WriteLine(wep.Mass + "free tons needed. " +
                    AeroFighter.FreeTons() + " tons availalbe");
            }
            return success;                                                                 // Return success status
        }

        // Removes a weapon from the fighter
        private void RemoveWeapon()
        {
            string[] options = new string[] { "1", "2", "3", "4" };                         // Valid inputs
            bool isValid = false;                                                           // Sentinel value for valid input
            string userInput = InputError;                                                  // Input string

            while (!isValid)                                                                // Until a valid input is entered...
            {
                DisplayWeapons();                                                           // Display current weapons
                Console.WriteLine("\nChoose the location you would like to remove " +       // Prompt user
                "the weapon from");
                LocMenu();                                                                  // Show menu options
                userInput = check.ParseInput(Console.ReadLine());                           // Read and parse user input
                isValid = check.Validate(userInput, options);                               // Validate input                
            }

            switch (userInput)                                                              // Switch to determine location
            {
                case "1":
                    RemoveNose();                                                           // Add weapon to fighter nose
                    break;
                case "2":
                    RemoveWing();                                                           // Add weapon to fighter wings
                    break;
                case "3":
                    RemoveAft();                                                            // Add weapon to fighter aft
                    break;
                case "4":
                    Console.WriteLine("No weapon removed.");                                // Cancel weapon add
                    break;
                default:
                    Console.WriteLine("Weapon allocation error");                           // Error message
                    break;
            }           
        }

        // Removes a weapon from the nose location
        private void RemoveNose()
        {
            bool isValid = false;                                                           // Sentinel value
            string userInput = InputError;                                                  // Input string

            while (!isValid)                                                                // While input is invalid
            {
                int userChoice;                                                             // Variable holds user input                
                Console.WriteLine("\nPlease enter the number for the weapon " +             // User Prompt
                    "you would like to remove and press the Enter key.");
                ShowNose();                                                                 // Display current nose weapons
                Console.Write("Selection: ");                                               // User Prompt
                userInput = check.ParseInput(Console.ReadLine());                           // Read and parse user input as string

                if (Int32.TryParse(userInput, out userChoice))                              // Parse input into an int
                {
                    if (userChoice > 0 && userChoice <= AeroFighter.NoseItems.Count)        // Validate int is within parameters
                    {
                        AeroFighter.NoseItems.RemoveAt(userChoice - 1);                     // Remove weapon at specified location  
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
            }
        }

        // Removes a weapon from the wing location
        private void RemoveWing()
        {
            bool isValid = false;                                                           // Sentinel value
            string userInput = InputError;                                                  // Input string

            while (!isValid)                                                                // While input is invalid
            {
                int userChoice;                                                             // Variable holds user input                
                Console.WriteLine("\nPlease enter the number for the weapon " +             // User Prompt
                    "you would like to remove and press the Enter key.");
                ShowWing();                                                                 // Display current wing weapons
                Console.Write("Selection: ");                                               // User Prompt
                userInput = check.ParseInput(Console.ReadLine());                           // Read and parse user input as string

                if (Int32.TryParse(userInput, out userChoice))                              // Parse input into an int
                {
                    if (userChoice > 0 && userChoice <= AeroFighter.WingItems.Count)        // Validate int is within parameters
                    {
                        AeroFighter.WingItems.RemoveAt(userChoice - 1);                     // Remove weapon at specified location  
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
            }
        }

        // Removes a weapon from the aft location
        private void RemoveAft()
        {
            bool isValid = false;                                                           // Sentinel value
            string userInput = InputError;                                                  // Input string

            while (!isValid)                                                                // While input is invalid
            {
                int userChoice;                                                             // Variable holds user input                
                Console.WriteLine("\nPlease enter the number for the weapon " +             // User Prompt
                    "you would like to remove and press the Enter key.");
                ShowAft();                                                                  // Display current aft weapons
                Console.Write("Selection: ");                                               // User Prompt
                userInput = check.ParseInput(Console.ReadLine());                           // Read and parse user input as string

                if (Int32.TryParse(userInput, out userChoice))                              // Parse input into an int
                {
                    if (userChoice > 0 && userChoice <= AeroFighter.AftItems.Count)         // Validate int is within parameters
                    {
                        AeroFighter.AftItems.RemoveAt(userChoice - 1);                      // Remove weapon at specified location  
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
            }
        }

        private void SetMaxWeapons()
        {
            switch (AeroFighter.Armor.Name)
            {
                case "Standard":
                    MaxNose = 5; MaxWing = 5; MaxAft = 5;                                   // Standard armor slots
                    break;
                case "Ferro-Aluminum":
                    MaxNose = 5; MaxWing = 4; MaxAft = 5;                                   // FA armor slots
                    break;
                case "Light Ferro-Aluminum":
                    MaxNose = 5; MaxWing = 5; MaxAft = 4;                                   // LFA armor slots
                    break;
                case "Heavy Ferro-Aluminum":
                    MaxNose = 4; MaxWing = 4; MaxAft = 4;                                   // HFA armor slots
                    break;
                case "Clan Ferro-Aluminum":                                                 
                    MaxNose = 5; MaxWing = 4; MaxAft = 5;                                   // FA (c) armor slots
                    break;
                default:
                    Console.WriteLine("There is an error in the armor type switch.");       // Error message
                    break;
            }
        }

        // Prompts user to choose type or weapon to add
        private void WeaponsMenu()
        {
            Console.WriteLine("\nChoose an option and then press the enter key");
            Console.WriteLine("1. Add energy weapons");
            Console.WriteLine("2. Add ballistic weapons");
            Console.WriteLine("3. Add missile weapons");
            Console.WriteLine("4. Remove a weapon");
            Console.WriteLine("5. Return to previous menu");
            Console.Write("Selection: ");
        }

        // Prints info on nose weapons
        private void ShowNose()
        {
            Console.WriteLine("\nNose:");
            int i = 1;                                                                      // Nose item counter
            foreach (Weapon wep in AeroFighter.NoseItems)                                   // Iterate through nose weapons
            {
                Console.WriteLine(i + ". " + wep.Name.PadRight(20) +                        // Print item details
                    (wep.Damage.ToString() + " damage").PadRight(14) +
                    (wep.Heat.ToString() + " heat").PadRight(12) +
                    (wep.Range + " range").PadRight(14) +
                    wep.Mass.ToString().PadRight(4) + "tons");
                i++;                                                                        // Increment counter
            }
        }

        // Prints info on wing weapons
        private void ShowWing()
        {
            Console.WriteLine("\nWing:");
            int j = 1;                                                                      // Wing item counter
            foreach (Weapon wep in AeroFighter.WingItems)                                   // Iterate through wing weapons
            {
                Console.WriteLine(j + ". " + wep.Name.PadRight(20) +                        // Print item details
                    (wep.Damage.ToString() + " *2 damage").PadRight(14) +
                    (wep.Heat.ToString() + " *2 heat").PadRight(12) +
                    (wep.Range + " range").PadRight(14) +
                    wep.Mass.ToString().PadRight(4) + "tons");
                j++;                                                                        // Increment counter
            }
        }

        // Prints info on aft weapons
        private void ShowAft()
        {
            Console.WriteLine("\nAft:");
            int k = 1;                                                                      // Aft item counter
            foreach (Weapon wep in AeroFighter.AftItems)                                    // Iterate through aft weapons
            {
                Console.WriteLine(k + ". " + wep.Name.PadRight(20) +                        // Print item details
                    (wep.Damage.ToString() + " damage").PadRight(14) +
                    (wep.Heat.ToString() + " heat").PadRight(12) +
                    (wep.Range + " range").PadRight(14) +
                    wep.Mass.ToString().PadRight(4) + "tons");
                k++;                                                                        // Increment counter
            }
        }

        // Prints info on all weapons on fighter
        public void DisplayWeapons()
        {
            Console.WriteLine("\nCurrent Weapons:");                                        // Heading
            Console.WriteLine("...............................................................................");
            ShowNose();                                                                     // Show nose weapons
            ShowWing();                                                                     // Show wing weapons
            ShowAft();                                                                      // Show aft weapons
            Console.WriteLine("...............................................................................\n");
        }

        public int TotalHeat()
        {
            int totalHeat = 0;                                                              // Total heat counter
            int i = 1;                                                                      // Nose item counter
            foreach (Weapon wep in AeroFighter.NoseItems)                                   // Iterate through nose weapons
            {
                totalHeat += wep.Heat;                                                      // Add weapon heat
                i++;                                                                        // Increment counter
            }

            int j = 1;                                                                      // Wing item counter
            foreach (Weapon wep in AeroFighter.WingItems)                                   // Iterate through wing weapons
            {
                totalHeat += wep.Heat * 2;                                                  // Add weapon heat
                j++;                                                                        // Increment counter
            }

            int k = 1;                                                                      // Aft item counter
            foreach (Weapon wep in AeroFighter.AftItems)                                    // Iterate through aft weapons
            {
                totalHeat += wep.Heat;                                                      // Add weapon heat
                k++;                                                                        // Increment counter
            }
            return totalHeat;                                                               // Return total heat
        }

        // Prints possible locations on fighter
        private void LocMenu()
        {            
            Console.WriteLine("1. Nose");
            Console.WriteLine("2. Wings (1 weapon added per wing)");
            Console.WriteLine("3. Aft");
            Console.WriteLine("4. Cancel");
            Console.Write("Selection: ");
        }

        // If weapon doesn't require ammo, return infinite sign instead of int
        private string checkInfinite(int ammo)
        {
            string count;
            if (ammo == 0)                                                                  // If ammo per ton is 0...
            {
                count = "--";                                                               // Set count to --
            }
            else                                                                            // Otherwise
            {
                count = ammo.ToString();                                                    // Set count to ToString
            }
            return count;                                                                   // Return count
        }
    }
}