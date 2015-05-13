using System;
using ASFbuilder.Ships;
using ASFbuilder.IO;

namespace ASFbuilder.Menus
{
    class NameMenu
    {
        const int MAX_NAME_LENGTH = 26;                                                     // Maximum name length
        const int MAX_DESIG_LENGTH = 10;                                                    // Maximum designation length
        private Fighter AeroFighter { get; set; }                                           // Fighter being modified
        private string InputError { get; set; }                                             // Default error string
        private bool IsLeave { get; set; }                                                  // Sentinel value for menu
        private ConsoleInput check;                                                         // Error checker

        // Constructor
        public NameMenu(Fighter newFighter)
        {
            check = new ConsoleInput();                                                     // Initialize error checker
            InputError = check.ErrMsg;                                                      // Set error message to checker message
            AeroFighter = newFighter;                                                       // Set fighter to passed parameter
            IsLeave = false;                                                                // Boolean for quitting
        }

        // Methods
        // Calls top level menu until sentinel value is flipped, then returns fighter
        public Fighter ChangeName()
        {
            while (!IsLeave)                                                                // Until user decides to quit
            {
                NameMainMenu();                                                             // Call main menu
            }
            return AeroFighter;                                                             // Return modfied fighter when done
        }

        // Main name menu
        private void NameMainMenu()
        {            
            string[] options = new string[] { "1", "2", "3" };                              // Valid inputs
            bool isValid = false;                                                           // Sentinel value for valid input            
            string userInput = InputError;                                                  // Input string

            while (!isValid)                                                                // Until a valid input is entered...
            {
                DisplayName();                                                              // Display current name and designation
                PrintMenu();                                                                // Print main menu
                userInput = check.ParseInput(Console.ReadLine());                           // Read and parse user input
                isValid = check.Validate(userInput, options);                               // Validate input                
            }
            switch (userInput)
            {
                case "1":
                    ChangeASFName();                                                        // Change name
                    break;
                case "2":
                    ChangeASFDesig();                                                       // Change deisgnation
                    break;
                case "3":
                    IsLeave = true;                                                         // Return to previous menu
                    break;
                default:
                    Console.WriteLine(InputError);                                          // Default case is an error
                    break;
            }
        }

        // Changes name
        private void ChangeASFName()
        {
            bool isValid = false;                                                           // Sentinel value for valid input
            string userInput = InputError;                                                  // Input string
            while (!isValid)
            {
                Console.WriteLine("\nEnter your new name here: ");                          // User prompt
                userInput = Console.ReadLine().Trim();                                      // Read and parse user input
                if (userInput != null && userInput.Length < MAX_NAME_LENGTH)                // Check input is not null or too long
                {
                    AeroFighter.Name = userInput;                                           // Assign new name
                    isValid = true;                                                         // Flip success sentinel
                }
            }
        }

        // Changes designation
        private void ChangeASFDesig()
        {
            bool isValid = false;                                                           // Sentinel value for valid input
            string userInput = InputError;                                                  // Input string
            while (!isValid)
            {
                Console.WriteLine("\nEnter your new designation here: ");                   // User prompt
                userInput = Console.ReadLine().Trim();                                      // Read and parse user input
                if (userInput != null && userInput.Length < MAX_DESIG_LENGTH)               // Check input is not null or too long
                {
                    AeroFighter.Designation = userInput;                                    // Assign new designation
                    isValid = true;                                                         // Flip success sentinel
                }
            }
        }

        // Displays current name and designation
        private void DisplayName()
        {
            Console.WriteLine("\nCurrent Name: " + AeroFighter.Name);                       // Print name
            Console.WriteLine("Current Designation: " + AeroFighter.Designation);           // Print designation
        }

        // Prints main menu
        private void PrintMenu()
        {
            Console.WriteLine("\n1. Change fighter name");
            Console.WriteLine("2. Change fighter designation");
            Console.WriteLine("3. Return to previous menu");
            Console.Write("Selection: ");
        }
    }
}
