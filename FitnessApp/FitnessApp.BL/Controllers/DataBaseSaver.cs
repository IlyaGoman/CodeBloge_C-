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
            throw new NotImplementedException();
        }
    }
}
