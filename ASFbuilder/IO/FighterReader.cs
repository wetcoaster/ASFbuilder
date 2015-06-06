using System;
using System.Collections.Generic;
using System.IO;
using ASFbuilder.Equipment;
using ASFbuilder.Data;
using ASFbuilder.Ships;
using ASFbuilder.Menus;

namespace ASFbuilder.IO
{
    class FighterReader
    {
        const char SPLITTER = ',';                                                          // Character delimiter for data
        private Fighter AeroFighter { get; set; }                                           // Fighter being printed
        private string InputError { get; set; }                                             // Default error string
        private string PrintLocation { get; set; }                                          // File path
        private ConsoleInput check;                                                         // Console Input checker object


        // Constructor
        public FighterReader(Fighter newFighter)
        {
            AeroFighter = newFighter;                                                       // Set fighter to passed parameter
            check = new ConsoleInput();                                                     // Initialize error checker
            InputError = check.ErrMsg;                                                      // Initialize error message
            PrintLocation = FileLocation.LOCATION;                                          // Initialize default file path
        }

        // Methods

        // Main method
        public Fighter LoadFile()
        {
            string name = RequestName();                                                    // Get name from user
            string address = GenerateFileName(name);                                        // Create/check address
            if (address != null)                                                            // If address is valid
            {
                StartLoad(address);                                                         // Start loading process
            }
            return AeroFighter;                                                             // Return updated fighter
        }

        // Starts load
        public void StartLoad(string address)                                               
        {
            AeroFighter = new Fighter();                                                    // Instantiate new fighter
            List<string> rawData = ReadFighter(address);                                    // Start reading
            foreach (string row in rawData)                                                 // Iterate through list of raw data
            {
                string[] rowData = SplitString(row);                                        // Splits input into a string array
                SortData(rowData);                                                          // Processes data
            }
            Console.WriteLine("\n" + AeroFighter.Name + " successfully loaded!");           // Completion message
        }

        // Switch determines what kind of data row contains depending on first index in row
        private void SortData(string[] rowData)
        {
            switch (rowData[0].ToLower())                                                   // Switch checks header string for data type
            {
                case "mass":                                                                // Row contains mass data
                    AeroFighter.Mass = decimal.Parse(rowData[1]);                           // Parse data and assign to mass
                    break;
                case "designation":                                                         // Row contains fighter designation
                    AeroFighter.Designation = rowData[1];                                   // Assign to designation
                    break;
                case "name":                                                                // Row contains fighter name
                    AeroFighter.Name = rowData[1];                                          // Assign to name
                    break;
                case "nose_item":                                                           // Row contains item for nose location
                    AeroFighter.NoseItems.Add(NewWep(rowData));                             // Add new weapon created from data
                    break;
                case "wing_item":                                                           // Row contains item for wing location
                    AeroFighter.WingItems.Add(NewWep(rowData));                             // Add new weapon created from data
                    break;
                case "aft_item":                                                            // Row contains item for aft location
                    AeroFighter.AftItems.Add(NewWep(rowData));                              // Add new weapon created from data
                    break;
                case "ammo":                                                                // Row contains data for an ammo item
                    AeroFighter.Ammo.Add(NewAmmo(rowData));                                 // Add new ammo created from data
                    break;
                case "armor":                                                               // Row contains armor data
                    AeroFighter.Armor = NewArmor(rowData);                                  // Assign armor created from data
                    break;
                case "engine":                                                              // Row contains engine data
                    AeroFighter.Engine = NewEngine(rowData);                                // Assigh engine created from data
                    break;
                case "heat_sink":                                                           // Row contains heat sink data
                    AeroFighter.HeatSink = NewSink(rowData);                                // Assign heat sink type created from data
                    break;
                case "fuel":                                                                // Row contains fuel data
                    AeroFighter.Fuel = Int32.Parse(rowData[1]);                             // Assign fuel quantity from data
                    break;
                case "sinks":                                                               // Row contains external sink qty
                    AeroFighter.ExtSinks = Int32.Parse(rowData[1]);                         // Assign external sink number from data
                    break;
                case "armor_mass":                                                          // Row contains armor mass
                    AeroFighter.ArmorMass = decimal.Parse(rowData[1]);                      // Assign armor qty from data
                    break;
                case "nose_armor":                                                          // Row contains location armor data
                    AeroFighter.NoseArmor = Int32.Parse(rowData[1]);                        // Assign armor points from data
                    break; 
                case "wing_armor":                                                          // Row contains location armor data
                    AeroFighter.WingArmor = Int32.Parse(rowData[1]);                        // Assign armor points from data
                    break;
                case "aft_armor":                                                           // Row contains location armor data
                    AeroFighter.AftArmor = Int32.Parse(rowData[1]);                         // Assign armor points from data
                    break;
                case "safe_thrust":                                                         // Row contains thrust data
                    AeroFighter.SafeThrust = Int32.Parse(rowData[1]);                       // Assign safe thrust from data
                    break;
                case "max_thrust":                                                          // Row contains thrust data
                    AeroFighter.MaxThrust = Int32.Parse(rowData[1]);                        // Assign safe thrust from data
                    break;
                case "controls":                                                            // Row contains control mass
                    AeroFighter.Controls = decimal.Parse(rowData[1]);                       // Assign control tonnage from data
                    break;
                default:                                                                    // Default case
                    Console.WriteLine("There is a problem with the data format for " +      // Error message for switch failure
                        rowData[0]);
                    break;
            }
        }

