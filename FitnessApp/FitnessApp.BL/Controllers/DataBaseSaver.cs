using FitnessApp.BL.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FitnessApp.BL.Controllers
{
    public class DataBaseSaver : IDataSaver
    {
        public List<T> Load<T>() where T : class
        {
            using (var db = new FitnessContext())
            {
                return db.Set<T>()
                    .Where(k => true)
                    .ToList();
            }
        }

        public void Save<T>(List<T> obj) where T : class
        {

            using (var db = new FitnessContext())
            {
                db.Set<T>().AddRange(obj);

                #region if-else
                //var type = typeof(T);
                //if (type == typeof(User))
                //{
                //    db.Users.Add(obj as User);
                //}
                //else if (type == typeof(Activity))
                //{
                //    db.Activities.Add(obj as Activity);
                //}
                //else if (type == typeof(Exercise))
                //{
                //    db.Exercisies.Add(obj as Exercise);
                //}
                //else if (type == typeof(Eating))
                //{
                //    db.Eating.Add(obj as Eating);
                //}
                //else if (type == typeof(Food))
                //{
                //    db.Foods.Add(obj as Food);
                //}
                //else if (type == typeof(Gender))
                //{
                //    db.Gender.Add(obj as Gender);
                //}
                #endregion

                db.SaveChanges();
            }
        }
    }
}
