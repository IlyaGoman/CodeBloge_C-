using System;
using System.Collections;
using System.Collections.Generic;

namespace FitnessApp.BL.Model
{
    /// <summary>
    /// Пол.
    /// </summary>
    [Serializable]
    public class Gender
    {
        public int Id { get; set; }
        /// <summary>
        /// Наименование пола.
        /// </summary>
        public string Name { get; set; }

        public ICollection<User> Users { get; set; }

        public Gender()
        {

        }
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
