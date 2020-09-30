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
            //var easyQueue = new EasyQueue<int>();

            //easyQueue.Enqueue(1);
            //easyQueue.Enqueue(2);
            //easyQueue.Enqueue(3);
            //easyQueue.Enqueue(4);
            //easyQueue.Enqueue(5);

            //PrintQueue(easyQueue);

            //Console.WriteLine(easyQueue.Dequeue());
            //Console.WriteLine(easyQueue.Dequeue());
            //Console.WriteLine(easyQueue.Dequeue());
            //Console.WriteLine(easyQueue.Peek());

            //PrintQueue(easyQueue);

            //Console.ReadLine();

            var arrayQueue = new ArrayQueue<int>(5);

            arrayQueue.Enqueue(1);
            arrayQueue.Enqueue(2);
            arrayQueue.Enqueue(3);
            arrayQueue.Enqueue(4);
            arrayQueue.Enqueue(5);

            PrintQueue(arrayQueue);

            Console.WriteLine(arrayQueue.Dequeue());
            Console.WriteLine(arrayQueue.Dequeue());
            Console.WriteLine(arrayQueue.Dequeue());
            Console.WriteLine(arrayQueue.Peek());

            PrintQueue(arrayQueue);

            Console.ReadLine();
        }

        static void PrintQueue(ArrayQueue<int> queue)
        {
            foreach (var item in queue)
            {
                Console.Write(item);
                Console.Write(" ");
            }

            Console.WriteLine();
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
