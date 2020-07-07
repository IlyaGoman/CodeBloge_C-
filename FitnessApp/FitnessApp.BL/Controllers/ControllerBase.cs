using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace FitnessApp.BL.Controllers
{
    /// <summary>
    /// Базовый класс для контроллеров.
    /// </summary>
    public abstract class ControllerBase
    {
        //private IDataSaver manager = new SerializeDataSaver();
        private IDataSaver manager = new SerializeDataSaver();

        /// <summary>
        /// Сохраняет предоставленный List<T>
        /// </summary>
        /// <typeparam name="T"> Тип объекта сохранения. </typeparam>
        /// <param name="obj"> Список, который необходимо сохранить. </param>
        protected void Save<T>(List<T> obj) where T : class
        {
            manager.Save(obj);
        }

        /// <summary>
        /// Загрузка информации из файла в List<T>
        /// </summary>
        /// <returns>  </returns>
        protected List<T> Load<T>() where T : class
        {
            return manager.Load<T>();
        }
    }
}
