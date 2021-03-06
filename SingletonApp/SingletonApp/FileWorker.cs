﻿using System;
using System.IO;

namespace SingletonApp
{
    /// <summary>
    /// Класс для работы с текстом. Сохранение изменений в файл
    /// выполняется только по запросу Save.
    /// До этого изменения хранятся в динамической памяти.
    /// </summary>
    class FileWorker
    {
        /// <summary>
        /// Путь к файлу
        /// </summary>
        public string FilePath { get; }

        /// <summary>
        /// Содержимое файла в динамической памяти.
        /// </summary>
        public string Text { get; private set; }

        /// <summary>
        /// Создать новый экземпляр работы с текстом.
        /// </summary>
        public FileWorker()
        {
            FilePath = "test.txt";
            ReadTextFromFile();
        }

        /// <summary>
        /// Сохранение текста в динамическую память(без записи в файл).
        /// </summary>
        /// <param name="text">Текст для сохранения.</param>
        public void WriteText(string text)
        {
            Text += text;
        }

        /// <summary>
        /// Запись данных в файл.
        /// </summary>
        /// <param name="text">Данные для записи.</param>
        public void Save()
        {
            using (var writer = new StreamWriter(FilePath, false))
            {
                writer.WriteLine(Text);
            }
        }

        /// <summary>
        /// Чтение данных из файла.
        /// </summary>
        private void ReadTextFromFile()
        {
            if(!File.Exists(FilePath))
            {
                Text = "";
            }
            else
            {
                using(var reader = new StreamReader(FilePath))
                {
                    Text = reader.ReadToEnd();
                }
            }
        }
    }
}
