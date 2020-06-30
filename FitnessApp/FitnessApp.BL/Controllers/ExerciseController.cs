using FitnessApp.BL.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FitnessApp.BL.Controllers
{
    [Serializable]
    public class ExerciseController: ControllerBase
    {
        private const string EXERCISES_FILE_NAME = "exercises.bin";
        private const string ACTIVITIES_FILE_NAME = "activities.bin";

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
            return Load<List<Exercise>>(EXERCISES_FILE_NAME) ?? new List<Exercise>();
        }

        /// <summary>
        /// Получение списка активностей пользователя
        /// </summary>
        /// <returns></returns>
        private List<Activity> GetActivities()
        {
            return Load<List<Activity>>(ACTIVITIES_FILE_NAME) ?? new List<Activity>();
        }

        /// <summary>
        /// Сохранение списка упражнений
        /// </summary>
        private void Save()
        {
            base.Save(EXERCISES_FILE_NAME, Exercises);
            base.Save(ACTIVITIES_FILE_NAME, Activities);
        }

        public override string ToString()
        {
            return $"Пользователь {user.Name} выполнил {Exercises.Count} упражнений.";
        }
    }
}
