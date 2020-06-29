using System;
using System.Data.Odbc;

namespace FitnessApp.BL.Model
{
    public class Activity
    {
        /// <summary>
        /// Наименование активности
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Расход калорий за одну минуту
        /// </summary>
        public double CaloriesPerMinute { get; }

        public Activity(string name, double caloriesPerMinute)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException("Наименование активности не может быть пустым.", nameof(name));
            }

            if (caloriesPerMinute<0)
            {
                throw new ArgumentException("Расход калорий не может быть отрицательным.", nameof(caloriesPerMinute));
            }

            Name = name;
            CaloriesPerMinute = caloriesPerMinute;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
