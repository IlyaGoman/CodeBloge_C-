﻿using System;
using System.CodeDom;
using System.Collections.Generic;

namespace FitnessApp.BL.Model
{
    /// <summary>
    /// Продукт
    /// </summary>
    [Serializable]
    public class Food
    {
        public int Id { get; set; }
        /// <summary>
        /// Имя продукта
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Белки
        /// </summary>
        public double Proteins { get; }
        
        /// <summary>
        /// Жиры
        /// </summary>
        public double Fats { get; }

        /// <summary>
        /// Углеводы
        /// </summary>
        public double Carbohydrates { get; }

        /// <summary>
        /// Калории за 100гр продукта
        /// </summary>
        public double Calories { get; }

        public virtual ICollection<Eating> Eatings { get; set; }

        public Food()
        {

        }

        public Food(string name) : this(name, 0, 0, 0, 0)
        {
        }

        public Food(string name, double proteins, double fats, double carbohydrates, double calories)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException("Имя не может быть пустым.", nameof(name));
            }

            // TODO: Проверки
            Name = name;
            Proteins = proteins / 100.0;
            Fats = fats / 100.0;
            Carbohydrates = carbohydrates / 100.0;
            Calories = calories / 100.0;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
