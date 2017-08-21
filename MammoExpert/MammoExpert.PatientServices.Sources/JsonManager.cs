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
        private string _json;
        public JsonManager(string path)
        {
            _json = LoadJson(path);
        }

        private string LoadJson(string path)
        {
            try
            {
                return File.ReadAllText(path);
            }
            catch (FileNotFoundException)
            {
                MessageBox.Show("Файл '" + path + "' не найден", "Ошибка при загрузке файла",
                    MessageBoxButton.OK, MessageBoxImage.Error);
                Environment.Exit(0);
            }
            return null;
        }

        public List<Source> JsonToList()
        {
            return JsonConvert.DeserializeObject<List<Source>>(_json);    
        }

        public void AddSource(Source newSource)
        {
            var list = JsonToList();
            list.Add(newSource);
            _json = JsonConvert.SerializeObject(list);
        }

        public void DeleteSource(Source source)
        {
            var obj = JsonConvert.SerializeObject(source);
            _json = _json.Replace(obj, "");
        }
    }
}
