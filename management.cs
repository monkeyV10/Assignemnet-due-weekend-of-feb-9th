using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignemnet_due_weekend_of_feb_9th
{
    class management
    {
        public void DoSomething()
        {
        start:
            Console.WriteLine("Welcome to Modern Appliances!");
            Console.WriteLine("How may we assist you?");
            Console.WriteLine("1 – Check out appliance");
            Console.WriteLine("2 – Find appliances by brand");
            Console.WriteLine("3 – Display appliances by type");
            Console.WriteLine("4 – Produce random appliance list");
            Console.WriteLine("5 – Save & exit");
            Console.Write("Enter option: ");


            int option = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine();
            string[] applianceClasses = { "Refrigerator", "Vacuum", "Microwave", "Dishwasher" };

            // The path of the text file
            string filePath = @"C:\\Users\\mac_h\\source\\repos\\second assignment\\Assignemnet due weekend of feb 9th\\appliances.txt";

            // Check if the file exists
            if (File.Exists(filePath))
            {
                // Create a list to store the lines
                List<string> lines = new List<string>();

                // Read the file line by line
                using (StreamReader reader = new StreamReader(filePath))
                {
                    while (!reader.EndOfStream)
                    {
                        string line = reader.ReadLine();
                        lines.Add(line);
                    }
                }
                static string GenerateRandomRefrigerator()
                {
                    string[] lines = File.ReadAllLines("C:\\Users\\mac_h\\source\\repos\\second assignment\\Assignemnet due weekend of feb 9th\\appliances.txt ");
                    List<string> refrigerators = new List<string>();

                    foreach (string line in lines)
                    {
                        string[] fields = line.Split(';');
                        if (fields[0].StartsWith("1"))
                        {
                            refrigerators.Add(line);
                        }
                    }

                    Random random = new Random();
                    string randomRefrigerator = refrigerators[random.Next(refrigerators.Count)];
                    string[] fridgeFields = randomRefrigerator.Split(';');

                    return $"Item Number: {fridgeFields[0]}\n" +
                           $"Brand: {fridgeFields[1]}\n" +
                           $"Quantity: {fridgeFields[2]}\n" +
                           $"Wattage: {fridgeFields[3]}\n" +
                           $"Color: {fridgeFields[4]}\n" +
                           $"Price: {fridgeFields[5]}\n" +
                           $"Number of Doors: {fridgeFields[6]}\n" +
                           $"Height (inches): {fridgeFields[7]}\n" +
                           $"Width (inches): {fridgeFields[8]}\n";
                }

                static string GenerateRandomVacuum()
                {
                    string[] lines = File.ReadAllLines("C:\\Users\\mac_h\\source\\repos\\second assignment\\Assignemnet due weekend of feb 9th\\appliances.txt ");
                    Random random = new Random();
                    string line = "";
                    while (!line.StartsWith("2"))
                    {
                        line = lines[random.Next(lines.Length)];
                    }
                    string[] fields = line.Split(';');

                    string result = $"Item Number: {fields[0]}\n" +
                                    $"Brand: {fields[1]}\n" +
                                    $"Quantity: {fields[2]}\n" +
                                    $"Wattage: {fields[3]}\n" +
                                    $"Color: {fields[4]}\n" +
                                    $"Price: {fields[5]}\n" +
                                    $"Grade: {fields[6]}\n" +
                                    $"Battery Voltage: {fields[7]}";
                    return result;
                }

                static string GenerateRandomMicrowave()
                {
                    string[] lines = File.ReadAllLines("C:\\Users\\mac_h\\source\\repos\\second assignment\\Assignemnet due weekend of feb 9th\\appliances.txt ");
                    string line;
                    Random random = new Random();

                    do
                    {
                        line = lines[random.Next(lines.Length)];
                    } while (!line.StartsWith("3"));

                    string[] fields = line.Split(';');
                    string itemNumber = fields[0];
                    string brand = fields[1];
                    string quantity = fields[2];
                    string wattage = fields[3];
                    string color = fields[4];
                    string price = fields[5];
                    string capacity = fields[7];
                    string roomType = fields[8];

                    return $"Item Number: {itemNumber}\n" +
                           $"Brand: {brand}\n" +
                           $"Quantity: {quantity}\n" +
                           $"Wattage: {wattage}\n" +
                           $"Color: {color}\n" +
                           $"Price: {price}\n" +
                           $"Capacity: {capacity}\n" +
                           $"Room Type: {roomType}";
                }

                static string GenerateRandomDishwasher()
                {
                    // Read the lines from the appliances.txt file
                    string[] lines = File.ReadAllLines("C:\\Users\\mac_h\\source\\repos\\second assignment\\Assignemnet due weekend of feb 9th\\appliances.txt ");

                    // Filter the lines to only include dishwashers (item numbers starting with 4 or 5)
                    var dishwashers = lines.Where(line => line.StartsWith("4") || line.StartsWith("5"));

                    // Choose a random dishwasher from the filtered list
                    string randomDishwasher = dishwashers.ElementAt(new Random().Next(0, dishwashers.Count()));

                    // Parse the fields and return a formatted string
                    string[] fields = randomDishwasher.Split(';');
                    return $"Item Number: {fields[0]}\n" +
                           $"Brand: {fields[1]}\n" +
                           $"Quantity: {fields[2]}\n" +
                           $"Wattage: {fields[3]}\n" +
                           $"Color: {fields[4]}\n" +
                           $"Price: {fields[5]}\n" +
                           $"Noise Level: {fields[6]}\n" +
                           $"Energy Efficiency Rating: {fields[7]}";
                }


                switch (option)
                {
                    case 1:
                        Console.Write("Enter the item number of an appliance: ");
                        int itemNumber = Convert.ToInt32(Console.ReadLine());

                        bool itemNumberFound = false;
                        foreach (string line in lines)
                        {
                            // Split the line by comma
                            string[] fields = line.Split(';');

                            // Check if the first field (item number) matches the input
                            if (int.TryParse(fields[0], out int number) && number == itemNumber)
                            {
                                itemNumberFound = true;
                                // Check if the quantity is greater than 0
                                if (int.TryParse(fields[2], out int quantity) && quantity >= 1)
                                {
                                    Console.WriteLine($"Appliance {itemNumber} has been checked out.");
                                    // TODO: Decrement the quantity by 1 in the file
                                    Console.WriteLine();
                                }
                                else
                                {
                                    Console.WriteLine("The appliance is not available to be checked out.");
                                    Console.WriteLine();
                                }
                                break;
                            }
                        }

                        if (!itemNumberFound)
                        {
                            Console.WriteLine("No appliances found with that item number.");
                            Console.WriteLine();
                        }
                        goto start;

                    case 2:
                        Console.Write("Enter brand to search for: ");
                        string brand = Console.ReadLine();
                        Console.WriteLine();

                        bool brandFound = false;
                        List<string> matchingAppliances = new List<string>();

                        foreach (string line in lines)
                        {
                            string[] fields = line.Split(';');

                            if (fields[1] == brand)
                            {
                                brandFound = true;

                                // Check if the item number starts with 1 (refrigerator)
                                if (fields[0].StartsWith("1"))
                                {
                                    string[] refrigeratorFields = line.Split(';');

                                    // Output the required fields for refrigerators
                                    Console.WriteLine("Refridgerator");
                                    Console.WriteLine($"Item Number: {refrigeratorFields[0]}");
                                    Console.WriteLine($"Brand: {refrigeratorFields[1]}");
                                    Console.WriteLine($"Quantity: {refrigeratorFields[2]}");
                                    Console.WriteLine($"Wattage: {refrigeratorFields[3]}");
                                    Console.WriteLine($"Color: {refrigeratorFields[4]}");
                                    Console.WriteLine($"Price: {refrigeratorFields[5]}");
                                    Console.WriteLine($"Number of Doors: {refrigeratorFields[6]}");
                                    Console.WriteLine($"Height (inches): {refrigeratorFields[7]}");
                                    Console.WriteLine($"Width (inches): {refrigeratorFields[8]}");
                                    Console.WriteLine();
                                }
                                else if (fields[0].StartsWith("2"))
                                {
                                    string[] vacuumFields = line.Split(';');

                                    // Output the required fields for vacuums
                                    Console.WriteLine("Vacuum");
                                    Console.WriteLine($"Item Number: {vacuumFields[0]}");
                                    Console.WriteLine($"Brand: {vacuumFields[1]}");
                                    Console.WriteLine($"Quantity: {vacuumFields[2]}");
                                    Console.WriteLine($"Wattage: {vacuumFields[3]}");
                                    Console.WriteLine($"Color: {vacuumFields[4]}");
                                    Console.WriteLine($"Price: {vacuumFields[5]}");
                                    Console.WriteLine($"Grade: {vacuumFields[6]}");

                                    if (vacuumFields[7] == "18")
                                    {
                                        Console.WriteLine($"Battery Voltage: low");
                                    }
                                    else if (vacuumFields[7] == "24")
                                    {
                                        Console.WriteLine($"Battery Voltage: high");
                                    }
                                    Console.WriteLine();
                                }
                                else if (fields[0].StartsWith("3"))
                                {
                                    string[] microwaveFields = line.Split(';');

                                    // Output the required fields for microwaves
                                    Console.WriteLine("Microwave");
                                    Console.WriteLine($"Item Number: {microwaveFields[0]}");
                                    Console.WriteLine($"Brand: {microwaveFields[1]}");
                                    Console.WriteLine($"Quantity: {microwaveFields[2]}");
                                    Console.WriteLine($"Wattage: {microwaveFields[3]}");
                                    Console.WriteLine($"Color: {microwaveFields[4]}");
                                    Console.WriteLine($"Price: {microwaveFields[5]}");
                                    Console.WriteLine($"Capacity: {microwaveFields[6]}");
                                    Console.WriteLine($"Room Type: {microwaveFields[7]}");
                                    Console.WriteLine();
                                }
                                else if (fields[0].StartsWith("4") || fields[0].StartsWith("5"))
                                {
                                    string[] dishwasherFields = line.Split(';');

                                    // Output the required fields for dishwashers
                                    Console.WriteLine("Dishwasher");
                                    Console.WriteLine($"Item Number: {dishwasherFields[0]}");
                                    Console.WriteLine($"Brand: {dishwasherFields[1]}");
                                    Console.WriteLine($"Quantity: {dishwasherFields[2]}");
                                    Console.WriteLine($"Wattage: {dishwasherFields[3]}");
                                    Console.WriteLine($"Color: {dishwasherFields[4]}");
                                    Console.WriteLine($"Price: {dishwasherFields[5]}");
                                    Console.WriteLine($"Special Feature: {dishwasherFields[6]}");
                                    Console.WriteLine($"Sound Rating: {dishwasherFields[7]}");
                                    Console.WriteLine();
                                }
                                else
                                {
                                    matchingAppliances.Add(line);
                                }
                            }
                        }

                        if (brandFound)
                        {
                            if (matchingAppliances.Count > 0)
                            {
                                Console.WriteLine("Matching Appliances:");
                                foreach (string appliance in matchingAppliances)
                                {
                                    Console.WriteLine(appliance);
                                }
                            }
                        }
                        else
                        {
                            Console.WriteLine("No appliances found for that brand.");
                        }
                        goto start;

                    case 3:
                        {
                            Console.WriteLine("Appliance Types");
                            Console.WriteLine("1 – Refrigerators");
                            Console.WriteLine("2 – Vacuums");
                            Console.WriteLine("3 – Microwaves");
                            Console.WriteLine("4 – Dishwashers");
                            Console.WriteLine("Enter type of appliance: ");

                            int input = int.Parse(Console.ReadLine());

                            if (input == 1)

                            {
                                Console.Write("Enter number of doors: 2 (double door), 3 (three doors) or 4 (four doors): ");
                                string numberOfDoors = Console.ReadLine();
                                Console.WriteLine();
                                List<string> matchingdoor = new List<string>();
                                Console.WriteLine("Refridgerator");

                                foreach (string line in lines)
                                {
                                    string[] fields = line.Split(';');
                                    if (fields[6] == numberOfDoors)
                                    {
                                        if (fields[6].StartsWith("2"))
                                        {
                                            string[] refrigeratorFields = line.Split(';');


                                            Console.WriteLine();
                                            Console.WriteLine($"Item Number: {refrigeratorFields[0]}");
                                            Console.WriteLine($"Brand: {refrigeratorFields[1]}");
                                            Console.WriteLine($"Quantity: {refrigeratorFields[2]}");
                                            Console.WriteLine($"Wattage: {refrigeratorFields[3]}");
                                            Console.WriteLine($"Color: {refrigeratorFields[4]}");
                                            Console.WriteLine($"Price: {refrigeratorFields[5]}");
                                            Console.WriteLine($"Number of Doors: {refrigeratorFields[6]}");
                                            Console.WriteLine($"Height (inches): {refrigeratorFields[7]}");
                                            Console.WriteLine($"Width (inches): {refrigeratorFields[8]}");
                                            Console.WriteLine();
                                        }

                                        else if (fields[6].StartsWith("3"))
                                        {
                                            string[] refrigeratorFields = line.Split(';');

                                            Console.WriteLine($"Item Number: {refrigeratorFields[0]}");
                                            Console.WriteLine($"Brand: {refrigeratorFields[1]}");
                                            Console.WriteLine($"Quantity: {refrigeratorFields[2]}");
                                            Console.WriteLine($"Wattage: {refrigeratorFields[3]}");
                                            Console.WriteLine($"Color: {refrigeratorFields[4]}");
                                            Console.WriteLine($"Price: {refrigeratorFields[5]}");
                                            Console.WriteLine($"Number of Doors: {refrigeratorFields[6]}");
                                            Console.WriteLine($"Height (inches): {refrigeratorFields[7]}");
                                            Console.WriteLine($"Width (inches): {refrigeratorFields[8]}");
                                            Console.WriteLine();
                                        }

                                        else if (fields[6].StartsWith("4"))
                                        {
                                            string[] refrigeratorFields = line.Split(';');

                                            Console.WriteLine($"Item Number: {refrigeratorFields[0]}");
                                            Console.WriteLine($"Brand: {refrigeratorFields[1]}");
                                            Console.WriteLine($"Quantity: {refrigeratorFields[2]}");
                                            Console.WriteLine($"Wattage: {refrigeratorFields[3]}");
                                            Console.WriteLine($"Color: {refrigeratorFields[4]}");
                                            Console.WriteLine($"Price: {refrigeratorFields[5]}");
                                            Console.WriteLine($"Number of Doors: {refrigeratorFields[6]}");
                                            Console.WriteLine($"Height (inches): {refrigeratorFields[7]}");
                                            Console.WriteLine($"Width (inches): {refrigeratorFields[8]}");
                                            Console.WriteLine();
                                        }
                                        else
                                        {
                                            matchingdoor.Add(line);
                                        }
                                    }
                                }
                            }
                            if (input == 2)
                            {
                                Console.Write("Enter battery voltage value. 18 V (low) or 24 V (high): ");
                                string whichwattage = Console.ReadLine();
                                Console.WriteLine();
                                List<string> voltage = new List<string>();
                                Console.WriteLine("Matching vacuums");

                                foreach (string line in lines)
                                {
                                    string[] fields = line.Split(';');
                                    if (fields[7] == whichwattage)
                                    {
                                        if (fields[7].StartsWith("18"))
                                        {
                                            string[] vacuumFields = line.Split(';');

                                            // Output the required fields for vacuums

                                            Console.WriteLine();
                                            Console.WriteLine($"Item Number: {vacuumFields[0]}");
                                            Console.WriteLine($"Brand: {vacuumFields[1]}");
                                            Console.WriteLine($"Quantity: {vacuumFields[2]}");
                                            Console.WriteLine($"Wattage: {vacuumFields[3]}");
                                            Console.WriteLine($"Color: {vacuumFields[4]}");
                                            Console.WriteLine($"Price: {vacuumFields[5]}");
                                            Console.WriteLine($"Grade: {vacuumFields[6]}");
                                            Console.WriteLine($"Battery Voltage: Low");
                                            Console.WriteLine();
                                        }
                                        else if (fields[7].StartsWith("24"))
                                        {
                                            string[] vacuumFields = line.Split(';');

                                            // Output the required fields for vacuums

                                            Console.WriteLine();
                                            Console.WriteLine($"Item Number: {vacuumFields[0]}");
                                            Console.WriteLine($"Brand: {vacuumFields[1]}");
                                            Console.WriteLine($"Quantity: {vacuumFields[2]}");
                                            Console.WriteLine($"Wattage: {vacuumFields[3]}");
                                            Console.WriteLine($"Color: {vacuumFields[4]}");
                                            Console.WriteLine($"Price: {vacuumFields[5]}");
                                            Console.WriteLine($"Grade: {vacuumFields[6]}");
                                            Console.WriteLine($"Battery Voltage: High");
                                            Console.WriteLine();
                                        }
                                        else
                                        { voltage.Add(line); }
                                    }
                                }
                            }
                            if (input == 3)
                            {
                                Console.Write("RoomWhere the microwave will be installed: K (kitchen) or W (work site): ");
                                string roomplace = Console.ReadLine();
                                Console.WriteLine();
                                List<string> whichroom = new List<string>();
                                Console.WriteLine("Matching microwaves:");

                                foreach (string line in lines)
                                {
                                    string[] fields = line.Split(';');
                                    if (fields[7] == roomplace)
                                    {
                                        if (fields[7].StartsWith("W"))
                                        {
                                            string[] microwaveFields = line.Split(';');


                                            Console.WriteLine();
                                            Console.WriteLine($"Item Number: {microwaveFields[0]}");
                                            Console.WriteLine($"Brand: {microwaveFields[1]}");
                                            Console.WriteLine($"Quantity: {microwaveFields[2]}");
                                            Console.WriteLine($"Wattage: {microwaveFields[3]}");
                                            Console.WriteLine($"Color: {microwaveFields[4]}");
                                            Console.WriteLine($"Price: {microwaveFields[5]}");
                                            Console.WriteLine($"Capacity: {microwaveFields[6]}");
                                            Console.WriteLine($"Room Type: {microwaveFields[7]}");
                                            Console.WriteLine();
                                        }
                                        else if (fields[7].StartsWith("K"))
                                        {
                                            string[] microwaveFields = line.Split(';');


                                            Console.WriteLine();
                                            Console.WriteLine($"Item Number: {microwaveFields[0]}");
                                            Console.WriteLine($"Brand: {microwaveFields[1]}");
                                            Console.WriteLine($"Quantity: {microwaveFields[2]}");
                                            Console.WriteLine($"Wattage: {microwaveFields[3]}");
                                            Console.WriteLine($"Color: {microwaveFields[4]}");
                                            Console.WriteLine($"Price: {microwaveFields[5]}");
                                            Console.WriteLine($"Capacity: {microwaveFields[6]}");
                                            Console.WriteLine($"Room Type: {microwaveFields[7]}");
                                            Console.WriteLine();
                                        }
                                        else
                                        {
                                            whichroom.Add(line);
                                        }
                                    }
                                }
                            }
                            if (input == 4)

                            {
                                Console.Write("Enter the sound rating of the dishwasher: Qt (Quietest), Qr (Quieter), Qu(Quiet) or M (Moderate): ");
                                string sounds = Console.ReadLine();
                                Console.WriteLine();
                                List<string> soundrate = new List<string>();
                                Console.WriteLine("Dishwasher");

                                foreach (string line in lines)
                                {
                                    string[] fields = line.Split(';');
                                    if (fields[7] == sounds)
                                    {
                                        if (fields[7].StartsWith("Qt"))
                                        {
                                            string[] dishwasherFields = line.Split(';');

                                            // Output the required fields for dishwashers
                                            Console.WriteLine();
                                            Console.WriteLine($"Item Number: {dishwasherFields[0]}");
                                            Console.WriteLine($"Brand: {dishwasherFields[1]}");
                                            Console.WriteLine($"Quantity: {dishwasherFields[2]}");
                                            Console.WriteLine($"Wattage: {dishwasherFields[3]}");
                                            Console.WriteLine($"Color: {dishwasherFields[4]}");
                                            Console.WriteLine($"Price: {dishwasherFields[5]}");
                                            Console.WriteLine($"Special Feature: {dishwasherFields[6]}");
                                            Console.WriteLine($"Sound Rating: {dishwasherFields[7]}");
                                            Console.WriteLine();
                                        }
                                        else if (fields[7].StartsWith("Qr"))
                                        {
                                            string[] dishwasherFields = line.Split(';');

                                            // Output the required fields for dishwashers
                                            Console.WriteLine();
                                            Console.WriteLine($"Item Number: {dishwasherFields[0]}");
                                            Console.WriteLine($"Brand: {dishwasherFields[1]}");
                                            Console.WriteLine($"Quantity: {dishwasherFields[2]}");
                                            Console.WriteLine($"Wattage: {dishwasherFields[3]}");
                                            Console.WriteLine($"Color: {dishwasherFields[4]}");
                                            Console.WriteLine($"Price: {dishwasherFields[5]}");
                                            Console.WriteLine($"Special Feature: {dishwasherFields[6]}");
                                            Console.WriteLine($"Sound Rating: {dishwasherFields[7]}");
                                            Console.WriteLine();
                                        }
                                        else if (fields[7].StartsWith("Qu"))
                                        {
                                            string[] dishwasherFields = line.Split(';');

                                            // Output the required fields for dishwashers
                                            Console.WriteLine();
                                            Console.WriteLine($"Item Number: {dishwasherFields[0]}");
                                            Console.WriteLine($"Brand: {dishwasherFields[1]}");
                                            Console.WriteLine($"Quantity: {dishwasherFields[2]}");
                                            Console.WriteLine($"Wattage: {dishwasherFields[3]}");
                                            Console.WriteLine($"Color: {dishwasherFields[4]}");
                                            Console.WriteLine($"Price: {dishwasherFields[5]}");
                                            Console.WriteLine($"Feature: {dishwasherFields[6]}");
                                            Console.WriteLine($"Sound Rating: {dishwasherFields[7]}");
                                            Console.WriteLine();
                                        }
                                        else if (fields[7].StartsWith("M"))
                                        {
                                            string[] dishwasherFields = line.Split(';');

                                            // Output the required fields for dishwashers
                                            Console.WriteLine();
                                            Console.WriteLine($"Item Number: {dishwasherFields[0]}");
                                            Console.WriteLine($"Brand: {dishwasherFields[1]}");
                                            Console.WriteLine($"Quantity: {dishwasherFields[2]}");
                                            Console.WriteLine($"Wattage: {dishwasherFields[3]}");
                                            Console.WriteLine($"Color: {dishwasherFields[4]}");
                                            Console.WriteLine($"Price: {dishwasherFields[5]}");
                                            Console.WriteLine($"Feature: {dishwasherFields[6]}");
                                            Console.WriteLine($"Sound Rating: {dishwasherFields[7]}");
                                            Console.WriteLine();
                                        }
                                        else
                                        {
                                            soundrate.Add(line);
                                        }
                                    }
                                }
                            }
                        }
                        goto start;


                    case 4:
                        Console.Write("Enter number of appliances: ");
                        int numAppliances = int.Parse(Console.ReadLine());

                        Console.WriteLine("Random appliances:");
                        Console.WriteLine();
                        Random random = new Random();

                        for (int i = 0; i < numAppliances; i++)
                        {
                            int index = random.Next(1, 5);
                            switch (index)
                            {
                                case 1:
                                    Console.WriteLine(GenerateRandomRefrigerator());
                                    break;
                                case 2:
                                    Console.WriteLine(GenerateRandomVacuum());
                                    break;
                                case 3:
                                    Console.WriteLine(GenerateRandomMicrowave());
                                    break;
                                case 4:
                                    Console.WriteLine(GenerateRandomDishwasher());
                                    break;
                            }
                            Console.WriteLine();
                        }

                        goto start;

                        

                    case 5:
                        Console.WriteLine("Exiting the program.");
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Invalid option.");
                        goto start;
                }
            }
            else
            {
                Console.WriteLine("The file does not exist.");
            }

            Console.ReadLine();
        }
    }
}