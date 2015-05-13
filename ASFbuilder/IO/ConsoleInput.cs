using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASFbuilder.IO
{
    class ConsoleInput
    {
        const string INPUT_ERROR = "Invalid Entry\n";                       // Default for initializing strings
        public string ErrMsg { get; private set; }

        public ConsoleInput()
        {
            ErrMsg = INPUT_ERROR;
        }
        // Trims and sets input to lower case
        public string ParseInput(string input)
        {
            return input.Trim().ToLower();
        }

        // Checks input string against array of accepted values
        public bool Validate(string userInput, string[] validInputs) 
        {
            bool isValid = false;                                           // Returned variable
            foreach (string input in validInputs)                           // Check each entry in validation array
            {
                if (userInput.Equals(input.ToLower()))
                {
                    isValid = true;                                         // If it matches, set to true
                }
            }

            if (!isValid)                                                   // Display error message if invalid
            {
                Console.WriteLine(ErrMsg);
            }
            return isValid;                                                 // Return boolean
        }
    }
}
