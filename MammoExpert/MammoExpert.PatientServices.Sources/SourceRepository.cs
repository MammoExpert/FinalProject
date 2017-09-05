using System.Collections.Generic;
using System.Linq;

namespace MammoExpert.PatientServices.Sources
{
    public class SourceRepository
    {
        #region Fields

        private List<Source> _sourceList;
        private JsonManager _fileManager;

        #endregion // Fields
        
        #region Constructor

        public SourceRepository(string filePath)
        {
            _fileManager = new JsonManager(filePath);
            _sourceList = GetAll();
        }

        #endregion // Constructor

        #region Public methods

        // Возвращает список имеющихся источников
        public List<Source> GetAll()
        {
            return _fileManager.GetAll();
        }

        // добавляет новый источник
        public void Add(Source newSource)
        {
            if (!_sourceList.Contains(newSource))
            {
                _sourceList.Add(newSource);
                _fileManager.Add(newSource);
            }
        }

        // удаляет источник
        public void Delete(Source source)
        {
            if (_sourceList.Contains(source) && _sourceList != null)
            {
                _sourceList.Remove(source);
                _fileManager.Delete(source);
            }
        }

        // возвращает список источников согласно переданному типу
        public List<Source> GetByType(SourceType type)
        {
            return _sourceList?.Where(t => t.Type == type).ToList();
        }

        #endregion // Public methods
    }
}
