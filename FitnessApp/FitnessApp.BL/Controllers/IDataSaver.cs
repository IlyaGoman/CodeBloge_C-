using System;

namespace FitnessApp.BL.Controllers
{
    public interface IDataSaver
    {
        void Save<T>(string fileName, T obj);
        T Load<T>(string fileName);
    }
}
