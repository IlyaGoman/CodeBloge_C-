﻿using FitnessApp.BL.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace FitnessApp.BL.Controllers
{
    public class EatingController : ControllerBase
    {
        private const string EATINGS_FILE_NAME = "eatings.bin";
        private const string FOODS_FILE_NAME = "foods.bin";
        /// <summary>
        /// Пользователь
        /// </summary>
        private readonly User user;
        public List<Food> Foods { get; }

        public EatingController(User user)
        {
            this.user = user ?? throw new ArgumentNullException("Не может отсутствовать пользователь.", nameof(user));
            Foods = GetAllFoods();
        }

        /// <summary>
        /// Получение списка продуктов
        /// </summary>
        /// <returns></returns>
        private List<Food> GetAllFoods()
        {
            return Load<Food>(FOODS_FILE_NAME);
        }

        /// <summary>
        /// Сохранение списка продуктов
        /// </summary>
        private void Save()
        {
            Save(FOODS_FILE_NAME, Foods);
        }

    }
}
