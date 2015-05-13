using System;
using System.Collections.Generic;
using System.Text;
using ASFbuilder.Equipment;
using ASFbuilder.Data;
using ASFbuilder.IO;
using ASFbuilder.Ships;

namespace ASFbuilder.Menus
{
    class SinksMenu
    {
        private Fighter AeroFighter { get; set; }                                           // Fighter being modified
        private List<Equipment.HeatSinks> SinkTypes { get; set; }                           // List of available heat sink types
        private string InputError { get; set; }                                             // Default error string
        private bool IsLeave { get; set; }                                                  // Sentinel value for menu
        private ConsoleInput check;                                                         // Console Input checker object        

        // Constructors

        // Constructor takes fighter it will be acting on as a parameter
        public SinksMenu(Fighter newFighter)
        {
            check = new ConsoleInput();                                                     // Initialize error checker
            SinkTypes = Data.HeatSinks.populateSinks();                                     // Initialize list of available heat sinks
            InputError = check.ErrMsg;                                                      // Set error message to checker message
            AeroFighter = newFighter;                                                       // Set fighter to passed parameter
            IsLeave = false;
        }

        // Methods

        // Calls top level menu until sentinel value is flipped, then returns fighter
        public Fighter ChangeSinks()
        {
            while (!IsLeave)                                                                // Until user decides to quit
            {
                SinksMainMenu();                                                            // Call main menu
            }
            return AeroFighter;                                                             // Return modfied fighter when done
        }

        // Main heat sink menu
        private void SinksMainMenu()
        {
            string[] options = new string[] { "1", "2", "3" };                              // Valid inputs
            bool isValid = false;                                                           // Sentinel value for valid input            
            string userInput = InputError;                                                  // Input string

            while (!isValid)                                                                // Until a valid input is entered...
            {
                DisplaySinks();                                                             // Display current heat sink information
                SinkMenu();                                                                 // Show menu options
                userInput = check.ParseInput(Console.ReadLine());                           // Read and parse user input
                isValid = check.Validate(userInput, options);                               // Validate input                
            }
            switch (userInput)
            {
                case "1":
                    ChangeSinkType();                                                       // Change heat sink type
                    break;
                case "2":
                    ChangeSinkQty();                                                        // Change heat sink quantity
                    break;
                case "3":
                    IsLeave = true;                                                         // Return to previous menu
                    break;
                default:
                    Console.WriteLine(InputError);                                          // Default case is an error
                    break;
            }
        }

        // Changes number of heatsinks
        private void ChangeSinkQty()
        {
            bool isValid = false;                                                           // Sentinel value
            string userInput = InputError;                                                  // Input string
            int newSinks = 0;                                                               // New number of heat sinks

            while (!isValid)                                                                // Until a valid input is entered...
            {
                Console.WriteLine("\nCurrent heat sinks: " + AeroFighter.TotalSinks());     // Display current number of sinks                
                Console.WriteLine("Please enter the new number of external heat sinks " +   // Prompt user to enter new number of heat sinks
                    "and press the Enter key.");
                userInput = check.ParseInput(Console.ReadLine());                           // Read and parse user input
                isValid = Int32.TryParse(userInput, out newSinks);                          // Validate input
            }
            AeroFighter.ExtSinks = newSinks;                                                // Set sinks to new amount
            Console.WriteLine("\nFighter now has " + AeroFighter.TotalSinks() + " "         // Display new total heatsinks and type
                + AeroFighter.HeatSink.Name); 
        }

        private void ChangeSinkType()
        {
            bool isValid = false;                                                           // Sentinel value
            string userInput = InputError;                                                  // Input string

            while (!isValid)                                                                // While input is invalid
            {
                int userChoice;                                                             // Variable holds user input
                DisplaySinks();                                                             // Display current heat sink information
                Console.WriteLine("\nPlease enter the number for the type of heat sink " +  // User Prompt
                    "you would like to select and press the Enter key.");
                Console.WriteLine("\n".PadRight(4) + "Name".PadRight(19) +                  // Display headers
                    "Dissipation".PadRight(13) + "Cost (each)");
                for (int i = 0; i < SinkTypes.Count; i++)                                   // Iterate through list of available heat sink types
                {                                                                           // Print detail for each heat sink type
                    Console.WriteLine(((i + 1) + ". ").PadRight(3) +                        // Choice number
                        SinkTypes[i].Name.PadRight(19) +                                    // Heat sink name
                        (SinkTypes[i].Dissipation.ToString() +                              // Heat sink dissipation
                        " heat/turn").PadRight(13) +
                        (SinkTypes[i].Cost).ToString() + " C-bills");                       // Heat sink cost
                }
                userInput = check.ParseInput(Console.ReadLine());                           // Read and parse user input as string
                if (Int32.TryParse(userInput, out userChoice))                              // Parse input into an int
                {
                    if (userChoice > 0 && userChoice <= SinkTypes.Count)                    // Validate int is within parameters
                    {
                        if (!SinkTypes[userChoice - 1].Equals(AeroFighter.HeatSink))        // If choice is not the same as current heat sinks (index offset)
                        {
                            AeroFighter.HeatSink = SinkTypes[userChoice - 1];               // Set new heat sink type (index offset)                            
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

        private void SinkMenu()
        {
            Console.WriteLine("\n1. Change heat sink type");
            Console.WriteLine("2. Change heat sink quantity");
            Console.WriteLine("3. Return to previous menu");
            Console.Write("Selection: ");
        }

        // Displays information on fighter's heat sinks
        private void DisplaySinks()
        {
            int totalSinks = AeroFighter.TotalSinks();                                      // Total heat sinks on fighter
            int dissipation = AeroFighter.HeatSink.Dissipation * totalSinks;                // Total heat dissipation
            Console.WriteLine("\nFighter currently has " + totalSinks.ToString() + " " + 
                AeroFighter.HeatSink.Name + " for " + dissipation + " heat dissipation per turn");
            Console.WriteLine(AeroFighter.ExtSinks + " are external, weighing " + 
                AeroFighter.ExtSinks + " tons");
        }
    }
}
