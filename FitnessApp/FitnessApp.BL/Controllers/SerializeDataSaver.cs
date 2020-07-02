using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace FitnessApp.BL.Controllers
{
    public class SerializeDataSaver : IDataSaver
    {
        public List<T> Load<T>() where T : class
        {
            var fileName = typeof(T).Name + ".bin";
            var binFormatter = new BinaryFormatter();

            using (var file = new FileStream(fileName, FileMode.OpenOrCreate))
            {
                try
                {
                    if (file.Length > 0 && binFormatter.Deserialize(file) is List<T> result)
                    {
                        return result;
                    }
                }
                catch { }
            }

            return new List<T>();
        }

        public void Save<T>(List<T> obj) where T : class
        {
            var fileName = typeof(T).Name + ".bin";
            var binFormatter = new BinaryFormatter();

            using (var file = new FileStream(fileName, FileMode.OpenOrCreate))
            {
                binFormatter.Serialize(file, obj);
            }
        }
    }
}
