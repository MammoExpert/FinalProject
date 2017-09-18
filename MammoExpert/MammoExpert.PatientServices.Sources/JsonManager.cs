using MammoExpert.PatientServices.Infrastructure;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows;

namespace MammoExpert.PatientServices.Sources
{
    /// <summary>
    /// Вспомогательный класс для работы с Json-файлами
    /// </summary>
    public class JsonManager : IManager<Source>
    {
        private const string DefaultPath = "../../Data/all_sources.json";

        #region Fields

        private string _jsonString;
        private readonly string _path;
        private readonly List<Source> _jsonCollection;

        #endregion // Fields

        #region Constructor

        public JsonManager(string path = null)
        {
            _path = path ?? DefaultPath;
            _jsonCollection = Load() as List<Source>;
        }

        #endregion // Constructor

        #region Public methods

        ///// <summary>
        ///// Возвращает список объектов
        ///// </summary>
        //public IEnumerable<Source> GetAll()
        //{
        //    return _jsonCollection;
        //}

        ///// <summary>
        ///// Добавляет объект
        ///// </summary>
        //public void Add(Source newItem)
        //{
        //    _jsonCollection.Add(newItem);
        //    RewriteFile();
        //}

        ///// <summary>
        ///// Удаляет объект
        ///// </summary>
        //public void Delete(Source item)
        //{
        //    _jsonCollection.Remove(item);
        //    RewriteFile();
        //}

        ///// <summary>
        ///// Обновляет объект
        ///// </summary>
        //public void Update(Source item)
        //{
        //    for (var i = 0; i < _jsonCollection.Count; i++)
        //    {
        //        if (_jsonCollection[i].Id == item.Id)
        //        {
        //            _jsonCollection[i] = item;
        //            RewriteFile();
        //            return;
        //        }
        //    }
        //}

        //public IEnumerable<Source> GetByType(SourceTypeEnum typeEnum)
        //{
        //    throw new NotImplementedException();
        //}

        #endregion // Public methods

        #region Private methods

        /// <summary>
        /// Возврвщает коллекцию объектов из json-файла в виде списка
        /// </summary>
        public IEnumerable<Source> Load()
        {
            try
            {
                _jsonString = File.ReadAllText(_path);
            }
            catch (Exception ex)
            {
                Messenger.ShowFileMessage(ex, _path);
            }
            var result = JsonConvert.DeserializeObject<List<Source>>(_jsonString);
            return result ?? new List<Source>().AsEnumerable();
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
