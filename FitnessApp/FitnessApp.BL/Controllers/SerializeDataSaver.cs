using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace FitnessApp.BL.Controllers
{
    public class SerializeDataSaver<T> : IDataSaver<T> where T : class
    {
        public List<T> Load()
        {
            var fileName = typeof(T) + ".bin";
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

        public void Save(T obj)
        {
            var fileName = typeof(T) + ".bin";
            var binFormatter = new BinaryFormatter();

            using (var file = new FileStream(fileName, FileMode.OpenOrCreate))
            {
                binFormatter.Serialize(file, obj);
            }
        }
    }
}
