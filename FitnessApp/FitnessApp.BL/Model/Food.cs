using System;

namespace FitnessApp.BL.Model
{
    /// <summary>
    /// Продукт
    /// </summary>
    public class Food
    {
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
        public double Calories1 { get; }

        /// <summary>
        /// Калории за 100гр продукта
        /// </summary>
        public int Calories { get; }

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
            Name = Name;
            Proteins = proteins / 100.0;
            Fats = fats / 100.0;
            Carbohydrates = carbohydrates / 100.0;
            Calories1 = calories / 100.0;
        }
    }
}
