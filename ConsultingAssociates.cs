using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilesOperations
{
    internal class ConsultingAssociates
    {
        //stream class
        public string Name { get; set; }
        public string?  ConId { get; set; }
        public string Email { get; set; }
        public string ClientName { get; set; }
        public ConsultingAssociates() { }
        public ConsultingAssociates(string name, string conId, string email, string clientName)
        {
            Name = name;
            ConId = conId;
            Email = email;
            ClientName = clientName;
        }
        public void Display()
        {
            Console.WriteLine($"Name: {Name}, Consultant ID: {ConId}, Email: {Email}, Client Name: {ClientName}");
        }
        public void AddAssociates(ConsultingAssociates associate, string filePath)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(filePath, true))
                {
                    writer.WriteLine($"Name:{associate.Name},Consultant ID:{associate.ConId},Email:{associate.Email},Client Name:{associate.ClientName}");
                }
            }
            catch (IOException ioex)
            {
                Console.WriteLine("Error writing to file: " + ioex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
        public void ReadAssociates(string filePath)
        {
            try
            {
                if (!File.Exists(filePath))
                {
                    Console.WriteLine("No associates found.");
                    return;
                }
                using (StreamReader reader = new StreamReader(filePath))
                {
                    string? line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        Console.WriteLine(line);
                    }
                }
            }
            catch (IOException ioex)
            {
                Console.WriteLine("Error reading file: " + ioex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}
