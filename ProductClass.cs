using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilesOperations
{
    internal class ProductClass
    {
        public string? productId { get; set; }
        public string productName { get; set; }
        public double productPrice { get; set; }
        public ProductClass() { }
        public ProductClass(string? ProductId, string ProductName, double ProductPrice)
        {
            productId = ProductId;
            productName = ProductName;
            productPrice = ProductPrice;
        }
        public void Display()
        {
            Console.WriteLine($"Product ID: {productId}, Product Name: {productName}, Product Price: {productPrice}");
        }
        public void writeProduct(ProductClass product, string filePath)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(filePath, true)) //if file does not exist, it will be created
                {
                    writer.WriteLine($"Product ID:{product.productId},Product Name:{product.productName},Product Price:{product.productPrice}");
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
        public void readProduct(string filePath)
        {
            try
            {
                if (!File.Exists(filePath))
                {
                    Console.WriteLine("No products found.");
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
