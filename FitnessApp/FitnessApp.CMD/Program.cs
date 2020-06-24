using FitnessApp.BL.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessApp.CMD
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Вас приветствует приложение FitnessApp");
            Console.Write("Введите имя пользователя");

            var name = Console.ReadLine();

            Console.WriteLine();
            Console.Write("Введите пол пользователя");
            var gender = Console.ReadLine();

            // TODO: Добавить проверки
            Console.WriteLine();
            Console.Write("Введите дату рождения пользователя");
            var birthDate = DateTime.Parse(Console.ReadLine());

            Console.WriteLine();
            Console.Write("Введите вес пользователя");
            var weight = double.Parse(Console.ReadLine());

            Console.WriteLine();
            Console.Write("Введите рост пользователя");
            var height = double.Parse(Console.ReadLine());

            var userController = new UserController(name, gender, birthDate, weight, height);
            userController.Save();

            Console.ReadLine();
        }
    }
}
