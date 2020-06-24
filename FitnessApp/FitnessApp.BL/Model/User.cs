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
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException("Имя не может быть пустым.", nameof(name));
            }

            if(gender == null)
            {
                throw new ArgumentNullException("Пол не может быть пустым.", nameof(gender));
            }

            if(birthDate <= DateTime.Parse("01.01.1900"))
            {
                throw new ArgumentNullException("Дата рождения не может быть меньше 01.01.1900.", nameof(birthDate));
            }

            if (weight<=0)
            {
                throw new ArgumentNullException("Вес не может быть меньше 0.", nameof(weight));
            }

            if (height<=0)
            {
                throw new ArgumentNullException("Рост не может быть меньше 0.", nameof(weight));
            }

            Name = name;
            Gender = gender;
            BirthDate = birthDate;
            Weight = weight;
            Height = height;
        }
    }
}
