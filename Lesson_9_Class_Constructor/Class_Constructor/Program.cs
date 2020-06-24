using System;
using System.CodeDom;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Class_Constructor
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var sw = new StreamWriter("codeblog.txt", false, Encoding.UTF8))
            {
                for (int i = 0; i < 10; i++)
                {
                    sw.WriteLine($"Line {i}");
                }
                
            }

            using (var sr = new StreamReader("codeblog.txt"))
            {
                int i = 0;
                while(!sr.EndOfStream)
                {
                    Console.WriteLine(sr.ReadLine() + " " + i);
                    i++;
                }
            }

                Console.ReadKey();
        }
    }
}
