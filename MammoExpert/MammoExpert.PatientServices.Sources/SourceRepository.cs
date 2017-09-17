using System.Collections.Generic;
using System.Linq;

namespace MammoExpert.PatientServices.Sources
{
    /// <summary>
    /// Класс для создания репозитория источников
    /// </summary>
    public class SourceRepository : IRepository<Source>
    {
        #region Fields

        private readonly List<Source> _sourceList;
        private readonly JsonManager _fileManager;

        #endregion // Fields

        #region Constructor

        public SourceRepository(string filePath)
        {
            _fileManager = new JsonManager(filePath);
            _sourceList = (List<Source>) _fileManager.GetAll();
        }

        #endregion // Constructor

        #region Public methods

        /// <summary>
        /// Возвращает список имеющихся источников
        /// </summary>
        public IEnumerable<Source> GetAll()
        {
            return _sourceList;
        }

        /// <summary>
        /// Добавляет новый источник
        /// </summary>       
        public void Add(Source newSource)
        {
            if (!_sourceList.Contains(newSource))
            {
                _sourceList.Add(newSource);
                _fileManager.RewriteFile();
            }
        }

        /// <summary>
        /// Удаляет источник
        /// </summary>
        public void Delete(Source source)
        {
            if (_sourceList.Contains(source) && _sourceList != null)
            {
                _sourceList.Remove(source);
                _fileManager.RewriteFile();
            }
        }

        /// <summary>
        /// Обновляет данные источника
        /// </summary>
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

        /// <summary>
        /// Возвращает список источников согласно переданному типу
        /// </summary>
        public IEnumerable<Source> GetByType(SourceTypeEnum typeEnum)
        {
            return _sourceList?.Where(t => t.TypeEnum == typeEnum);
        }

        #endregion // Public methods
    }
}
