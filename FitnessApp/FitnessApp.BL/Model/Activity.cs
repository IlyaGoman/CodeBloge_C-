using System;
using System.Collections.Generic;
using System.Data.Odbc;

namespace FitnessApp.BL.Model
{
    [Serializable]
    public class Activity
    {
        public int Id { get; set; }
        /// <summary>
        /// Наименование активности
        /// </summary>
        public string Name { get; set; }

        public virtual ICollection<Exercise> Exersices { get; set; }

        /// <summary>
        /// Расход калорий за одну минуту
        /// </summary>
        public double CaloriesPerMinute { get; set; }

        public Activity()
        {

        }

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
