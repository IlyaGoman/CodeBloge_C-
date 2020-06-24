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
        /// Пользователь.
        /// </summary>
        public User User { get; }

        /// <summary>
        /// Создание нового контроллера пользователя.
        /// </summary>
        /// <param name="user"> Пользователь. </param>
        public UserController(User user)
        {
            User = user ?? throw new ArgumentNullException("Пользователь не может быть равен NULL.", nameof(user));
        }

        /// <summary>
        /// Сохранение пользователя в файл.
        /// </summary>
        public void Save()
        {
            var binFormatter = new BinaryFormatter();

            using (var file = new FileStream("users.bin", FileMode.OpenOrCreate))
            {
                binFormatter.Serialize(file, User);
            }
        }

        /// <summary>
        /// Получить пользователя из файла.
        /// </summary>
        /// <returns> Пользователь. </returns>
        public UserController()
        {
            var binFormatter = new BinaryFormatter();

            using (var file = new FileStream("users.bin", FileMode.Open))
            {
                User = binFormatter.Deserialize(file) as User;
            }

            // TODO: Что делать, если пользователя не прочитали?
        }
    }
}
