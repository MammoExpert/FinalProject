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
    public class JsonManager : IManager
    {
        
        #region Fields

        private string _jsonString;
        private readonly string _path;

        #endregion // Fields

        #region Constructor

        public JsonManager(string path)
        {
            _path = path;
        }

        #endregion // Constructor

        #region Public methods

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
                //Messenger.ShowFileMessage(ex, _path);
            }
            var result = JsonConvert.DeserializeObject<List<Source>>(_jsonString);
            return result ?? new List<Source>().AsEnumerable();
        }

        /// <summary>
        /// Записывает в json-файл новые значения
        /// </summary>
        public void RewriteFile(IEnumerable<Source> collection)
        {
            var str = JsonConvert.SerializeObject(collection);
            if (!File.Exists(_path)) return;
            var writer = new StreamWriter(_path, false, Encoding.UTF8);
            writer.WriteLine(str);
            writer.Close();
        }

        #endregion // Pablic methods
    }
}
