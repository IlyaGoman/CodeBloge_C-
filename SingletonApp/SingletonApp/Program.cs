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
            //var text1 = new FileWorker();
            //var text2 = new FileWorker();

            //text1.WriteText("Hello, world!");
            //text2.WriteText("Hello, Ilya!");

            //text1.Save();
            //text2.Save();

            var singleton1 = FileWorkerSingleton.Instance;
            var singleton2 = FileWorkerSingleton.Instance;

            singleton1.WriteText("Goman");
            singleton2.WriteText("Ilya");
            singleton2.WriteText("Bay-Bay");

            singleton1.Save();
            singleton2.Save();
        }
    }
}
