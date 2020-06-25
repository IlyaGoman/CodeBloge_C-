using FitnessApp.BL.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace FitnessApp.BL.Controllers
{
    public class EatingController : ControllerBase
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
        private List<Food> Load()
        {
            return Load<Food>("foods.bin");
        }

        /// <summary>
        /// Сохранение списка продуктов
        /// </summary>
        private void Save()
        {
            Save<Food>("foods.bin", Foods);
        }

    }
}
