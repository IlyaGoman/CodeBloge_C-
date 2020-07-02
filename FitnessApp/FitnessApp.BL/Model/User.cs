using System;
using System.Collections.Generic;

namespace FitnessApp.BL.Model
{
    /// <summary>
    /// Пользователь.
    /// </summary>
    [Serializable]
    public class User
    {
        public int Id { get; set; }
        private Gender gender;
        private DateTime birthDate;
        private double weight;
        private double height;

        #region Свойства
        /// <summary>
        /// Имя пользователя.
        /// </summary>
        public string Name { get; }

        public int? GenderId { get; set; }
        /// <summary>
        /// Пол пользователя.
        /// </summary>
        public virtual Gender Gender
        {
            get => gender;
            set => gender = value ?? throw new ArgumentNullException("Пол не может быть пустым.", nameof(gender));
        }

        /// <summary>
        /// Дата рождения.
        /// </summary>
        public DateTime BirthDate
        {
            get => birthDate;
            set
            {
                if (value <= DateTime.Parse("01.01.1900") || value >= DateTime.Now)
                {
                    throw new ArgumentException("Дата рождения не может быть меньше 01.01.1900.", nameof(birthDate));
                }

                birthDate = value;
            }
        }

        /// <summary>
        /// Вес пользователя.
        /// </summary>
        public double Weight
        {
            get => weight;
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Вес не может быть меньше 0.", nameof(weight));
                }

                weight = value;
            }
        }

        /// <summary>
        /// Рост пользователя.
        /// </summary>
        public double Height 
        { 
            get => height;
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Рост не может быть меньше 0.", nameof(height));
                }

                height = value;
            }
        }

        /// <summary>
        /// Вычисляет возраст пользователя.
        /// </summary>
        public int Age
        {
            get
            {
                var diffYear = DateTime.Now.Year - BirthDate.Year;
                return BirthDate.AddYears(diffYear) < DateTime.Now ? diffYear - 1 : diffYear;
            }
        }

        public ICollection<Eating> Eatings { get; set; }

        public ICollection<Exercise> Exercises { get; set; }

        #endregion

        public User()
        {

        }

        public User(string userName)
        {
            if (string.IsNullOrWhiteSpace(userName))
            {
                throw new ArgumentNullException("Имя не может быть пустым.", nameof(userName));
            }

            Name = userName;
        }

        /// <summary>
        /// Создание нового пользователя.
        /// </summary>
        /// <param name="userName"> Имя </param>
        /// <param name="gender"> Пол </param>
        /// <param name="birthDate"> Дата рождения </param>
        /// <param name="weight"> Вес </param>
        /// <param name="height"> Рост </param>
        public User(string userName, Gender gender, DateTime birthDate, double weight, double height)
        {
            #region Проверка входных параметров
            if (string.IsNullOrWhiteSpace(userName))
            {
                throw new ArgumentNullException("Имя не может быть пустым.", nameof(userName));
            }
            #endregion

            Name = userName;
            Gender = gender ?? throw new ArgumentNullException("Пол не может быть пустым.", nameof(gender));
            BirthDate = birthDate;
            Weight = weight;
            Height = height;
        }

        public override string ToString()
        {
            return $"UserName: {Name}, gender: {Gender}, age: {Age}, birthDate: {BirthDate}, weight: {Weight}kg, height: {Height}cm";
        }
    }
}