        // Parses a string array to create a new weapon
        private Equipment.Weapon NewWep(string[] data)
        {
            int bv1 = Int32.Parse(data[1]);                                                 // Extracts BV1 from index 1
            int cost = Int32.Parse(data[2]);                                                // Extracts cost from index 2
            decimal mass = decimal.Parse(data[3]);                                          // Extracts mass from index 3
            string name = data[4];                                                          // Extracts name from index 4
            int damage = Int32.Parse(data[5]);                                              // Extracts damage from index 5
            int heat = Int32.Parse(data[6]);                                                // Extracts heat from index 6
            int ammo = Int32.Parse(data[7]);                                                // Extracts ammo from index 7
            string range = data[8];                                                         // Extracts range from index 8
            string type = data[9];                                                          // Extracts weapon type from index 9
            return new Equipment.Weapon(bv1, cost, mass, name, damage, heat, ammo,          // Returns a weapon created with data
                range, type); 
        }

        // Parses a string array to create an ammo item
        private Equipment.Ammo NewAmmo(string[] data)
        {
            int bv1 = Int32.Parse(data[1]);                                                 // Extracts BV1 from index 1
            int cost = Int32.Parse(data[2]);                                                // Extracts cost from index 2
            decimal mass = decimal.Parse(data[3]);                                          // Extracts mass from index 3
            string name = data[4];                                                          // Extracts name from index 4
            int ammo = Int32.Parse(data[5]);                                                // Extracts ammo from index 5
            return new Equipment.Ammo(bv1, cost, mass, name, ammo);                         // Returns an ammo item created with data
        }

        // Parses a string array to create an armor item
        private Equipment.Armor NewArmor(string[] data)
        {
            int bv1 = Int32.Parse(data[1]);                                                 // Extracts BV1 from index 1
            int cost = Int32.Parse(data[2]);                                                // Extracts cost from index 2
            decimal mass = decimal.Parse(data[3]);                                          // Extracts mass from index 3
            string name = data[4];                                                          // Extracts name from index 4
            int points = Int32.Parse(data[5]);                                              // Extracts points from index 5
            decimal multiplier = decimal.Parse(data[6]);                                    // Extracts multiplier from index 6
            return new Equipment.Armor(bv1, cost, mass, name, points, multiplier);          // Returns armor created with data
        }

        // Parses a string array to create an engine item
        private Equipment.Engine NewEngine(string[] data)
        {
            int size = Int32.Parse(data[1]);                                                // Extracts engine size from index 1
            decimal mass = decimal.Parse(data[2]);                                          // Extracts engine mass from index 2
            string name = data[3];                                                          // Extracts engine name from index 3
            string type = data[4];                                                          // Extracts engine name from index 4
            return new Equipment.Engine(size, mass, name, type);                            // Returns engine created with data
        }

        // Parses a string array to create a heatsink item
        private Equipment.HeatSinks NewSink(string[] data)
        {
            int bv1 = Int32.Parse(data[1]);                                                 // Extracts BV1 from index 1
            int cost = Int32.Parse(data[2]);                                                // Extracts cost from index 2
            decimal mass = decimal.Parse(data[3]);                                          // Extracts mass from index 3
            string name = data[4];                                                          // Extracts name from index 4
            int dissipation = Int32.Parse(data[5]);                                         // Extracts dissipation from index 5
            return new Equipment.HeatSinks(bv1, cost, mass, name, dissipation);             // Returns heatsink created with data
        }

        // Splits string 
        private static string[] SplitString(string input)
        {
            string[] splitInput = input.Split(SPLITTER);                                    // Splits string into a string array 
            return splitInput;                                                              // Returns array
        }

        // Generates a file name using user input
        private List<string> ReadFighter(string address)
        {
            StreamReader sr = new StreamReader(address);                                    // Open a new stream reader
            List<string> rawData = new List<string>();                                      // New list to hold data

            while (!sr.EndOfStream)                                                         // While csv file has data
            {
                rawData.Add(sr.ReadLine());                                                 // Add string to list
            }
            sr.Close();                                                                     // Close stream reader
            return rawData;                                                                 // Return read data
        }

        // Prompts user to submit a file name
        private string RequestName()
        {
            string name = InputError;                                                       // Initalize string
            Console.WriteLine("\nPlease enter the name of the fighter you are loading. " +  // User prompt
                "Do not include the designation.");
            name = Console.ReadLine().Trim().ToLower();                                     // Assign trimmed and to lower string to name
            return name;                                                                    // Returns name of fighter       
        }                                 
        private string GenerateFileName(string name)
        {
            string address = FileLocation.LOCATION + name + ".csv";                         // Concatenates file name from fighter name                  
            if (!File.Exists(address))
            {
                Console.WriteLine("No file matching that name could be found.");            // File not found message
                return null;                                                                // Return null
            }
            else
            {
                return address;                                                             // Return address
            }
        }
    }
}