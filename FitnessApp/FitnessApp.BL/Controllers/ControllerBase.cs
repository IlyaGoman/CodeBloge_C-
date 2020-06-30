using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace FitnessApp.BL.Controllers
{
    /// <summary>
    /// Базовый класс для контроллеров.
    /// </summary>
    public abstract class ControllerBase<T> where T : class
    {
        protected IDataSaver<T> manager = new SerializeDataSaver<T>();

        /// <summary>
        /// Сохраняет предоставленный List<T>
        /// </summary>
        /// <typeparam name="T"> Тип объекта сохранения. </typeparam>
        /// <param name="obj"> Список, который необходимо сохранить. </param>
        protected void Save(T obj)
        {
            manager.Save(obj);
        }


        /// <summary>
        /// Загрузка информации из файла в List<T>
        /// </summary>
        /// <typeparam name="T"> Тип получаемых объектов. </typeparam>
        /// <param name="fileName"> Пусть к файлу. </param>
        /// <returns> Возвращает List<T> </returns>
        protected List<T> Load()
        {
            return manager.Load();
        }
    }
}
