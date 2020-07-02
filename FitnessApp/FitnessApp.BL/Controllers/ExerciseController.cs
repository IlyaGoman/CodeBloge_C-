using FitnessApp.BL.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FitnessApp.BL.Controllers
{
    [Serializable]
    public class ExerciseController: ControllerBase
    {

        private readonly User user;

        public List<Activity> Activities { get; set; }

        public List<Exercise> Exercises { get; set; }

        public ExerciseController(User user)
        {
            this.user = user ?? throw new ArgumentNullException("Пользователь не может быть пустым.", nameof(user));

            Exercises = GetExercises();
            Activities = GetActivities();
        }

        /// <summary>
        /// Добавление активности в список
        /// </summary>
        /// <param name="activityName"></param>
        /// <param name="begin"></param>
        /// <param name="end"></param>
        /// <param name=""></param>
        public void Add(Activity activity, DateTime begin, DateTime end)
        {
            var act = Activities.SingleOrDefault(x => x.Name == activity.Name);
            if (act == null)
            {
                Activities.Add(activity);

                var exersice = new Exercise(begin, end, activity, user);
                Exercises.Add(exersice);
            }
            else
            {
                var exersice = new Exercise(begin, end, act, user);
                Exercises.Add(exersice);
            }
            Save();
        }

        /// <summary>
        /// Получение списка упражнений пользователя
        /// </summary>
        /// <returns></returns>
        private List<Exercise> GetExercises()
        {
            return Load<Exercise>() ?? new List<Exercise>();
        }

        /// <summary>
        /// Получение списка активностей пользователя
        /// </summary>
        /// <returns></returns>
        private List<Activity> GetActivities()
        {
            return Load<Activity>() ?? new List<Activity>();
        }

        /// <summary>
        /// Сохранение списка упражнений
        /// </summary>
        private void Save()
        {
            Save(Exercises);
            Save(Activities);
        }

        public override string ToString()
        {
            return $"Пользователь {user.Name} выполнил {Exercises.Count} упражнений.";
        }
    }
}
