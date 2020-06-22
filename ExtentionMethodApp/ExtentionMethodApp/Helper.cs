using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExtentionMethodApp
{
    public static class Helper
    {
        public static bool IsEven(this int a)
        {
            return a % 2 == 0;
        }

        public static Road CreateRandomRoad(this Road road, int min, int max)
        {
            var rnd = new Random(Guid.NewGuid().ToByteArray().Sum(x=>x));
            road.Number = rnd.Next(min, max);
            road.Length = rnd.Next(min, max);
            return road;
        }

        public static string ConvertToString(this IEnumerable collection)
        {
            var result = "";

            foreach (var item in collection)
            {
                result += item.ToString() + "\n";
            }

            return result;
        }
    }
}
