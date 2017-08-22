using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MammoExpert.PatientServices.Sources
{
    public class JsonManager
    {
        #region Fields

        private string _jsonString = string.Empty;
        private string _path;
        private List<Source> _jsonCollection;

        #endregion // Fields

        #region Constructor

        public JsonManager(string path)
        {
            _path = path;
            _jsonCollection = LoadJson();
        }

        #endregion // Constructor

        #region Public methods

        public List<Source> GetAllSources()
        {
            return _jsonCollection;   
        }

        public void AddSource(Source newSource)
        {
            _jsonCollection.Add(newSource);
            RewriteFile(_jsonCollection);
        }

        public void DeleteSource(Source source)
        {
            _jsonCollection.Remove(source);
            RewriteFile(_jsonCollection);
        }

        #endregion // Public methods

        #region Private methods

        private List<Source> LoadJson()
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
            return JsonConvert.DeserializeObject<List<Source>>(_jsonString); ;
        }

        private void RewriteFile(List<Source> coll)
        {
            _jsonString = JsonConvert.SerializeObject(coll);
            using (FileStream fstream = new FileStream(_path, FileMode.Open))
            {
                byte[] array = Encoding.Default.GetBytes(_jsonString);
                fstream.Write(array, 0, array.Length);
            }
        }

        #endregion // Private methods
    }
}
