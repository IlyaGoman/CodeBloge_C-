using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqApp
{
    class Program
    {
        static Random rnd = new Random();
        static void Main(string[] args)
        {
            var collection = new List<Product>();
            for (int i = 0; i < 10; i++)
            {
                var product = new Product()
                {
                    Name = "Product_" + i,
                    Energy = rnd.Next(10, 500)
                };
                collection.Add(product);
            }

            var result = from item in collection
                         where item.Energy < 200
                         select item;

            foreach (var i in result)
                Console.WriteLine(i);

            Console.WriteLine();

            var result2 = collection.Where(item => item.Energy < 200 || item.Energy > 400);

            foreach (var i in result2)
                Console.WriteLine(i);

            Console.WriteLine();

            Console.WriteLine("Select");
            var selectCollection = collection.Select(item => item.Energy);

            foreach (var i in selectCollection)
                Console.WriteLine(i);

            Console.WriteLine();
            Console.WriteLine("Aggregate");

            var array = new int[] { 1, 2, 3};
            var array2 = new int[] { 1, 2};
            var aggregate = array.Aggregate((x, y) => x * y);

            Console.WriteLine(aggregate);
            Console.WriteLine();

            Console.ReadKey();


        }
    }
}
