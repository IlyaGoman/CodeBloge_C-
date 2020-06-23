using System;
using System.Collections.Generic;

namespace IEnumerableApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var cars = new List<Car>()
            {
                new Car() {Name="Lada", Number="A001AA01" },
                new Car() {Name="FORD", Number="B001BB01" },
                new Car() {Name="BMW", Number="C001CC01" }
            };

            var parking = new Parking();
            foreach (var car in cars)
            {
                parking.Add(car);
            }

            Console.WriteLine(parking["A001AA01"]?.Name);
            Console.WriteLine(parking["A001AA02"]?.Name);

            foreach (var car in parking)
            {
                Console.WriteLine(car);
            }

            Console.WriteLine();

            foreach (var car in parking.GetNames())
            {
                Console.WriteLine(car);
            }

            Console.ReadKey();
        }
    }
}
