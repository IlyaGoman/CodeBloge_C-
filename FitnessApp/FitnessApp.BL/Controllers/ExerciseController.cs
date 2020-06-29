using FitnessApp.BL.Model;
using System;

namespace FitnessApp.BL.Controllers
{
    [Serializable]
    public class ExerciseController: ControllerBase
    {
        private readonly User user;

        public ExerciseController(User user)
        {
            this.user = user ?? throw new ArgumentNullException("Пользователь не может быть пустым.", nameof(user)); ;
        }
    }
}
