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
            if(CurrentUser == null)
            {
                CurrentUser = new User(userName);
                Users.Add(CurrentUser);
                Save();
            }
        }

        /// <summary>
        /// Создание нового контроллера пользователя.
        /// </summary>
        /// <param name="user"> Пользователь. </param>
        public UserController(string name, string nameGender, DateTime birthDate, double weight, double height)
        {
            var gender = new Gender(nameGender);
            var user = new User(name, gender, birthDate, weight, height);

            Users.Add(user);
            Save();
        }

        /// <summary>
        /// Сохранение пользователя в файл.
        /// </summary>
        private void Save()
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

            using (var file = new FileStream("users.bin", FileMode.OpenOrCreate))
            {
                // TODO: Если файл с данными не существует, то вылетает ArgumentNullException на пустой поток для Deserialize.
                //try
                //{
                if (binFormatter.Deserialize(file) is List<User> users)
                {
                    return users;
                }
                //}
                //    catch (Exception)
                //    {


                //    }
            }

            return new List<User>();
        }
    }
}
