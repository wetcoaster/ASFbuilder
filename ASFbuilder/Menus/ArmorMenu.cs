using System;
using System.Collections.Generic;
using System.Text;
using ASFbuilder.Equipment;
using ASFbuilder.Data;
using ASFbuilder.IO;
using ASFbuilder.Ships;

namespace ASFbuilder.Menus
{
    class ArmorMenu
    {
        //Constant, property and variable declarations
        const decimal MIN_ARMOR_INCREMENT = 0.5m;                                           // Minimum armor mass increment
        private Fighter AeroFighter { get; set; }                                           // Fighter being modified
        private List<Equipment.Armor> ArmorType { get; set; }                               // List of available armor types
        private string InputError { get; set; }                                             // Default error string
        private bool IsLeave { get; set; }                                                  // Sentinel value for menu
        private ConsoleInput check;                                                         // Console Input checker object        

        // Constructors

        // Constructor takes fighter it will be acting on as a parameter
        public ArmorMenu(Fighter newFighter)
        {
            check = new ConsoleInput();                                                     // Initialize error checker
            ArmorType = Data.Armor.populateArmor();                                         // Initialize list of available armor
            InputError = check.ErrMsg;                                                      // Set error message to checker message
            AeroFighter = newFighter;                                                       // Set fighter to passed parameter
            IsLeave = false;                                                                // Boolean for quitting
        }

        // Methods

        // Calls top level menu until sentinel value is flipped, then returns fighter
        public Fighter ChangeArmor()
        {
            while (!IsLeave)                                                                // Until user decides to quit
            {
                ArmorMainMenu();                                                            // Call main menu
            }
            return AeroFighter;                                                             // Return modfied fighter when done
        }

        // Top level menu
        public void ArmorMainMenu()
        {
            string[] options = new string[] { "1", "2", "3", "4" };                         // Valid inputs
            bool isValid = false;                                                           // Sentinel value for valid input            
            string userInput = InputError;                                                  // Input string
                                                              
            while (!isValid)                                                                // Until a valid input is entered...
            {
                DisplayArmor();                                                             // Display current armour information
                ModMenu();                                                                  // Show menu options
                userInput = check.ParseInput(Console.ReadLine());                           // Read and parse user input
                isValid = check.Validate(userInput, options);                               // Validate input                
            }
            switch (userInput)
            {
                case "1":
                    ChangeArmorType();                                                      // Change armor type
                    break;
                case "2":
                    ChangeArmorQty();                                                       // Change armor quantity
                    break;
                case "3":
                    ReallocateArmor();                                                      // Reallocate existing armor
                    break;
                case "4":
                    IsLeave = true;                                                         // Return to previous menu
                    break;
                default:
                    Console.WriteLine(InputError);                                          // Default case is an error
                    break;
            }           
        }

        // Reallocates existing armor
        private void ReallocateArmor()
        {
            int armorPts = 0;                                                               // Total armor points

            armorPts += AeroFighter.NoseArmor;                                              // Add nose armor
            armorPts += AeroFighter.WingArmor * 2;                                          // Add wing armor
            armorPts += AeroFighter.AftArmor;                                               // Add aft armor

            AeroFighter.NoseArmor = 0;                                                      // Set nose armor to 0
            AeroFighter.WingArmor = 0;                                                      // Set wing armor to 0
            AeroFighter.AftArmor = 0;                                                       // Set tail armor to 0

            AllocateArmor(armorPts);                                                        // Call allocation method with total armor
        }

