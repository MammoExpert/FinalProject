using System.Collections.Generic;
using System.Linq;

namespace MammoExpert.PatientServices.Sources
{
    public class SourceRepository
    {
        #region Fields

        private readonly List<Source> _sourceList;
        private readonly JsonManager _fileManager;

        #endregion // Fields
        
        #region Constructor

        public SourceRepository(string filePath)
        {
            _fileManager = new JsonManager(filePath);
            _sourceList = _fileManager.GetAll();
        }

        #endregion // Constructor

        #region Public methods

        // Возвращает список имеющихся источников
        public List<Source> GetAll()
        {
            return _sourceList;
        }

        // добавляет новый источник
        public void Create(Source newSource)
        {
            if (!_sourceList.Contains(newSource))
            {
                _sourceList.Add(newSource);
                _fileManager.RewriteFile();
            }
        }

        // удаляет источник
        public void Delete(Source source)
        {
            if (_sourceList.Contains(source) && _sourceList != null)
            {
                _sourceList.Remove(source);
                _fileManager.RewriteFile();
            }
        }

        // обновляет данные источника
        public void Update(Source source)
        {
            for (var i = 0; i < _sourceList.Count; i++)
            {
                if (_sourceList[i].Id == source.Id)
                {
                    _sourceList[i] = source;
                    _fileManager.RewriteFile();
                    return;
                }
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
