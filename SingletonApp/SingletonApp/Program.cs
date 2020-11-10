using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace SingletonApp
{
    class Program
    {
        static void Main(string[] args)
        {
            //var text1 = new FileWorker();
            //var text2 = new FileWorker();

            //text1.WriteText("Hello, world!");
            //text2.WriteText("Hello, Ilya!");

            //text1.Save();
            //text2.Save();

            //var singleton1 = FileWorkerSingleton.Instance;
            //var singleton2 = FileWorkerSingleton.Instance;

            //singleton1.WriteText("Goman");
            //singleton2.WriteText("Ilya");
            //singleton2.WriteText("Bay-Bay");

            //singleton1.Save();
            //singleton2.Save();
            
            foreach (var item in GenerateRange(0,100,5))
            {
                Console.Write(item + " ");
            }

            Console.ReadKey();
        }
        //public static List<int> GenerateRange(int min, int max, int step)
        //{
        //    List<int> lst = new List<int>();
        //    for (int i = 0; min + i * step <= max; i++)
        //    {
        //        lst.Add(min + i * step);
        //    }
        //    return lst;
        //}

        public static int[] GenerateRange(int min, int max, int step)
        {
            int[] result = new int[1+(max - min) / step];
            for (int i = min; min + i * step <= max; i++)
            {
                result[i] = min + i * step;
            }

            foreach(var item in result.Select(x=>x*(-1)))
            {
                Console.Write(item + " ");
            }

            return result;
        }
    }

}
