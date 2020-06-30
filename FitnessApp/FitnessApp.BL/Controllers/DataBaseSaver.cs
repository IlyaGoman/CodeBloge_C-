using FitnessApp.BL.Model;
using System;

namespace FitnessApp.BL.Controllers
{
    public class DataBaseSaver : IDataSaver
    {
        public T Load<T>(string fileName)
        {
            throw new NotImplementedException();
        }

        public void Save<T>(string fileName, T obj)
        {

            using (var db = new FitnessContext())
            {
                var type = typeof(T);
                if(type == typeof(User))
                {
                    db.Users.Add(obj as User);
                }
                else if (type == typeof(Activity))
                {
                    db.Activities.Add(obj as Activity);
                }
                else if (type == typeof(Exercise))
                {
                    db.Exercisies.Add(obj as Exercise);
                }
                else if (type == typeof(Eating))
                {
                    db.Eating.Add(obj as Eating);
                }
                else if (type == typeof(Food))
                {
                    db.Foods.Add(obj as Food);
                }
                else if (type == typeof(Gender))
                {
                    db.Gender.Add(obj as Gender);
                }
            }
        }
    }
}
