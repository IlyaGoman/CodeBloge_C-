using FitnessApp.BL.Controllers;
using FitnessApp.BL.Model;
using FitnessApp.CMD.Languages;
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
            Console.WriteLine(Ru_Ru_Resource.Hello);

            Console.Write(Ru_Ru_Resource.InputName);
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

            var eatingController = new EatingController(userController.CurrentUser);

            Console.WriteLine("Выберете действие:");
            Console.WriteLine("E - ввести прием пищи");
            var inputKey = Console.ReadKey();
            Console.WriteLine();

            switch (inputKey.Key)
            { 
                case ConsoleKey.E:
                    {
                        var weightFood = 0.0;
                        var food = FillEating(out weightFood);
                        eatingController.Add(food, weightFood);
                        break;
                    }
                default:
                    Console.WriteLine("Введена неверная команда!");
                    break;
            }

            Console.WriteLine();
            Console.WriteLine(eatingController.ToString());
            foreach (var food in eatingController.Eating.Foods)
            {
                Console.WriteLine($"{food.Key} - {food.Value}");
            }


            Console.ReadLine();
        }

        private static Food FillEating(out double weightFood)
        {
            Console.WriteLine("Введите наименование продукта: ");
            var foodName = Console.ReadLine();

            var calories = ParseInput<double>("Введите калорийность продукта(кКал): ");
            var proteins = ParseInput<double>("Введите содержание белков(г): ");
            var fats = ParseInput<double>("Введите содержание жиров(г): ");
            var carbohydrates = ParseInput<double>("Введите содержание углеводов(г): ");

            weightFood = ParseInput<double>("Введите вес продукта(г): ");

            return new Food(foodName, proteins, fats, carbohydrates, calories);
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
