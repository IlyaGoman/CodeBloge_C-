using FitnessApp.BL.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace FitnessApp.BL.Controllers
{
    public class EatingController
    {
        /// <summary>
        /// Пользователь
        /// </summary>
        private readonly User user;
        public List<Food> Foods { get; }

        public EatingController(User user)
        {
            this.user = user ?? throw new ArgumentNullException("Не может отсутствовать пользователь.", nameof(user));
        }

        /// <summary>
        /// Получение списка продуктов
        /// </summary>
        /// <returns></returns>
        private List<Food> GetAllFoods()
        {
            var binFormatter = new BinaryFormatter();

            using (var file = new FileStream("foods.bin", FileMode.OpenOrCreate))
            {
                if (file.Length > 0 && binFormatter.Deserialize(file) is List<Food> foods)
                {
                    return foods;
                }
            }

            return new List<Food>();
        }

        private void Save()
        {
            var binFormatter = new BinaryFormatter();

            using (var file = new FileStream("foods.bin", FileMode.OpenOrCreate))
            {
                binFormatter.Serialize(file, Foods);
            }
        }

    }
}
