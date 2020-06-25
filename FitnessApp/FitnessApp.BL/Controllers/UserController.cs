using FitnessApp.BL.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace FitnessApp.BL.Controllers
{
    /// <summary>
    /// Контроллер пользователя.
    /// </summary>
    public class UserController
    {
        /// <summary>
        /// Список пользователей приложения.
        /// </summary>
        public List<User> Users { get; }

        /// <summary>
        /// Текущий пользователь.
        /// </summary>
        public User CurrentUser { get; }

        /// <summary>
        /// Создание нового контроллера пользователя.
        /// </summary>
        /// <param name="user"> Пользователь. </param>
        public UserController(string userName)
        {
            if (string.IsNullOrWhiteSpace(userName))
                throw new ArgumentNullException("Имя пользователя не может быть пустым.", nameof(userName));

            Users = GetUsersData();

            CurrentUser = Users.SingleOrDefault(x=>x.Name == userName);
        }

        /// <summary>
        /// Создание нового контроллера пользователя.
        /// </summary>
        /// <param name="user"> Пользователь. </param>
        public UserController(string name, string nameGender, DateTime birthDate, double weight, double height)
        {
            var gender = new Gender(nameGender);
            var user = new User(name, gender, birthDate, weight, height);

            Users.Add(user ?? throw new ArgumentNullException("Пользователь не может быть равен NULL.", nameof(user)));
        }

        /// <summary>
        /// Сохранение пользователя в файл.
        /// </summary>
        public void Save()
        {
            var binFormatter = new BinaryFormatter();

            using (var file = new FileStream("users.bin", FileMode.OpenOrCreate))
            {
                binFormatter.Serialize(file, Users);
            }
        }

        /// <summary>
        /// Получаем список пользователей из файла.
        /// </summary>
        /// <returns> Пользователь. </returns>
        private List<User> GetUsersData()
        {
            var binFormatter = new BinaryFormatter();

            using (var file = new FileStream("users.bin", FileMode.Open))
            {
                return binFormatter.Deserialize(file) as List<User>;
            }

            return new List<User>();

            // TODO: Что делать, если пользователя не прочитали?
        }
    }
}
