using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.Serialization.Json;
using Newtonsoft.Json;

namespace MammoExpert.PatientServices.Sources
{
    public class SourceRepository
    {
        private List<Source> _sourceList;
        private readonly DataContractJsonSerializer _jsonFormatter = new DataContractJsonSerializer(typeof(List<Source>));
        private readonly string _jsonFilePath = "all_sources.json";

        public SourceRepository()
        {
            _sourceList = GetAllSources();
            //{
            //    new Source("Некая база данных 1", SourceType.DataBase, "описание 1, очень длинное описание, прям длинне всех, это для проверки скролов ))"),
            //    new Source("Некий ворклист 1",SourceType.WorkList, "описание 2"),
            //    new Source("Некая база данных 2", SourceType.DataBase, "описание 3"),
            //    new Source("Некий ворклист 2",SourceType.WorkList, "описание 4"),
            //    new Source("Некая база данных 3", SourceType.DataBase, "описание 5"),
            //    new Source("Некая база данных 3", SourceType.DataBase, "описание 6"),
            //    new Source("Некий ворклист 3",SourceType.WorkList, "описание 7"),
            //    new Source("Некая база данных 4", SourceType.DataBase, "описание 8"),
            //    new Source("Некая база данных 5", SourceType.DataBase, "описание 9"),
            //    new Source("Некий ворклист 4",SourceType.WorkList, "описание 10"),
            //    new Source("Некая база данных 6", SourceType.DataBase, "описание 11")
            //};
        }

        public List<Source> GetAllSources()
        {
            using (var fs = new FileStream(_jsonFilePath, FileMode.Open))
            {
                _sourceList = (List<Source>)_jsonFormatter.ReadObject(fs);
            }
            return _sourceList;
        }

        public void AddSource(Source newSource)
        {
            // добавляем в JSON
            using (var fs = new FileStream(_jsonFilePath, FileMode.Open))
            {
                _jsonFormatter.WriteObject(fs, newSource);
            }

            //добавляем в список
            _sourceList.Add(newSource);
        }

        public void DeleteSource(Source source)
        {
            // удаляем из JSON-а
            var obj = JsonConvert.SerializeObject(source);
            var jsonString = File.ReadAllText(_jsonFilePath);
            jsonString = jsonString.Replace(obj, "");

            // удаляем из списка
            _sourceList.Remove(source);
        }

        public List<Source> GetSourcesByType(SourceType type)
        {
            return _sourceList.Where(t => t.Type == type).ToList();
        }

    }
}
