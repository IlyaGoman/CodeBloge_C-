using System;
using System.Collections.Generic;

namespace FitnessApp.BL.Controllers
{
    public interface IDataSaver<T> where T : class
    {
        void Save(T obj);
        List<T> Load();
    }
}
