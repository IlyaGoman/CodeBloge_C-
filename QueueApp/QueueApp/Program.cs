using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;

namespace QueueApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var easyQueue = new EasyQueue<int>();

            easyQueue.Enqueue(1);
            easyQueue.Enqueue(2);
            easyQueue.Enqueue(3);
            easyQueue.Enqueue(4);
            easyQueue.Enqueue(5);

            PrintQueue(easyQueue);

            Console.WriteLine(easyQueue.Dequeue());
            Console.WriteLine(easyQueue.Dequeue());
            Console.WriteLine(easyQueue.Dequeue());
            Console.WriteLine(easyQueue.Peek());

            PrintQueue(easyQueue);

            Console.ReadLine();

        }

        static void PrintQueue(EasyQueue<int> queue)
        {
            foreach (var item in queue)
            {
                Console.Write(item);
                Console.Write(" ");
            }

            Console.WriteLine();
        }
    }
}
