using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilesOperations
{
    internal class LinqDemo
    {
        int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
        List<SmartThings> smartobj = new List<SmartThings>
        {
            new SmartThings("bkm", "Smart Light"),
            new SmartThings("sd", "Smart Thermostat"),
            new SmartThings("sf", "Smart Lock"),
            new SmartThings("ak", "Smart Camera")
        };
        ArrayList ArrayList = new ArrayList
        {
           1, 2, 3, 4, 5, 6, 7, 8, 9, 10,"smart light", "smart thermostat", "smart lock", "smart camera"
        };

        public void SingleorSingleDefault()
        {
            try
            {
                var res = smartobj.Single(t => t.Type == "Smart Light");
                Console.WriteLine(res.Name);
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            //try
            //{
            //    var res1 = smartobj.SingleOrDefault(t => t.Type == "Smart Camera");
            //    Console.WriteLine(res1.Type);
            //}
            //catch (InvalidOperationException ex)
            //{
            //    Console.WriteLine("Error: " + ex.Message);
            //}
        }

        public void LinqFirstorFirstDefault()
        {
            var res= smartobj.First(t=> t.Name=="bkm");
            Console.WriteLine(res.Name);
            var res1 = smartobj.FirstOrDefault(t => t.Name == "sd");
            Console.WriteLine(res1.Name);
        }

        //linq queries
        public void TakeLinq()
        {
            Console.WriteLine("Using Take in LINQ");
            var result = numbers.Take(9);
            foreach (var n in result)
            {
                Console.Write(n + " ");
            }
            Console.WriteLine();

            var takeresult = numbers.TakeWhile(n => n > 0);

            Console.WriteLine("Using TakeWhile in LINQ");
            foreach (var n in takeresult)
            {
                Console.Write(n + " ");
            }
            Console.WriteLine();
        }
        public void linqtypearraylist()
        {
            var names = ArrayList.OfType<string>();
            var numbers = ArrayList.OfType<int>();
            Console.WriteLine("ArrayList of names :");
            foreach (var name in names)
            {
                Console.WriteLine(name+" ");
            }
            Console.WriteLine("ArrayList of numbers :");
            foreach (var number in numbers)
            {
                Console.WriteLine(number + " ");
            }
        }
        public void basiclinq()
        {
            var result = from number in numbers select number;
            Console.WriteLine("Even Numbers:");
            foreach (var num in result)
            {
                Console.Write(num+" ");
            }
            Console.WriteLine();
        }
        public void UsingwhereLinq()
        {
            Console.WriteLine("using where clause in LINQ");
            var result = from number in numbers
                         where number > 7
                         select number;

            foreach (var num in result)
            {
                Console.Write(" " + num);
            }
        }

        public void UsingOrderByLinq()
        {
            Console.WriteLine("using OrderBy clause in LINQ");
            var result = from smart in smartobj
                         orderby smart.Name ascending
                         select smart;
            foreach (var temp in result)
            {
                Console.WriteLine($"Name: {temp.Name}, type: {temp.Type}");
            }
        }
       
        public void GroupByLinq()
        {
            Console.WriteLine("Using GroupBy in LINQ");
            var groupedTrainees = smartobj.GroupBy(t => t.Type);
            foreach (var group in groupedTrainees)
            {
                Console.WriteLine($"Course: {group.Key}");
                foreach (var trainee in group)
                {
                    Console.WriteLine($"  Name: {trainee.Name}, type: {trainee.Type}");
                }
            }
        }
        public void OrderByThenByLinq()
        {
            Console.WriteLine("Using OrderBy and ThenBy in LINQ");
            /* var result = from trainee in trainees
                          orderby trainee.Name ascending, trainee.Id descending
                          select trainee;*/
            var result = smartobj.OrderBy(t => t.Name).ThenByDescending(t => t.Name);
            foreach (var t in result)
            {
                Console.WriteLine($"Name: {t.Name}, Id: {t.Type}");
            }
        }
    }
}
