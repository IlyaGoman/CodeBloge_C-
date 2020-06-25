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
    public class UserController : ControllerBase
    {
        private const string USERS_FILE_PATH = "users.bin";

        #region Свойства
        /// <summary>
        /// Список пользователей приложения.
        /// </summary>
        public List<User> Users { get; }

        /// <summary>
        /// Текущий пользователь.
        /// </summary>
        public User CurrentUser { get; }

        /// <summary>
        /// Флаг, указывающий новый ли это пользователь.
        /// </summary>
        public bool IsNewUser { get; } = false; 
        #endregion

        /// <summary>
        /// Создание нового контроллера пользователя.
        /// </summary>
        /// <param name="user"> Пользователь. </param>
        public UserController(string userName)
        {
            if (string.IsNullOrWhiteSpace(userName))
                throw new ArgumentNullException("Имя пользователя не может быть пустым.", nameof(userName));

            Users = GetAllUsers();

            CurrentUser = Users.SingleOrDefault(x=>x.Name == userName);
            if(CurrentUser == null)
            {
                CurrentUser = new User(userName);
                Users.Add(CurrentUser);
                IsNewUser = true;
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
        /// Запрашиваем и сохраняем информацию о новом пользователе.
        /// </summary>
        /// <param name="genderName"></param>
        /// <param name="birthDate"></param>
        /// <param name="weight"></param>
        /// <param name="height"></param>
        public void SetUserData(string genderName, DateTime birthDate, double weight = 1, double height=1)
        {
            CurrentUser.Gender = new Gender(genderName);
            CurrentUser.BirthDate = birthDate;
            CurrentUser.Weight = weight;
            CurrentUser.Height = height;

            Save();
        }

        /// <summary>
        /// Сохранение пользователя в файл.
        /// </summary>
        private void Save()
        {
            Save<User>(USERS_FILE_PATH, Users);
        }

        /// <summary>
        /// Получаем список пользователей из файла.
        /// </summary>
        /// <returns> Пользователь. </returns>
        public List<User> GetAllUsers()
        {
            return Load<User>(USERS_FILE_PATH);
        }
    }
}
