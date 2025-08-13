using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilesOperations
{
    internal class ProdData
    {
        public int productId { get; set; }
        public string productName { get; set; }
        public double productPrice { get; set; }
        public DateTime productDate { get; set; }
        public ProdData() { }
        public ProdData(int ProductId, string ProductName, double ProductPrice, DateTime ProductDate)
        {
            productId = ProductId;
            productName = ProductName;
            productPrice = ProductPrice;
            productDate = ProductDate;
        }
        public void Display()
        {
            Console.WriteLine($"Product ID: {productId}, Product Name: {productName}, Product Price: {productPrice}, Product Date: {productDate}");
            Console.WriteLine("--------------------------------------------------");
        }
    }
}
