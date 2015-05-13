using System;
using System.Collections.Generic;
using System.Text;
using ASFbuilder.Equipment;
using ASFbuilder.Data;
using ASFbuilder.IO;
using ASFbuilder.Ships;

namespace ASFbuilder.Menus
{
    class MainMenu
    {
        // Constants
        const int MAX_WEIGHT = 100;                                                         // Maximum ASF weight
        const int MIN_WEIGHT = 20;                                                          // Minimum ASF weight        

        // Instance variables
        private List<Weapon> Beams { get; set; }                                            // List of available energy weapons
        private List<Weapon> Guns { get; set; }                                             // List of available ballistics
        private List<Weapon> Missiles { get; set; }                                         // List of available missiles
        private List<Equipment.Armor> ArmorType { get; set; }                               // List of available armor types
        private Zubok Colonel { get; set; }                                                 // Pearls of Niopsian wisdom     
        private string InputError { get; set; }                                             // Default error string
        private Fighter AeroFighter { get; set; }                                           // Active fighter
        private bool isQuit;                                                                // Sentinel variable
        private ConsoleInput check;                                                         // Console Input checker object        

        // Constructors
        public MainMenu()                                                                   // Default constructor
        {
            check = new ConsoleInput();                                                     // Initialize Input checker
            isQuit = false;                                                                 // Initialize sentinel variable
            Beams = Data.Energy.populateBeams();                                            // Initialize list of available energy weapons
            Guns = Data.Ballistic.populateGuns();                                           // Initialize list of available ballistics
            Missiles = Data.Missile.populateMissiles();                                     // Initialize list of available missiles
            ArmorType = Data.Armor.populateArmor();                                         // Initialize list of available armor
            Colonel = new Zubok();                                                          // Initialize new Zubok            
            InputError = check.ErrMsg;                                                      // Initialize error message from checker
            AeroFighter = new Fighter();                                                    // Initialize new fighter
            AeroFighter.Armor = ArmorType[0];                                               // Defaults armor type to standard
            AeroFighter.Mass = MAX_WEIGHT;                                                  // Defaults mass to max weight
        }

        // Start Program
        public void StartBuilder()                                                          // Start menu
        {
            PrintProgStart();                                                               // Prints intro
            while (!isQuit)                                                                 // While sentinel is unchecked...
            {
                GetMainOption();                                                            // Call main menu method
            }
            Console.WriteLine("\nThank you for using chanman's ASF creator!");              // Farewell message
            Console.ReadLine();                                                             // Hold console open
        }

        // Main menu method
        public void GetMainOption()
        {
            //List of valid options for validation
            string[] options = new string[] { "1", "2", "3", "4", "5", "6", "7" };          // Acceptable input range
            bool isValid = false;                                                           // Sentinel value
            string userSelection = InputError;                                              // Input string

            while (!isValid)                                                                // Until a valid input is entered...
            {
                PrintMainMenu();                                                            // Prints main menu
                userSelection = check.ParseInput(Console.ReadLine());                       // Read and parse user input
                isValid = check.Validate(userSelection, options);                           // Validate input
            }

            // Switch follows user input
            switch (userSelection)
            {
                case "1":
                    AeroFighter = new Fighter();                                            // Initialize new fighter
                    BuildMenu();                                                            // Start building a new fighter
                    break;
                case "2":
                    SaveToText();                                                           // Print to txt file
                    break;
                case "3":                                                                   
                    BuildMenu();                                                            // Continue building current fighter
                    break;
                case "4":
                    SaveFighter();                                                          // Save fighter to file
                    break;
                case "5":
                    LoadFighter();                                                          // Load fighter from file
                    break;
                case "6":
                    Colonel.GetWisdom();                                                    // Calls Colonel method to dispense wisdom
                    break;
                case "7":
                    isQuit = true;                                                          // Exit program
                    break;
                default:
                    Console.WriteLine(InputError);                                          // Default case is an error
                    break;
            }
        }

        // Load a fighter
        private void LoadFighter()
        {
            FileReader reader = new FileReader(AeroFighter);                                // Creates new file reader
            AeroFighter = reader.LoadFile();                                                // Loads file
            BuildMenu();                                                                    // Goes to build menu
        }

