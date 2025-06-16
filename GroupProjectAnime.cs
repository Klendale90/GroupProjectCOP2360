// Import necessary namespaces
using System;                   // For basic system functions and console I/O
using System.Collections.Generic; // For Dictionary and List data structures

namespace DictionarySwitchApp
{
    class Program
    {
        // Static dictionary storing string keys and lists of string values
        static Dictionary<string, List<string>> myDictionary = new Dictionary<string, List<string>>();

        // Main program entry point
        static void Main(string[] args)
        {
            bool exit = false;  // Control flag for program loop
            
            // Main program loop
            while (!exit)
            {
                ShowMenu();     // Display menu options
                Console.Write("Enter your choice: ");
                string choice = Console.ReadLine();  // Read user input

                // Switch statement handling menu choices
                switch (choice)
                {
                    case "1":
                        PopulateDictionary();  // Initialize dictionary with sample data
                        break;
                    case "2":
                        DisplayDictionary();   // Show current dictionary contents
                        break;
                    case "3":
                        RemoveKey();           // Delete a key-value pair
                        break;
                    case "4":
                        AddNewKeyValue();      // Insert new key with initial value
                        break;
                    case "5":
                        AddValueToExistingKey(); // Append value to existing key
                        break;
                    case "6":
                        SortKeys();            // Display sorted keys
                        break;
                    case "0":
                        exit = true;           // Exit program
                        Console.WriteLine("Exiting program.");
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
        }

        // Displays menu options to user
        static void ShowMenu()
        {
            Console.WriteLine("\nDictionary Management Menu:");
            Console.WriteLine("1. Populate the Dictionary");       // Option 1
            Console.WriteLine("2. Display Dictionary Contents");   // Option 2
            Console.WriteLine("3. Remove a Key");                  // Option 3
            Console.WriteLine("4. Add a New Key and Value");       // Option 4
            Console.WriteLine("5. Add a Value to an Existing Key");// Option 5
            Console.WriteLine("6. Sort the Keys");                 // Option 6
            Console.WriteLine("0. Exit");                          // Option 0
        }

        // Initializes dictionary with sample data
        static void PopulateDictionary()
        {
            myDictionary.Clear();  // Remove existing entries
            // Add sample categories and items
            myDictionary["Action Anime"] = new List<string> { "Naruto", "Bleach" };
            myDictionary["Romance Anime"] = new List<string> { "Maid-Sama", "Fruits Basket" };
            myDictionary["Psychological Anime"] = new List<string> { "Psycho-Pass", "Death Note" };
            Console.WriteLine("Dictionary populated with sample data.");
        }

        // Displays current dictionary contents
        static void DisplayDictionary()
        {
            Console.WriteLine("\nDictionary Contents:");
            // Iterate through all key-value pairs
            foreach (var kvp in myDictionary)
            {
                // Format: "Key: [value1, value2, ...]"
                Console.WriteLine($"{kvp.Key}: [{string.Join(", ", kvp.Value)}]");
            }
        }

        // Removes specified key from dictionary
        static void RemoveKey()
        {
            Console.Write("Enter the key to remove: ");
            string key = Console.ReadLine();  // Get key to remove
            
            // Attempt removal and notify user
            if (myDictionary.Remove(key))
                Console.WriteLine($"Key '{key}' removed.");
            else
                Console.WriteLine($"Key '{key}' not found.");
        }

        // Adds new key with initial value
        static void AddNewKeyValue()
        {
            Console.Write("Enter new key: ");
            string key = Console.ReadLine();  // Get new key
            
            Console.Write("Enter value: ");
            string value = Console.ReadLine(); // Get initial value
            
            myDictionary[key] = new List<string> { value }; // Create new entry
            Console.WriteLine($"Added key '{key}' with value '{value}'.");
        }

        // Appends value to existing key's list
        static void AddValueToExistingKey()
        {
            Console.Write("Enter the key to append a value to: ");
            string key = Console.ReadLine();  // Get target key
            
            if (myDictionary.ContainsKey(key))
            {
                Console.Write("Enter value to append: ");
                string value = Console.ReadLine();  // Get new value
                myDictionary[key].Add(value);       // Append to list
                Console.WriteLine($"Appended value '{value}' to key '{key}'.");
            }
            else
            {
                Console.WriteLine($"Key '{key}' not found.");
            }
        }

        // Displays sorted dictionary keys
        static void SortKeys()
        {
            Console.WriteLine("\nSorted Keys:");
            List<string> keys = new List<string>(myDictionary.Keys); // Extract keys
            keys.Sort();  // Alphabetical sort
            
            // Print sorted keys
            foreach (string key in keys)
                Console.WriteLine(key);
        }
    }
}


