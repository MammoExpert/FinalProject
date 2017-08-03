using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.Serialization.Json;
using MammoExpert.PatientServices.Sources.Types;
using Newtonsoft.Json;

namespace MammoExpert.PatientServices.Sources
{
    public class SourceRepository
    {
        private List<Source> _sourceList;
        private string _jsonFilePath;
        private JsonManager _fileManager;

        public SourceRepository(string filePath)
        {
            _fileManager = new JsonManager(filePath);
            _jsonFilePath = filePath;
            _sourceList = GetAllSources();
        }

        // метод, возвращающий полный список источников
        public List<Source> GetAllSources()
        {
            return _fileManager.JsonToList();
        }

        // метод для добавления нового источника в список
        public void AddSource(Source newSource)
        {
            _sourceList.Add(newSource);
            _fileManager.AddSource(newSource);
        }

        // метод для удаления источника из списка
        public void DeleteSource(Source source)
        {
            _sourceList.Remove(source);
            _fileManager.DeleteSource(source);
        }

        // метод, возвращающий список источников, согласно переданному типу
        public List<Source> GetSourcesByType(SourceType type)
        {
            return _sourceList.Where(t => t.Type == type).ToList();
        }

    }
}
