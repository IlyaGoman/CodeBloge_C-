using FitnessApp.BL.Controllers;
using FitnessApp.BL.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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

            Console.Write("Введите имя пользователя: ");
            var userNme = Console.ReadLine();

            var userController = new UserController(userNme);

            if(userController.IsNewUser)
            {
                Console.WriteLine();
                Console.Write("Введите пол пользователя: ");
                var gender = Console.ReadLine();

                var birthDate = ParseInput<DateTime>("Введите дату рождения пользователя (dd.MM.yyyy): ");

                var weight = ParseInput<double>("Введите вес пользователя(кг): ");

                var height = ParseInput<double>("Введите рост пользователя(см): ");

                userController.SetUserData(gender, birthDate, weight, height);
            }

            Console.WriteLine(userController.CurrentUser);
            Console.ReadLine();
        }

        private static T ParseInput<T>(string message)
        {
            T result;
            Console.WriteLine();
            Console.Write(message);
            while (!Helper.TryParse<T>(Console.ReadLine(), out result))
            {
                Console.WriteLine("Неверный формат ввода!");
                Console.Write(message);
            }
            

            return result;
        }

        //public static void CreateUser(string name)
        //{
        //    Console.WriteLine();
        //    Console.Write("Введите пол пользователя: ");
        //    var gender = Console.ReadLine();

        //    Console.WriteLine();
        //    Console.Write("Введите дату рождения пользователя: ");
        //    var birthDate = DateTime.Parse(Console.ReadLine());

        //    Console.WriteLine();
        //    Console.Write("Введите вес пользователя(кг): ");
        //    var weight = double.Parse(Console.ReadLine());

        //    Console.WriteLine();
        //    Console.Write("Введите рост пользователя(см): ");
        //    var height = double.Parse(Console.ReadLine());

        //    var userController = new UserController(name, gender, birthDate, weight, height);
        //    userController.Save();

        //}

        //public static bool IsExistsUser(string name)
        //{
        //    var userController = new UserController();

        //    if (userController.User.Name == name)
        //    {
        //        Console.WriteLine("Добро пожаловать.Вы вошли как:");
        //        Console.WriteLine(userController.User);
        //        return true;
        //    }

        //    return false;
        //}
    }
}
