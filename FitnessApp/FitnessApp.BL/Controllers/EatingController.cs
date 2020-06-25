﻿using FitnessApp.BL.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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

        public Eating Eating { get; }

        public EatingController(User user)
        {
            this.user = user ?? throw new ArgumentNullException("Не может отсутствовать пользователь.", nameof(user));
            Foods = GetAllFoods();
            Eating = GetEating();
        }

        public bool AddEating(string foodName, double weight)
        {
            var food = Foods.SingleOrDefault(x=>x.Name == foodName);
            if(Eating != null)
            {
                Eating.Add(food, weight);
                Save();
                return true;
            }
            return false;
        }

        public void Add(Food food, double weight)
        {
            var product = Foods.SingleOrDefault(x => x.Name == food.Name);
            if(product ==null)
            {
                Foods.Add(food);
                Eating.Add(food, weight);
                Save();
            }
        }

        /// <summary>
        /// Получение списка съеденной еды.
        /// </summary>
        /// <returns></returns>
        private Eating GetEating()
        {
            return Load<Eating>(EATINGS_FILE_NAME) ?? new Eating(user);
        }

        /// <summary>
        /// Получение списка продуктов
        /// </summary>
        /// <returns></returns>
        private List<Food> GetAllFoods()
        {
            return Load<List<Food>>(FOODS_FILE_NAME) ?? new List<Food>();
        }

        /// <summary>
        /// Сохранение списка продуктов
        /// </summary>
        private void Save()
        {
            base.Save(FOODS_FILE_NAME, Foods);
            base.Save(EATINGS_FILE_NAME, Eating);
        }

    }
}
