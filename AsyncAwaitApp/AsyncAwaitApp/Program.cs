using System;
using System.IO;
using System.Text;
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



            //var result = SaveToFile("async.txt");

            var result = SaveToFileAsync("async.txt");

            var inputText = Console.ReadLine();

            Console.WriteLine(result.Result);

            Console.WriteLine("Main is completed!");

            Console.ReadKey();
        }

        static async Task<bool> SaveToFileAsync(string path)
        {
            var result = await Task<bool>.Run(() => SaveToFile(path));

            Console.WriteLine("SaveToFileAsync completed!");
            return result;
        }
        static bool SaveToFile(string path)
        {
            var rnd = new Random();
            var text = "";
            for (int i = 0; i < 1000; i++)
            {
                text += rnd.Next(0, i);
            }

            using (StreamWriter sw = new StreamWriter(path, false, Encoding.UTF8))
            {
                sw.WriteLine(text);
            }

            return true;
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
