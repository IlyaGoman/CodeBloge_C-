using System;

namespace LinkedListApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            var duplexList = new DuplexLinkedList<int>();

            duplexList.Add(1);
            duplexList.Add(2);
            duplexList.Add(3);
            duplexList.Add(4);
            duplexList.Add(5);

            foreach (var item in duplexList)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();

            Console.ReadLine();
        }
    }
}
