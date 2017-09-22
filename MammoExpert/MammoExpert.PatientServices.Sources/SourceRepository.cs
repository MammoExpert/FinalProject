using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace MammoExpert.PatientServices.Sources
{
    /// <summary>
    /// Класс для создания репозитория источников
    /// </summary>
    public class SourceRepository : ISourceRepository
    {
        #region Fields

        public readonly ObservableCollection<Source> SourceList;
        private readonly JsonManager _fileManager;

        #endregion // Fields

        #region Constructor

        public SourceRepository(string filePath)
        {
            _fileManager = new JsonManager(filePath);
            SourceList = new ObservableCollection<Source>(_fileManager.Load());
        }

        #endregion // Constructor

        #region Public methods

        /// <summary>
        /// Возвращает список имеющихся источников
        /// </summary>
        public ObservableCollection<Source> GetAll()
        {
            return SourceList;
        }

        /// <summary>
        /// Добавляет новый источник
        /// </summary>       
        public void Add(Source newSource)
        {
            if (!SourceList.Contains(newSource))
            {
                SourceList.Add(newSource);
                _fileManager.RewriteFile(SourceList);
            }
        }

        /// <summary>
        /// Удаляет источник
        /// </summary>
        public void Delete(Source source)
        {
            if (SourceList.Contains(source) && SourceList != null)
            {
                SourceList.Remove(source);
                _fileManager.RewriteFile(SourceList);
            }
        }

        /// <summary>
        /// Обновляет данные источника
        /// </summary>
        public void Update(Source newSource, Source oldSource)
        {
            for (var i = 0; i < SourceList.Count; i++)
            {
                if (SourceList[i] == oldSource)
                {
                    SourceList[i] = newSource;
                    _fileManager.RewriteFile(SourceList);
                    return;
                }
            }
        }

        #endregion // Public methods
    }
}
