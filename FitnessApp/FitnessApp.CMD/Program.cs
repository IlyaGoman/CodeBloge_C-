using FitnessApp.BL.Controllers;
using FitnessApp.BL.Model;
using FitnessApp.CMD.Languages;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;

namespace FitnessApp.CMD
{
    class Program
    {
        static void Main(string[] args)
        {
            Random rnd = new Random();

            var culture = CultureInfo.CreateSpecificCulture("en-us");
            var resourcesManager = new ResourceManager("FitnessApp.CMD.Languages.Messages", typeof(Program).Assembly);

            Console.WriteLine(resourcesManager.GetString("Hello", culture));

            Console.Write(resourcesManager.GetString("InputName", culture));
            var userNme = Console.ReadLine();

            var userController = new UserController(userNme);

            if(userController.IsNewUser)
            {
                Console.WriteLine();
                Console.Write(resourcesManager.GetString("InputGender", culture));
                var gender = Console.ReadLine();

                var birthDate = ParseInput<DateTime>("Введите дату рождения пользователя (dd.MM.yyyy): ");

                var weight = ParseInput<double>("Введите вес пользователя(кг): ");

                var height = ParseInput<double>("Введите рост пользователя(см): ");

                userController.SetUserData(gender, birthDate, weight, height);
            }

            Console.WriteLine(userController.CurrentUser);

            var eatingController = new EatingController(userController.CurrentUser);
            var exersiceController = new ExerciseController(userController.CurrentUser);

            Console.WriteLine("Выберете действие:");
            Console.WriteLine("E - ввести прием пищи");
            Console.WriteLine("A - ввести упражнение");

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
                case ConsoleKey.A:
                    {
                        var activity = FillActivity();
                        exersiceController.Add(activity, DateTime.Now.AddMinutes(rnd.Next(-10, -1)), DateTime.Now);
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

            Console.WriteLine();
            Console.WriteLine(exersiceController.ToString());
            foreach (var exersice in exersiceController.Exercises)
            {
                Console.WriteLine($"{exersice.User.Name} выполнил {exersice.Activity} за {exersice.Finish - exersice.Start} минут. Затратив {exersice.GetExpensiveCalories()} калорий.");
            }

            Console.ReadLine();
        }

        private static Activity FillActivity()
        {
            Console.Write("Введите наименование упражнения: ");
            var activityName = Console.ReadLine();

            var caloriesPerMinute = ParseInput<double>("Введите расход калорий(кКал): ");

            return new Activity(activityName, caloriesPerMinute);
        }

        private static Food FillEating(out double weightFood)
        {
            Console.Write("Введите наименование продукта: ");
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
    }
}
