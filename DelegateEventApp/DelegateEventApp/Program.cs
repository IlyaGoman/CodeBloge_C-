using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegateEventApp
{
    public delegate void MyDelegate(String message);
    

    public class Car
    {
        public event MyDelegate DisplayInfo;

        public void Move()
        {
            DisplayInfo?.Invoke("Car is moving!");
        }

        public void Stop()
        {
            DisplayInfo?.Invoke("Car is stopping!");
        }

    }

    class Program
    {
        static void Main(string[] args)
        {
            Car car = new Car();

            Action<string> action = DisplayMessage;

            action?.Invoke("TestString");

            car.DisplayInfo += DisplayMessage;
            car.Move();

            Console.ReadKey();
        }

        private static void DisplayMessage(string message)
        {
            Console.WriteLine(message);
        }
    }
}
