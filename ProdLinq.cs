using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilesOperations
{
    internal class ProdLinq
    {
        List<ProdData> prod=new List<ProdData>
        {
            new ProdData(1, "computer", 100000, DateTime.Now),
            new ProdData(2, "car", 2000000, DateTime.Now),
            new ProdData(3, "bike", 500000, DateTime.Now),
            new ProdData(4, "mobile", 50000, DateTime.Now),
            new ProdData(5, "tablet", 30000, DateTime.Now),
            new ProdData(6, "watch", 5000, DateTime.Now),
            new ProdData(7, "headphone", 2000, DateTime.Now),
            new ProdData(8, "keyboard", 1000, DateTime.Now),
        };

        public void basiclinq()
        {
            Console.WriteLine("basic linq");
            var res = from a in prod
                      select a;
            foreach (var r in res)
            {
                r.Display();
            }
        }
        public void wherelinq() 
        {
            Console.WriteLine("where linq");
            var res = prod.Where(p => p.productPrice > 50000);
            foreach (var a in res)
            {
                a.Display();
            }
        }
        public void orderbylinq()
        {
            Console.WriteLine("orderby linq");
            var res = prod.OrderBy(p => p.productPrice);
            foreach (var a in res)
            {
                a.Display();
            }
        }
        public void groupbylinq()
        {
            Console.WriteLine("groupby linq");
            var res = prod.GroupBy(p => p.productDate.Year);
            foreach (var group in res)
            {
                Console.WriteLine($"Year: {group.Key}");
                foreach (var a in group)
                {
                    a.Display();
                }
            }
        }
        public void orderbythenbylinq()
        {
            Console.WriteLine("orderby thenby linq");
            var res = prod.OrderBy(p => p.productPrice).ThenBy(p => p.productName);
            foreach (var a in res)
            {
                a.Display();
            }
        }
        public void takeLinq()
        {
            Console.WriteLine("take linq");
            var result = prod.Take(5);
            foreach (var a in result)
            {
                a.Display();
            }
        }
        public void firstorfirstdefault()
        {
            Console.WriteLine("first or firstdefault linq");
            var res = prod.First(p => p.productName == "computer");
            res.Display();
            var res1 = prod.FirstOrDefault(p => p.productName == "tablet");
            res1.Display();
        }
        public void singleorsingledefault()
        {
            Console.WriteLine("single or singledefault linq");
            try
            {
                var res = prod.Single(p => p.productDate.Year == 2025);
                res.Display();
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            try
            {
                var res1 = prod.SingleOrDefault(p => p.productDate.Year == 2025);
                res1.Display();
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}
