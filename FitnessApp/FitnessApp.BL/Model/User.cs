using System;

namespace FitnessApp.BL.Model
{
    public class User
    {

        public string Name { get; }
        public Gender Gender { get; }

        public DateTime BirthDate { get; set; }

        public double Weight { get; set; }

        public double Height { get; set; }

        public User(string name, Gender gender, DateTime birthDate, double weight, double height)
        {
            #region checked
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
