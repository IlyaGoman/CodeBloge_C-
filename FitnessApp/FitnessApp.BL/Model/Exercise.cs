using System;

namespace FitnessApp.BL.Model
{
    public class Exercise
    {
        private DateTime start;
        /// <summary>
        /// Время начала выполнения упражнения
        /// </summary>
        public DateTime Start 
        { 
            get => start; 
            set
            {
                if (value <= User.BirthDate || value >= DateTime.Now)
                {
                    throw new ArgumentException("Время начала выполнения упражнения не может быть меньше даты рождения пользователя.", nameof(start));
                }

                start = value;
            }
        }


        /// <summary>
        /// Время окончания выполнения упражнения
        /// </summary>
        public DateTime Finish { get; }

        /// <summary>
        /// Вид активности
        /// </summary>
        public Activity Activity { get; }

        /// <summary>
        /// Пользователь
        /// </summary>
        public User User { get; }

        public Exercise(DateTime start, DateTime finish, Activity activity, User user)
        {
            // TODO: Доделать проверки для Exercise

            User = user;
            Start = start;
            Finish = finish;
            Activity = activity;
        }
    }
}
