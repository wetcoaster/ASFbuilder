using System;

namespace ASFbuilder.Equipment
{
    class Item
    {
        public const int MAX_LENGTH = 30;                               // Max name length
        public decimal Mass { get; protected set; }                     // Mass in tonnes
        public int BV1 { get; protected set; }                          // BV1 value
        public int Cost { get; protected set; }                         // Cost in C-bills
        public string Name { get; protected set; }                      // Item name
        
        // Constructors
        // Default constructor initalizes to default values
        public Item()
        {
            Mass = 0m;
            BV1 = 0;
            Cost = 0;
            Name = "Unknown";
        }
        // Non-default constructor takes parameters for all properties
        public Item(int bv1, int cost, decimal mass, string name)
        {
            Mass = ValidateDecimal(mass);
            Cost = ValidateInt(cost);
            BV1 = ValidateInt(bv1);
            Name = ValidateString(name);
        }
        // Non-default constructor takes parameters for cost, name and mass only
        public Item(int cost, decimal mass, string name)
        {
            Mass = ValidateDecimal(mass);
            Cost = ValidateInt(cost);
            BV1 = 0;
            Name = ValidateString(name);
        }
        // Non-default constructor takes parameters for name and mass only
        public Item(decimal mass, string name)
        {
            Mass = ValidateDecimal(mass);
            Name = ValidateString(name);
        }

        // Methods
        // Checks to see if int is >= 0
        protected int ValidateInt(int input)
        {
            if (input >= 0)                                             // If input is not negative
            {
                return input;                                           // Return valid int
            }
            else                                                        // If input is negative
            {
                Console.WriteLine("This number cannot be negative");    // Print error message
                return 0;                                               // Return 0
            }
        }
        // Checks to see if decimal >= 0
        protected decimal ValidateDecimal(decimal input)
        {
            if (input >= 0m)                                            // If input is not negative
            {
                return input;                                           // Return valid decimal
            }
            else                                                        // If input is negative
            {
                Console.WriteLine("This number cannot be negative");    // Print error message
                return 0m;                                              // Return 0
            }
        }
        protected string ValidateString(string input)
        {
            if (input != null && input.Length < MAX_LENGTH)             // If name is not null
            {
                return input.Trim();                                    // Return name with spaces trimmed
            }
            else                                                        // If name is null or > max length
            {
                Console.WriteLine("Name cannot be null or longer than " // Pring error message
                    + MAX_LENGTH + " characters");
                return "Unknown";                                       // Return 'unkown'
            }
        }
    }
}