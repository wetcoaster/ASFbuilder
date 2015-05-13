using System;
using System.Collections.Generic;
using System.Text;
using ASFbuilder.Equipment;
using ASFbuilder.Data;
using ASFbuilder.IO;
using ASFbuilder.Ships;

namespace ASFbuilder.Menus
{
    class EngineMenu
    {
        const int OFFSET = 2;                                                               // Index offset for engine list/sizes
        const int INCREMENT = 5;                                                            // Engine size increment
        const int MIN_THRUST = 1;                                                           // Minimum thrust allowed
        const int MIN_THRUST_OFFSET = 2;                                                    // Offset added to divided thrust 
        const decimal MAX_MULTIPLIER = 1.5m;                                                // Multiplier for calculating max thrust
        private Fighter AeroFighter { get; set; }                                           // Fighter being modified
        private List<Equipment.Engine> SFETypes { get; set; }                               // List of available SFE sizes
        private List<Equipment.Engine> XLFETypes { get; set; }                              // List of available XLFE sizes
        private List<Equipment.Engine> LFETypes { get; set; }                               // List of available LFE sizes
        private string InputError { get; set; }                                             // Default error string
        private bool IsLeave { get; set; }                                                  // Sentinel value for menu
        private ConsoleInput check;                                                         // Console Input checker object        

        // Constructors

        // Constructor takes fighter it will be acting on as a parameter
        public EngineMenu(Fighter newFighter)
        {
            check = new ConsoleInput();                                                     // Initialize error checker
            SFETypes = Data.Engine.populateSFE();                                           // Initialize list of available SFE
            XLFETypes = Data.Engine.populateXLFE();                                         // Initialize list of available XLFE
            LFETypes = Data.Engine.populateLFE();                                           // Initialize list of available LFE
            InputError = check.ErrMsg;                                                      // Set error message to checker message
            AeroFighter = newFighter;                                                       // Set fighter to passed parameter
            IsLeave = false;                                                                // Boolean for quitting
        }

        // Calls top level menu until sentinel value is flipped, then returns fighter
        public Fighter AddEngine()
        {
            while (!IsLeave)                                                                // Until user decides to quit
            {
                MainEngineMenu();                                                           // Call main menu
            }
            return AeroFighter;                                                             // Return modified fighter
        }

        private void MainEngineMenu()
        {
            string[] options = new string[] { "1", "2", "3" };                              // Valid inputs
            bool isValid = false;                                                           // Sentinel value for valid input            
            string userInput = InputError;                                                  // Input string

            while (!isValid)                                                                // Until a valid input is entered...
            {
                DisplayEngine();                                                            // Display current engine information
                PrintMainMenu();                                                            // Show menu options
                userInput = check.ParseInput(Console.ReadLine());                           // Read and parse user input
                isValid = check.Validate(userInput, options);                               // Validate input                
            }
            switch (userInput)
            {
                case "1":
                    ChangeEngineType();                                                     // Change heat sink type
                    break;
                case "2":
                    ChangeEngineSize();                                                     // Change heat sink quantity
                    break;
                case "3":
                    IsLeave = true;                                                         // Return to previous menu
                    break;
                default:
                    Console.WriteLine(InputError);                                          // Default case is an error
                    break;
            }
        }

        private void ChangeEngineType()
        {
            string[] options = new string[] { "1", "2", "3" };                              // Valid inputs
            bool isValid = false;                                                           // Sentinel value for valid input            
            string userInput = InputError;                                                  // Input string

            while (!isValid)                                                                // Until a valid input is entered...
            {
                DisplayEngine();                                                            // Display current engine information
                EngineTypes();                                                              // Show menu options
                userInput = check.ParseInput(Console.ReadLine());                           // Read and parse user input
                isValid = check.Validate(userInput, options);                               // Validate input                
            }
            switch (userInput)
            {
                case "1":
                    ChangeEngine("SFE");                                                    // Change to standard engine
                    break;
                case "2":
                    ChangeEngine("XL");                                                     // Change to XL engine
                    break;
                case "3":
                    ChangeEngine("LFE");                                                    // Change to light engine
                    break;
                default:
                    Console.WriteLine(InputError);                                          // Default case is an error
                    break;
            }
        }

