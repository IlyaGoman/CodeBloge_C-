using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var prod = new Product<int>("Apple", 100, 15);

            Console.WriteLine(prod);

            var eat = new Eating<Product<int>, int>();
            eat.Add(prod);

            Console.WriteLine($"All volume eating: {eat.Volume}");

            Console.ReadKey();
        }
    }
}
