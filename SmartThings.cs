using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Text.Json;

namespace FilesOperations
{
    //file reader, creating a new file
    public class SmartThings
    {
        public string? Name { get; set; }
        public string? Type { get; set; }

        public SmartThings(string name, string type)
        {
            Name = name;
            Type = type;
        }
        public SmartThings() { }

        //serialization and deserialization methods
        public void JsonSerializeMethod(SmartThings smart)
        {
            string jsonString = JsonSerializer.Serialize(smart);
            Console.WriteLine("Serialized JSON: " + jsonString);
            SmartThings smrt= JsonSerializer.Deserialize<SmartThings>(jsonString);
            Console.WriteLine($"Name: {smrt.Name}, Type: {smrt.Type}");
        }
        public static void AddSmartThing(string filePath)
        {
            try
            {
                Console.Write("Enter SmartThing Name: ");
                string? name = Console.ReadLine();

                Console.Write("Enter SmartThing Type: ");
                string? type = Console.ReadLine();

                string? entry = $"{name},{type}"; 
                File.AppendAllText(filePath, entry + Environment.NewLine);
                Console.WriteLine("SmartThing added successfully.");
            }
            catch (IOException ex)
            {
                Console.WriteLine("Error writing to file: " + ex.Message);
            }
        }

        public static void ViewSmartThings(string filePath)
        {
            try
            {
                if (!File.Exists(filePath))
                {
                    Console.WriteLine("No SmartThings found.");
                    return;
                }

                string[] entries = File.ReadAllLines(filePath);
                Console.WriteLine("\nRegistered SmartThings:");
                foreach (string entry in entries)
                {
                    string[] parts = entry.Split(',');
                    Console.WriteLine($"Name: {parts[0]}, Type: {parts[1]}");
                }
            }
            catch (IOException ex)
            {
                Console.WriteLine("Error reading file: " + ex.Message);
            }
        }

        public static void SearchSmartThing(string filePath, string searchName)
        {
            try
            {
                if (!File.Exists(filePath))
                {
                    Console.WriteLine("No SmartThings found.");
                    return;
                }

                var entries = File.ReadAllLines(filePath);
                var result = entries.FirstOrDefault(e => e.StartsWith(searchName + ","));

                if (result != null)
                {
                    string[] parts = result.Split(',');
                    Console.WriteLine($"Found: Name: {parts[0]}, Type: {parts[1]}");
                }
                else
                {
                    Console.WriteLine("SmartThing not found.");
                }
            }
            catch (IOException ex)
            {
                Console.WriteLine("Error searching file: " + ex.Message);
            }
        }

        public static void DeleteSmartThing(string filePath, string nameToDelete)
        {
            try
            {
                if (!File.Exists(filePath))
                {
                    Console.WriteLine("No SmartThings found.");
                    return;
                }

                var entries = File.ReadAllLines(filePath).ToList();
                int removed = entries.RemoveAll(e => e.StartsWith(nameToDelete + ","));

                if (removed > 0)
                {
                    File.WriteAllLines(filePath, entries);
                    Console.WriteLine("SmartThing deleted successfully.");
                }
                else
                {
                    Console.WriteLine("SmartThing not found.");
                }
            }
            catch (IOException ex)
            {
                Console.WriteLine("Error deleting entry: " + ex.Message);
            }
        }

        public static void UpdateSmartThing(string filePath, string nameToUpdate)
        {
            try
            {
                if (!File.Exists(filePath))
                {
                    Console.WriteLine("No SmartThings found.");
                    return;
                }

                var entries = File.ReadAllLines(filePath).ToList();
                int index = entries.FindIndex(e => e.StartsWith(nameToUpdate + ","));

                if (index != -1)
                {
                    Console.Write("Enter new SmartThing Type: ");
                    string? newType = Console.ReadLine();
                    entries[index] = $"{nameToUpdate},{newType}";
                    File.WriteAllLines(filePath, entries);
                    Console.WriteLine("SmartThing updated successfully.");
                }
                else
                {
                    Console.WriteLine("SmartThing not found.");
                }
            }
            catch (IOException ex)
            {
                Console.WriteLine("Error updating entry: " + ex.Message);
            }
        }

        public static void CountSmartThingsByType(string filePath)
        {
            try
            {
                if (!File.Exists(filePath))
                {
                    Console.WriteLine("No SmartThings found.");
                    return;
                }

                var entries = File.ReadAllLines(filePath);
                var typeCounts = entries
                    .Select(e => e.Split(',')[1])
                    .GroupBy(type => type)
                    .ToDictionary(g => g.Key, g => g.Count());

                Console.WriteLine("\nSmartThing Type Counts:");
                foreach (var kvp in typeCounts)
                {
                    Console.WriteLine($"{kvp.Key}: {kvp.Value}");
                }
            }
            catch (IOException ex)
            {
                Console.WriteLine("Error counting types: " + ex.Message);
            }
        }
    }
}