        // Save current fighter
        private void SaveFighter()
        {
            FileWriter writer = new FileWriter(AeroFighter);                                // Creates new file writer
            writer.WriteFighter();                                                          // Saves fighter to file
        }

        // Checks to see if user wants to leave build menu, creates a new fighter
        private void BuildMenu()
        {
            bool stop = false;                                                              // Sentinel value of leaving build menu
            while (!stop)
            {                
                stop = FighterMenu();                                                       // Call build menu
            }
        }

        private bool FighterMenu()
        {
            //List of valid options for validation
            string[] options = new string[] { "1", "2", "3", "4", "5", "6", "7", "8", "9", "0" };
            bool isValid = false;                                                           // Input Sentinel value
            bool leaveMenu = false;                                                         // Menu Sentinel value
            string userSelection = InputError;                                              // Input string

            while (!isValid)                                                                // Until a valid input is entered...
            {
                PrintBuildMenu();                                                           // Prints main menu
                userSelection = check.ParseInput(Console.ReadLine());                       // Read and parse user input
                isValid = check.Validate(userSelection, options);                           // Validate input
            }

            // Switch follows user input
            switch (userSelection)
            {
                case "1":
                    ChangeName();                                                           // Change fighter name
                    break;
                case "2":
                    ChangeMass();                                                           // Change fighter mass
                    break;
                case "3":
                    ChangeEngine();                                                         // Change fighter engine
                    break;
                case "4":
                    ChangeArmor();                                                          // Change fighter armor
                    break;
                case "5":
                    ChangeWeapons();                                                        // Change fighter weapons
                    break;
                case "6":
                    ChangeFuel();                                                           // Change fighter fuel
                    break;
                case "7":
                    ChangeSinks();                                                          // Change fighter heat sinks
                    break;
                case "8":
                    ChangeAmmo();                                                           // Change fighter ammunition
                    break;
                case "9":
                    ShowFighter();                                                          // Display fighter
                    break;  
                case "0":
                    Console.WriteLine("\nReturning to Main menu");                          // Return to main menu
                    leaveMenu = true;
                    break;
                default:
                    Console.WriteLine(InputError);                                          // Default case is an error
                    break;
            }
            return leaveMenu;                                                               // Return quit boolean
        }

        // Change fighter name and designation
        private void ChangeName()
        {
            NameMenu namer = new NameMenu(AeroFighter);                                     // Create new instance of name menu
            AeroFighter = namer.ChangeName();                                               // Call name change method
        }

        // Change fighter armor
        private void ChangeArmor()
        {
            ArmorMenu armorMenu = new ArmorMenu(AeroFighter);                               // Create new instance of armor menu
            AeroFighter = armorMenu.ChangeArmor();                                          // Call armor menu method
        }

        // Change fighter weapons
        private void ChangeWeapons()
        {
            WeaponMenu wepMenu = new WeaponMenu(AeroFighter);                               // Create new instance of weapon menu
            AeroFighter = wepMenu.ChangeWeapons();                                          // Call weapon menu method
        }

        // Change fighter mass
        private void ChangeMass()
        {
            string[] options = new string[] { "20", "25", "30", "35",                       // Valid weights
                "40", "45", "50", "55", "60", "65", "70", "75", "80", 
                "85", "90", "95", "100" };
            bool isValid = false;                                                           // Sentinel value
            string userInput = InputError;                                                  // Input string

            while (!isValid)                                                                // Until a valid input is entered...
            {
                Console.WriteLine("\nFighter mass must be between 20 and 100 tons " +
                    "inclusive and be a multiple of 5.");
                Console.WriteLine("Please enter new mass for this fighter and press " + 
                    "the Enter key.");
                userInput = check.ParseInput(Console.ReadLine());                           // Read and parse user input
                isValid = check.Validate(userInput, options);                               // Validate input
            }
            AeroFighter.Mass = Int32.Parse(userInput);                                      // Set mass to new parsed input
            Console.WriteLine("Fighter mass changed to " + userInput + " tons.\n");         // Notify user of change
        }

