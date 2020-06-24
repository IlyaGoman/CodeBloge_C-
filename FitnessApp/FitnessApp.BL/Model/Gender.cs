using System;

namespace FitnessApp.BL.Model
{
    /// <summary>
    /// Пол.
    /// </summary>
    public class Gender
    {
        /// <summary>
        /// Наименование пола.
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Создание пола
        /// </summary>
        /// <param name="name">Наименование</param>
        public Gender(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentNullException("Пол не может быть пустым или null!", nameof(name));
            Name = name;
        }

       /// <summary>
       /// 
       /// </summary>
       /// <returns></returns>
        public override string ToString()
        {
            return Name;
        }
    }
}
