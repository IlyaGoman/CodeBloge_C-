using FitnessApp.BL.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;

namespace FitnessApp.BL.Controllers
{
    [Serializable]
    public class EatingController : ControllerBase<Eating>
    {
        private const string EATINGS_FILE_NAME = "eatings.bin";
        private const string FOODS_FILE_NAME = "foods.bin";
        /// <summary>
        /// Пользователь
        /// </summary>
        private readonly User user;

        /// <summary>
        /// Список продуктов
        /// </summary>
        public List<Food> Foods { get; }

        /// <summary>
        /// Прием пищи
        /// </summary>
        public Eating Eating { get; }

        /// <summary>
        /// Создание нового контроллера приема пищи
        /// </summary>
        /// <param name="user"> Пользователь. </param>
        public EatingController(User user)
        {
            this.user = user ?? throw new ArgumentNullException("Не может отсутствовать пользователь.", nameof(user));
            Foods = GetAllFoods();
            Eating = GetEating();
        }

        /// <summary>
        /// Добавление нового продукта/занесение в прием пищи
        /// </summary>
        /// <param name="food"></param>
        /// <param name="weight"></param>
        public void Add(Food food, double weight)
        {
            var product = Foods.SingleOrDefault(x => x.Name == food.Name);
            if(product ==null)
            {
                Foods.Add(food);
                Eating.Add(food, weight);
            }
            else
            {
                Eating.Add(food, weight);
            }
            Save();
        }

        /// <summary>
        /// Получение списка съеденной еды.
        /// </summary>
        /// <returns></returns>
        private Eating GetEating()
        {
            return Load().First();
        }

        /// <summary>
        /// Получение списка продуктов
        /// </summary>
        /// <returns></returns>
        private List<Food> GetAllFoods()
        {
            return Load();
        }

        /// <summary>
        /// Сохранение списка продуктов
        /// </summary>
        private void Save()
        {
            Save();
        }

        public override string ToString()
        {
            return $"В {Eating.Moment} пользователь {user.Name} съел {Foods.Count} продуктов.";
        }
    }
}
