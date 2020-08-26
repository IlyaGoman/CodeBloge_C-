using StackApps.Model;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;

namespace StackApps
{
    class Program
    {
        static void Main(string[] args)
        {
            var easyStack = new EasyStack<int>();

            easyStack.Push(1);
            easyStack.Push(2);
            easyStack.Push(3);
            easyStack.Push(4);
            easyStack.Push(1);
            easyStack.Push(2);

            foreach (var item in easyStack)
            {
                Console.Write(item + " ");
            }

            Console.WriteLine();

            Console.WriteLine(easyStack.Pop());
            Console.WriteLine(easyStack.Peek());

            foreach (var item in easyStack)
            {
                Console.Write(item + " ");
            }

            Console.WriteLine();


            Console.ReadLine();
        }

        //public void PrintStack(EasyStack<T> easyStack)
        //{
        //    foreach (var item in easyStack)
        //    {
        //        Console.Write(item + " ");
        //    }

        //    Console.WriteLine();
        //}
            
    }
}
