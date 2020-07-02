using System;
using System.Collections.Generic;

namespace FitnessApp.BL.Controllers
{
    public interface IDataSaver
    {
        void Save<T>(List<T> obj) where T : class;

        List<T> Load<T>() where T : class;
    }
}
