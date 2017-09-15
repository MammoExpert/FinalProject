using MammoExpert.PatientServices.Infrastructure;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows;

namespace MammoExpert.PatientServices.Sources
{
    /// <summary>
    /// Вспомогательный класс для работы с Json-файлами
    /// </summary>
    public class JsonManager
    {
        #region Fields

        private string _jsonString;
        private readonly string _path;
        private readonly List<Source> _jsonCollection;

        #endregion // Fields

        #region Constructor

        public JsonManager(string path)
        {
            _path = path;
            _jsonCollection = LoadJson();
        }

        #endregion // Constructor

        #region Public methods

        /// <summary>
        /// Возвращает список объектов
        /// </summary>
        public List<Source> GetAll()
        {
            return _jsonCollection;
        }

        /// <summary>
        /// Добавляет объект
        /// </summary>
        public void Add(Source newItem)
        {
            _jsonCollection.Add(newItem);
            RewriteFile();
        }

        /// <summary>
        /// Удаляет объект
        /// </summary>
        public void Delete(Source item)
        {
            _jsonCollection.Remove(item);
            RewriteFile();
        }

        /// <summary>
        /// Обновляет объект
        /// </summary>
        public void Update(Source item)
        {
            for (var i = 0; i < _jsonCollection.Count; i++)
            {
                if (_jsonCollection[i].Id == item.Id)
                {
                    _jsonCollection[i] = item;
                    RewriteFile();
                    return;
                }
            }
        }

        #endregion // Public methods

        #region Private methods

        /// <summary>
        /// Возврвщает коллекцию объектов из json-файла в виде списка
        /// </summary>
        private List<Source> LoadJson()
        {
            try
            {
                _jsonString = File.ReadAllText(_path);
            }
            catch (FileNotFoundException)
            {
                Messager.ShowNotFindFileMessage(_path);
            }
            var result = JsonConvert.DeserializeObject<List<Source>>(_jsonString);
            return result ?? new List<Source>();
        }

        /// <summary>
        /// Записывает в json-файл новые значения
        /// </summary>
        public void RewriteFile()
        {
            var str = JsonConvert.SerializeObject(_jsonCollection);
            if (!File.Exists(_path)) return;
            var writer = new StreamWriter(_path, false, Encoding.UTF8);
            writer.WriteLine(str);
            writer.Close();
        }

        #endregion // Private methods
    }
}
