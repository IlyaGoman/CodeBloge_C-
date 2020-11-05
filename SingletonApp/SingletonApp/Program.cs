using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SingletonApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var text1 = new FileWorker();

            text1.WriteText("Hello. world!");
            text1.WriteText("Hello, Ilya!");

            text1.Save();

            Console.ReadKey();
        }
    }
}
