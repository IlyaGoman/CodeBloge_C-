using System;
using System.Collections.Generic;

namespace ExtentionMethodApp
{
    class Program
    {
        static void Main(string[] args)
        {
            #region RegionName
            //Console.Write("Input number:");
            //var input = Console.ReadLine();
            //int result;

            //if(int.TryParse(input, out result))
            //{
            //    //var isEven = Helper.IsEven(result);
            //    if(result.IsEven())
            //        Console.WriteLine($"{result} - even");
            //    else
            //        Console.WriteLine($"{result} - not even");
            //}
            #endregion


            var roads = new List<Road>();
            for (int i = 0; i < 10; i++)
            {
                var road = new Road();
                road.CreateRandomRoad(1, 1000);
                roads.Add(road);
            }

            var mapRoads = roads.ConvertToString();

            Console.WriteLine(mapRoads);

            Console.ReadKey();
        }
    }
}
