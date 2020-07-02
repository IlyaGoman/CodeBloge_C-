using System;

namespace FitnessApp.BL.Model
{
    [Serializable]
    public class Exercise
    {
        public int Id { get; set; }

        private DateTime start;
        private DateTime finish;
        /// <summary>
        /// Время начала выполнения упражнения
        /// </summary>
        public DateTime Start 
        { 
            get => start; 
            private set
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
        public DateTime Finish
        {
            get => finish;
            private set
            {
                if (value <= Start || value >= DateTime.Now)
                {
                    throw new ArgumentException("Время окончания выполнения упражнения не может быть меньше начала выполнения или даты рождения пользователя.", nameof(finish));
                }

                finish = value;
            }
        }

        public int ActivityId { get; set; }
        /// <summary>
        /// Вид активности
        /// </summary>
        public virtual Activity Activity { get; set; }

        public int UserId { get; set; }
        /// <summary>
        /// Пользователь
        /// </summary>
        public virtual User User { get; set; }

        public Exercise()
        {

        }
        public Exercise(DateTime start, DateTime finish, Activity activity, User user)
        {
            User = user ?? throw new ArgumentNullException("Пользователь не может быть пустым", nameof(user));
            Start = start;
            Finish = finish;
            Activity = activity ?? throw new ArgumentNullException("Активность не может быть пустым", nameof(activity));
        }

        public double GetExpensiveCalories()
        {
            return Activity.CaloriesPerMinute * ((TimeSpan)(Finish - Start)).TotalMinutes;
        }
    }
}
