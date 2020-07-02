using System;
using System.Collections.Generic;
using System.Linq;

namespace FitnessApp.BL.Model
{
    /// <summary>
    /// Прием пищи.
    /// </summary>
    [Serializable]
    public class Eating
    {
        public int Id { get; set; }
        /// <summary>
        /// Время приема пищи 
        /// </summary>
        public DateTime Moment { get; }

        /// <summary>
        /// Список съеденных продуктов
        /// </summary>
        public Dictionary<Food, double> Foods { get; }

        public int UserId { get; set; }
        /// <summary>
        /// Пользователь, который принимал пищу.
        /// </summary>
        public virtual User User { get; }

        public Eating()
        {

        }

        public Eating(User user)
        {
            User = user ?? throw new ArgumentNullException("Не может отсутствовать пользователь.", nameof(user));
            Moment = DateTime.UtcNow;
            Foods = new Dictionary<Food, double>();
        }


        /// <summary>
        /// Добавление продукта в список
        /// </summary>
        /// <param name="food"> Продукт </param>
        /// <param name="weight"> Вес продукта </param>
        public void Add(Food food, double weight)
        {
            var product = Foods.Keys.FirstOrDefault(f => f.Name == food.Name);
            if(product == null)
            {
                Foods.Add(food, weight);
            }
            else
            {
                Foods[product] += weight;
            }
        }
    }
}
