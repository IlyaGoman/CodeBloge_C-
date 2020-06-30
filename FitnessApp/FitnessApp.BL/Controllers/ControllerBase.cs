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
        protected IDataSaver saver = new SerializeDataSaver();

        /// <summary>
        /// Сохраняет предоставленный List<T>
        /// </summary>
        /// <typeparam name="T"> Тип объекта сохранения. </typeparam>
        /// <param name="fileName"> Путь к файлу. </param>
        /// <param name="obj"> Список, который необходимо сохранить. </param>
        protected void Save<T>(string fileName, T obj)
        {
            saver.Save(fileName, obj);
        }


        /// <summary>
        /// Загрузка информации из файла в List<T>
        /// </summary>
        /// <typeparam name="T"> Тип получаемых объектов. </typeparam>
        /// <param name="fileName"> Пусть к файлу. </param>
        /// <returns> Возвращает List<T> </returns>
        protected T Load<T>(string fileName)
        {
            return saver.Load<T>(fileName);
        }
    }
}