        // Change fighter fuel
        private void ChangeFuel()
        {
            bool isValid = false;                                                           // Sentinel value
            string userInput = InputError;                                                  // Input string
            int newMass = 0;                                                                // New mass

            while (!isValid)                                                                // Until a valid input is entered...
            {                
                Console.WriteLine("\nCurrent fuel tonnage: " + AeroFighter.Fuel);           // Display current amount of fuel
                Console.WriteLine("Please enter the new amount of fuel and press the "      // Prompt user to enter new fuel tonnage
                    + "Enter key.");
                userInput = check.ParseInput(Console.ReadLine());                           // Read and parse user input
                isValid = Int32.TryParse(userInput, out newMass);                           // Validate input
            }
            AeroFighter.Fuel = newMass;                                                     // Set fuel to equal new amount
            Console.WriteLine("Fighter fuel capcity changed to " + userInput + " tons.");   // Display new fuel amount
        }

        // Change engine
        private void ChangeEngine()
        {
            EngineMenu engMenu = new EngineMenu(AeroFighter);                               // Create new instance of weapon menu
            AeroFighter = engMenu.AddEngine();                                              // Call weapon menu method
        }

        // Change heatsinks
        private void ChangeSinks()
        {
            SinksMenu sinkMenu = new SinksMenu(AeroFighter);                                // Create new instance of weapon menu
            AeroFighter = sinkMenu.ChangeSinks();                                           // Call heat sink menu method
        }

        // Change ammunition
        private void ChangeAmmo()
        {
            AmmoMenu ammoMenu = new AmmoMenu(AeroFighter);                                  // Create new instance of ammo menu
            AeroFighter = ammoMenu.ChangeAmmo();                                            // Call ammo menu method
        }

        // Displays fighter stats on console
        private void ShowFighter()
        {
            ConsoleOutput output = new ConsoleOutput(AeroFighter);                          // Create new instance of console output
            output.PrintFighter();                                                          // Print technical readout
        }

        // Saves fighter to text file of user specified name
        private void SaveToText()
        {
            TextWriter writer = new TextWriter(AeroFighter);                                // Create new instance of text writer
            writer.WriteFighter();                                                          // Printe technical readout
        }

        // Prints program start
        private void PrintProgStart()
        {
            Console.WriteLine("\n================================");
            Console.WriteLine("ASF builder v1.10a");
            Console.WriteLine("================================");
            Console.WriteLine("Welcome to chanman's ASF builder!\nThis program " +
                "will allow you to build introductory tech aerospace fighters " + 
                "for the Battletech universe.");
        }

        // Prints main menu
        private void PrintMainMenu()
        {
            Console.WriteLine("\nPlease pick from one of the following options by typing the " +
                "number and pressing the 'Enter' key.\n");
            Console.WriteLine("1. Create New Fighter (Current fighter will be lost)");
            Console.WriteLine("2. Save fighter to text file");
            Console.WriteLine("3. Continue working on current fighter");
            Console.WriteLine("4. Save current fighter (file name will use fighter's name)");
            Console.WriteLine("5. Load existing fighter");
            Console.WriteLine("6. Request a nugget of wisdom from Niopsian Colonel Zubok");
            Console.WriteLine("7. Quit");
            Console.Write("Selection: ");
        }

        // Prints construction menu
        private void PrintBuildMenu()
        {
            Console.WriteLine("\nPlease pick from one of the following options by typing the " +
                "number and pressing the 'Enter' key.\n");
            Console.WriteLine("1. Change fighter name");
            Console.WriteLine("2. Change fighter mass");
            Console.WriteLine("3. Change fighter engine");
            Console.WriteLine("4. Change fighter armor");
            Console.WriteLine("5. Change fighter weapons");
            Console.WriteLine("6. Change fighter fuel");
            Console.WriteLine("7. Change fighter heat sinks");
            Console.WriteLine("8. Change fighter ammunition");
            Console.WriteLine("9. View fighter details");
            Console.WriteLine("0. Return to previous menu");
            Console.Write("Selection: ");
        }
    }   
}