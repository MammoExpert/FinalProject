using System.Collections.Generic;
using System.Linq;

namespace MammoExpert.PatientServices.Sources
{
    public class SourceRepository
    {
        #region Fields

        private List<Source> _sourceList;
        private string _jsonFilePath;
        private JsonManager _fileManager;

        #endregion // Fields
        
        #region Constructor

        public SourceRepository(string filePath)
        {
            _fileManager = new JsonManager(filePath);
            _jsonFilePath = filePath;
            _sourceList = GetAllSources();
        }

        #endregion // Constructor

        #region Public methods

        // метод, возвращающий полный список источников
        public List<Source> GetAllSources()
        {
            return _fileManager.GetAllSources();
        }

        // метод для добавления нового источника в список
        public void AddSource(Source newSource)
        {
            if (!_sourceList.Contains(newSource))
            {
                _sourceList.Add(newSource);
                _fileManager.AddSource(newSource);
            }
        }

        // метод для удаления источника из списка
        public void DeleteSource(Source source)
        {
            if (_sourceList.Contains(source))
            {
                _sourceList.Remove(source);
                _fileManager.DeleteSource(source);
            }
        }

        // метод, возвращающий список источников, согласно переданному типу
        public List<Source> GetSourcesByType(SourceType type)
        {
            return _sourceList.Where(t => t.Type == type).ToList();
        }

        #endregion // Public methods
    }
}