        // Changes armor type
        private void ChangeArmorType()
        {
            bool isValid = false;                                                           // Sentinel value
            string userInput = InputError;                                                  // Input string

            while (!isValid)                                                                // While input is invalid
            {
                int userChoice;                                                             // Variable holds user input
                DisplayArmor();                                                             // Display current armour information
                Console.WriteLine("Please enter the number for the type of armor " +        // User Prompt
                    "you would like to select and press the Enter key.");
                Console.WriteLine("\n".PadRight(4) + "Name".PadRight(22) +                  // Display headers
                    "Points per ton".PadRight(16) + "Cost per ton");
                for (int i = 0; i < ArmorType.Count; i++)                                   // Iterate through list of available armor types
                {                                                                           // Print detail for each armor type
                    Console.WriteLine(((i + 1) + ". ").PadRight(3) + 
                        ArmorType[i].Name.PadRight(22) +
                        (ArmorType[i].PointsPerTonne*ArmorType[i].Multiplier + "/ton").PadRight(16) + 
                        (ArmorType[i].Cost).ToString().PadRight(6) + " C-bills/ton");
                }
                userInput = check.ParseInput(Console.ReadLine());                           // Read and parse user input as string
                if (Int32.TryParse(userInput, out userChoice))                              // Parse input into an int
                {
                    if (userChoice > 0 && userChoice <= ArmorType.Count)                    // Validate int is within parameters
                    {
                        if (!ArmorType[userChoice -1].Equals(AeroFighter.Armor))            // If choice is not the same as current armor (index offset)
                        {
                            AeroFighter.Armor = ArmorType[userChoice -1];                   // Set new armor type (index offset)
                            int newPoints = (int)Math.Round(AeroFighter.ArmorMass *         // Calculate new amount of armor points
                                AeroFighter.Armor.PointsPerTonne * 
                                AeroFighter.Armor.Multiplier);                            
                            AllocateArmor(newPoints);                                       // Allocate new armor total
                        }
                        isValid = true;                                                     // Toggle sentinel value if executed correctly
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

        // Changes armor tonnage
        private void ChangeArmorQty()
        {
            bool isValid = false;                                                           // Sentinel value
            string userInput = InputError;                                                  // Input string
            decimal newMass = 0;                                                            // New mass
            int newPoints = 0;                                                              // New amount of armor points
            DisplayArmor();                                                                 // Display current armour information
            AeroFighter.NoseArmor = 0;                                                      // Set armor to 0
            AeroFighter.WingArmor = 0;                                                      // Set armor to 0
            AeroFighter.AftArmor = 0;                                                       // Set armor to 0

            while (!isValid)                                                                // Until a valid input is entered...
            {
                // Prompt user to choose tonnage of armor
                Console.WriteLine("Please enter the tonnage of armor and press the " +      // Display prompt
                    "Enter key. Armor must be allocated in half ton increments.");
                userInput = check.ParseInput(Console.ReadLine());                           // Read and parse user input
                isValid = decimal.TryParse(userInput, out newMass);                         // Validate input is a decimal
                if (newMass % MIN_ARMOR_INCREMENT != 0)                                     // Validate mass is in proper increment
                {
                    Console.WriteLine("\nArmor mass must be a half or full ton\n");         // Invalid increment error message            
                    isValid = false;                                                        // Switch sentinel back to false
                }
            }

            AeroFighter.ArmorMass = newMass;                                                // Updates fighter's armor mass
            newPoints = (int)Math.Round(newMass * AeroFighter.Armor.PointsPerTonne *        // Convert new mass into armor points
                 AeroFighter.Armor.Multiplier);         

            Console.WriteLine("\nFighter armor changed to " + userInput +                   // Notify user of changes
                " tons of " + AeroFighter.Armor + " armor\n");
            Console.WriteLine(newPoints + " armor points to distribute.");                  // Notify new armor point total

            AllocateArmor(newPoints);                                                       // Allocate new armor total
        }

        // Method allocates armor
        private void AllocateArmor(int newPoints)                                           
        {
            string[] options = new string[] { "1", "2", "3" };                              // List of valid options for validation
            int ptsRemaining = newPoints;                                                   // New armour points for this location
            bool isValid = false;                                                           // Sentinel value
            string userSelection = InputError;                                              // Input string

            while (!isValid && ptsRemaining != 0)                                           // While unallocated points remain or input invalid
            {
                AllocationMenu(ptsRemaining);                                               // Call allocation menu with remaining points
                userSelection = check.ParseInput(Console.ReadLine());                       // Read and parse user input
                isValid = check.Validate(userSelection, options);                           // Validate input

                switch (userSelection)                                                      // Switch follows user input
                {
                    case "1":
                        ChangeNoseArmor(ref ptsRemaining);                                  // Change nose armor
                        break;
                    case "2":
                        ChangeWingArmor(ref ptsRemaining);                                  // Change wing armor
                        break;
                    case "3":
                        ChangeAftArmor(ref ptsRemaining);                                   // Change aft armor
                        break;
                    default:
                        Console.WriteLine(InputError);                                      // Default case is an error
                        break;
                }
            }
        }

        // Method allocates armor to nose location
        private void ChangeNoseArmor(ref int ptsRemaining)
        {
            int ptsAllocated = 0;                                                           // Allocated points tracker
            bool isValid = false;                                                           // Sentinel value
            while (!isValid)
            {
                Console.WriteLine("Allocating armor to nose location");                     // Display location message
                ArmorPrompt(ptsRemaining);                                                  // Display instruction prompt
                string userInput = Console.ReadLine();                                      // Read user input
                isValid = Int32.TryParse(userInput, out ptsAllocated);                      // Validate input type
                if (ptsAllocated > ptsRemaining)                                            // Validate input is <= max
                {
                    isValid = false;                                                        // Take input again
                    Console.WriteLine("You have tried to allocate more armor than is" +     // Overallocation error error message
                        "available! Try again.");
                }
                if (ptsAllocated < 0)                                                       // Validate input is > 0
                {
                    isValid = false;
                    Console.WriteLine("You have tried to allocate a negative quantity!");   // Negative allocation error message
                }
            }
            AeroFighter.NoseArmor += ptsAllocated;                                          // Add allocated points to total
            ptsRemaining = ptsRemaining - ptsAllocated;                                     // Subtract allocated points from pool
            if (ptsRemaining == 0)                                                          // If all armor is allocated
            {
                Console.WriteLine("All armor allocated!");                                  // Display completion message
            }
            else                                                                            // If unallocated armor remains
            {
                AllocateArmor(ptsRemaining);                                                // Call allocation method with remainder
            }
        }

        // Method allocates armor to wing locations
        private void ChangeWingArmor(ref int ptsRemaining)
        {
            int ptsAllocated = 0;                                                           // Allocated points tracker
            bool isValid = false;                                                           // Sentinel value
            while (!isValid)
            {
                Console.WriteLine("Allocating armor to wing location");                     // Display location message
                ArmorPrompt(ptsRemaining);                                                  // Display instruction prompt
                string userInput = Console.ReadLine();                                      // Read user input
                isValid = Int32.TryParse(userInput, out ptsAllocated);                      // Validate input type
                if ((ptsAllocated * 2) > ptsRemaining || ptsAllocated < 0)                  // Validate input value
                {
                    isValid = false;                                                        // Take input again
                }
            }
            AeroFighter.WingArmor += ptsAllocated;                                          // Add allocated points to total
            ptsRemaining -= (ptsAllocated * 2);                                             // Subtract allocated points from pool
            if (ptsRemaining == 0)                                                          // If all armor is allocated
            {
                Console.WriteLine("All armor allocated!");                                  // Display completion message
            }
            else                                                                            // If unallocated armor remains
            {
                AllocateArmor(ptsRemaining);                                                // Call allocation method with remainder
            }
        }

        // Method allocates armor to aft location
        private void ChangeAftArmor(ref int ptsRemaining)
        {
            int ptsAllocated = 0;                                                           // Allocated points tracker
            bool isValid = false;                                                           // Sentinel value
            while (!isValid)
            {
                Console.WriteLine("Allocating armor to Aft location");                      // Display location message
                ArmorPrompt(ptsRemaining);                                                  // Display instruction prompt
                string userInput = Console.ReadLine();                                      // Read user input
                isValid = Int32.TryParse(userInput, out ptsAllocated);                      // Validate input type
                if (ptsAllocated > ptsRemaining || ptsAllocated < 0)                        // Validate input value
                {
                    isValid = false;                                                        // Take input again
                }
            }
            AeroFighter.AftArmor += ptsAllocated;                                           // Add allocated points to total
            ptsRemaining -= ptsAllocated;                                                   // Subtract allocated points from pool
            if (ptsRemaining == 0)                                                          // If all armor is allocated
            {
                Console.WriteLine("All armor allocated!");                                  // Display completion message
            }
            else                                                                            // If unallocated armor remains
            {
                AllocateArmor(ptsRemaining);                                                // Call allocation method with remainder
            }
        }

        // Prints armor modification menu
        private void ModMenu()
        {
            Console.WriteLine("Please select the action that you wish to perform");
            Console.WriteLine("1. Change the type of armor");
            Console.WriteLine("2. Change the quantity of armor");
            Console.WriteLine("3. Reallocate the current armor");
            Console.WriteLine("4. Return to previous menu");
            Console.Write("Selection: ");
        }

        // Prints armor allocation menu
        private void AllocationMenu(int ptsRemaining)
        {
            Console.WriteLine("\nYou have " + ptsRemaining +
                " points of armour left to allocate");
            Console.WriteLine("Pick a location to allocate to: (Each point " +
                "allocated to the wings takes 2 pts from the total - one for each wing)");
            Console.WriteLine("1. Allocate armour to fighter's nose");
            Console.WriteLine("2. Allocate armour to fighter's wings");
            Console.WriteLine("3. Allocate armour to fighter's aft");
            Console.Write("Selection: ");
        }

        // Prompts user to enter amount of armor to allocate to location
        private void ArmorPrompt(int ptsremaining)
        {
            Console.WriteLine("\nYou have " + ptsremaining + " points or armor left unallocated");
            Console.WriteLine("Enter the number of points you would like to allocate and press Enter");
        }

        // Displays current armor specifications
        private void DisplayArmor()
        {
            Console.WriteLine();
            Console.WriteLine("Current armor type: ".PadRight(21) + AeroFighter.Armor.Name);
            Console.WriteLine("Nose armor: ".PadRight(21) + AeroFighter.NoseArmor + " points");
            Console.WriteLine("Right wing armor: ".PadRight(21) + AeroFighter.WingArmor + " points");
            Console.WriteLine("Left wing armor: ".PadRight(21) + AeroFighter.WingArmor + " points");
            Console.WriteLine("Aft armor: ".PadRight(21) + AeroFighter.AftArmor + " points\n");
        }
    }
}