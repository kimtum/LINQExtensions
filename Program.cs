using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQExtentions
{
    class Program
    {
        static void Main(string[] args)
        {
            var cities = new[] { "London", "Paris" };
            var customers = new[]
            {
                new { Name = "John", City = "London", Age = 24 },
                new { Name = "Marinette", City = "Paris", Age = 31  },
                new { Name = "Pier", City = "Paris", Age = 49  },
                new { Name = "Diego", City = "Madrid", Age = 28  },
                new { Name = "Ivan", City = "Moscow", Age = 35  },
                new { Name = "Boris", City = "London", Age = 56  },
            };

            var x = customers.MyToList().MyOrderByDescending(y => y.Age).MyWhere(y => y.Age > 20).MySelect(y => y.Name);
            //var query = customers.MyToDictionary(y => y.Name);
            //foreach(var a in query)
            //    Console.WriteLine($"{a.Key}: {a.Value}");
            foreach(var a in x)
                Console.WriteLine(a);
            Console.ReadLine();
        }
    }
}
