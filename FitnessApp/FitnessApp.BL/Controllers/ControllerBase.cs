using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace FitnessApp.BL.Controllers
{
    abstract class ControllerBase
    {
        protected void Save<T>(string fileName, List<T> obj)
        {
            var binFormatter = new BinaryFormatter();

            using (var file = new FileStream(fileName, FileMode.OpenOrCreate))
            {
                binFormatter.Serialize(file, obj);
            }
        }

        protected List<T> Load<T>(string fileName)
        {
            var binFormatter = new BinaryFormatter();

            using (var file = new FileStream(fileName, FileMode.OpenOrCreate))
            {
                if (file.Length > 0 && binFormatter.Deserialize(file) is List<T> result)
                {
                    return result;
                }
            }

            return new List<T>();
        }
    }
}