        private void ChangeEngine(string type)
        {
            Equipment.Engine oldEng = AeroFighter.Engine;                                   // Assigns current engine to variable for convenience
            if (type.Equals(oldEng.EngineType))                                             // Checks to see if selected type differs from current
            {
                Console.WriteLine("Fighter already has a " + type + " engine.");            // Notifies user that selected engine is the same
            }
            else
            {
                int index = (oldEng.EngineSize / INCREMENT - OFFSET);                       // Calculates index of the current engine in the List
                switch (type)                                                               // Switch determines what engine type will be used
                {
                    case "SFE":
                        AeroFighter.Engine = SFETypes[index];                               // Change to standard engine
                        break;
                    case "XL":
                        AeroFighter.Engine = XLFETypes[index];                              // Change to XL engine
                        break;
                    case "LFE":
                        AeroFighter.Engine = LFETypes[index]; ;                             // Change to light engine
                        break;
                    default:
                        Console.WriteLine(InputError);                                      // Default case is an error
                        break;
                }
            }
        }
        private void ChangeEngineSize()
        {
            List<Equipment.Engine> legal = FindLegalEngines();                              // Generates list of all legal engines            
            string userInput = InputError;                                                  // Input string            
            bool isValid = false;                                                           // Sentinel value
            ShowAllEngines(legal);                                                          // Prints out all engines that are legal            

            while (!isValid)
            {
                int userChoice;                                                             // Holds user input
                userInput = check.ParseInput(Console.ReadLine());                           // Read and parse user input as string
                if (Int32.TryParse(userInput, out userChoice))                              // Parse input into an int
                {
                    if (userChoice > 0 && userChoice <= legal.Count)                        // Validate int is within parameters
                    {
                        AeroFighter.Engine = legal[userChoice - 1];                         // Assigns selected engine to fighter
                        AeroFighter.SafeThrust = SafeThrust(AeroFighter.Engine.EngineSize); // Updates safe thrust
                        AeroFighter.MaxThrust = MaxThrust(AeroFighter.Engine.EngineSize);   // Updates max thrust
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

        private List<Equipment.Engine> FindLegalEngines()
        {
            List<Equipment.Engine> legal = new List<Equipment.Engine>();                    // List of legal engines for fighter
            List<Equipment.Engine> engType = new List<Equipment.Engine>();                  // Initializes legal to blank list
            switch (AeroFighter.Engine.EngineType)                                          // Check current fighter engine type
            {
                case "SFE":
                    engType = SFETypes;                                                     // Set list to SFE
                    break;
                case "XL":
                    engType = XLFETypes;                                                    // Set list to XLFE
                    break;
                case "LFE":
                    engType = LFETypes;                                                     // Set list to LFE
                    break;
                default:
                    Console.WriteLine(InputError);                                          // Default case is an error
                    break;
            }

            foreach (Equipment.Engine eng in engType)                                       // Iterate through engine list
            {
                if (eng.EngineSize % AeroFighter.Mass == 0)                                 // Check if size is valid for current fighter
                {
                    if (eng.EngineSize / AeroFighter.Mass >= MIN_THRUST)                    // Check for minimum thrust
                    {
                        legal.Add(eng);                                                     // If so, add to legal engine list
                    }
                }
            }
            return legal;                                                                   // Return legal engines
        }

        // Calculates safe thrust from engine size
        private int SafeThrust(int size)
        {
            return (size / (int)AeroFighter.Mass + OFFSET);                                 // Calculate safe thrust
        }

        // Calculates max thrust from engine size
        private int MaxThrust(int size)
        {
            decimal safe = SafeThrust(size);                                                // Implicitly converts safe to decimal
            return ((int)Math.Ceiling(safe * MAX_MULTIPLIER));                              // Multiplies by multiplier, rounds up, then cast back to int            
        }

        // Shows all legal engine sizes for this aerospace fighter
        private void ShowAllEngines(List<Equipment.Engine> legal)
        {
            Console.WriteLine("\nPlease enter the number for the engine that " +            // User Prompt
                   "you would like to select and press the Enter key.\n");
            Console.WriteLine("Engine name".PadRight(20) + "Mass".PadRight(14) +            // Print headings
                "Safe Thrust".PadRight(13) + "Max Thrust");
            int i = 0;                                                                      // Engine counter
            foreach (Equipment.Engine eng in legal)                                         // Iterate through legal engine list
            {
                Console.WriteLine(((i + 1) + ".").PadRight(4) + eng.Name.PadRight(16) +     // Print details for each engine 
                    (eng.Mass.ToString("N2").PadRight(6) + "tons").PadRight(14) +
                    SafeThrust(eng.EngineSize).ToString().PadRight(13) +
                    MaxThrust(eng.EngineSize).ToString());
                i++;                                                                        // Increment counter
            }
            Console.Write("\nSelection: ");
        }

        // Displays current engine information
        private void DisplayEngine()
        {
            Console.WriteLine("\nCurrent Engine:");
            Console.WriteLine(AeroFighter.Engine.Name.PadRight(18) + 
                (AeroFighter.Engine.Mass.ToString("N2").PadRight(6) + "tons").PadRight(11) + 
                AeroFighter.Engine.Cost.ToString("N2") + " C-bills");
        }

        // Displays menu of available engine types
        private void EngineTypes()
        {
            Console.WriteLine("\n1. Standard Fusion Engine");
            Console.WriteLine("2. Extralight Fusion Engine");
            Console.WriteLine("3. Light Fusion Engine");
        }

        // Prints main engine menu options
        private void PrintMainMenu()
        {
            Console.WriteLine("\n1. Change engine type");
            Console.WriteLine("2. Change engine size");
            Console.WriteLine("3. Return to previous menu");
            Console.Write("Selection: ");
        }
    }
}