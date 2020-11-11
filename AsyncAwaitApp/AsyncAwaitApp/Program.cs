using System;
using System.Threading;
using System.Threading.Tasks;

namespace AsyncAwaitApp
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Thread
            //Thread thread = new Thread(new ThreadStart(DoWork));
            //thread.Start();

            //Thread thread2 = new Thread(new ParameterizedThreadStart(DoWork));
            //thread2.Start(int.MaxValue);

            //int j = 0;
            //for (int i = 0; i < int.MaxValue; i++)
            //{
            //    j++;

            //    if (i % 100000000 == 0)
            //        Console.WriteLine("Main");
            //} 
            #endregion

            DoWorkAsync();

            Console.WriteLine("Main is working!");

            Console.ReadKey();
        }

        static async Task DoWorkAsync()
        {
            await Task.Run(() => DoWork());
            Console.WriteLine("DoWorkAsync completed!");
        }

        static void DoWork()
        {
            int j = 0;
            for (int i = 0; i < int.MaxValue; i++)
            {
                j++;

                if(j % 100000000 == 0)
                    Console.WriteLine("DoWork()");
            }
        }

        static void DoWork(object max)
        {
            if (max is int)
            {
                int j = 0;
                for (int i = 0; i < (int)max; i++)
                {
                    j++;

                    if (j % 100000000 == 0)
                        Console.WriteLine($"DoWork({i})");
                }
            }
        }
    }
}
