using System;

namespace FitnessApp.BL.Model
{
    /// <summary>
    /// Пользователь.
    /// </summary>
    public class User
    {
        #region Свойства
        /// <summary>
        /// Имя пользователя.
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Пол пользователя.
        /// </summary>
        public Gender Gender { get; }

        /// <summary>
        /// Дата рождения.
        /// </summary>
        public DateTime BirthDate { get; set; }

        /// <summary>
        /// Вес пользователя.
        /// </summary>
        public double Weight { get; set; }

        /// <summary>
        /// Рост пользователя.
        /// </summary>
        public double Height { get; set; }

        #endregion
        /// <summary>
        /// Создание нового пользователя.
        /// </summary>
        /// <param name="name">Имя</param>
        /// <param name="gender">Пол</param>
        /// <param name="birthDate">Дата рождения</param>
        /// <param name="weight">Вес</param>
        /// <param name="height">Рост</param>
        public User(string name, Gender gender, DateTime birthDate, double weight, double height)
        {
            #region Проверка входных параметров
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException("Имя не может быть пустым.", nameof(name));
            }

            if (birthDate <= DateTime.Parse("01.01.1900") || birthDate>=DateTime.Now)
            {
                throw new ArgumentException("Дата рождения не может быть меньше 01.01.1900.", nameof(birthDate));
            }

            if (weight<=0)
            {
                throw new ArgumentException("Вес не может быть меньше 0.", nameof(weight));
            }

            if (height<=0)
            {
                throw new ArgumentException("Рост не может быть меньше 0.", nameof(height));
            }
            #endregion

            Name = name;
            Gender = gender ?? throw new ArgumentNullException("Пол не может быть пустым.", nameof(gender));
            BirthDate = birthDate;
            Weight = weight;
            Height = height;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
