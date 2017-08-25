using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows;

namespace MammoExpert.PatientServices.Sources
{
    public class JsonManager<T>
    {
        #region Fields

        private string _jsonString;
        private readonly string _path;
        private List<T> _jsonCollection;

        #endregion // Fields

        #region Constructor

        public JsonManager(string path)
        {
            _path = path;
            _jsonCollection = LoadJson();
        }

        #endregion // Constructor

        #region Public methods

        public List<T> GetAll()
        {
            return _jsonCollection;   
        }

        public void Add(T newItem)
        {
            _jsonCollection.Add(newItem);
            RewriteFile();
        }

        public void Delete(T item)
        {
            _jsonCollection.Remove(item);
            RewriteFile();
        }

        #endregion // Public methods

        #region Private methods

        // возврвщает коллекцию объектов из json-файла в виде списка
        private List<T> LoadJson()
        {
            try
            {
                _jsonString = File.ReadAllText(_path);
            }
            catch (FileNotFoundException)
            {
                MessageBox.Show("Файл '" + _path + "' не найден", "Ошибка при загрузке файла",
                    MessageBoxButton.OK, MessageBoxImage.Error);
                Environment.Exit(0);
            }
            return JsonConvert.DeserializeObject<List<T>>(_jsonString); ;
        }

        // записывает в json-файл новые значения
        private void RewriteFile()
        {
            var str = JsonConvert.SerializeObject(_jsonCollection);
            if (File.Exists(_path))
            {
                var writer = new StreamWriter(_path, false, Encoding.UTF8);
                writer.WriteLine(str);
                writer.Close();
            }
        }

        #endregion // Private methods
    }
}
