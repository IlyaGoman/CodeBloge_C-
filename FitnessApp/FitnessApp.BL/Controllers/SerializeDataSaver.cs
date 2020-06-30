using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace FitnessApp.BL.Controllers
{
    public class SerializeDataSaver : IDataSaver
    {
        public T Load<T>(string fileName)
        {
            var binFormatter = new BinaryFormatter();

            using (var file = new FileStream(fileName, FileMode.OpenOrCreate))
            {
                try
                {
                    if (file.Length > 0 && binFormatter.Deserialize(file) is T result)
                    {
                        return result;
                    }
                }
                catch { }
            }

            return default(T);
        }

        public void Save<T>(string fileName, T obj)
        {
            var binFormatter = new BinaryFormatter();

            using (var file = new FileStream(fileName, FileMode.OpenOrCreate))
            {
                binFormatter.Serialize(file, obj);
            }
        }
    }
}
