using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MammoExpert.PatientServices.Demo.Sources
{
    public class SourceRepository
    {
        private readonly List<Source> _sourceList;

        public SourceRepository()
        {
            _sourceList = new List<Source>()
            {
                new Source("Некая база данных 1", Source.Types.DataBase, "описание 1, очень длинное описание, прям длинне всех, это для проверки скролов ))"),
                new Source("Некий ворклист 1",Source.Types.WorkList, "описание 2"),
                new Source("Некая база данных 2", Source.Types.DataBase, "описание 3"),
                new Source("Некий ворклист 2",Source.Types.WorkList, "описание 4"),
                new Source("Некая база данных 3", Source.Types.DataBase, "описание 5"),
                new Source("Некая база данных 3", Source.Types.DataBase, "описание 6"),
                new Source("Некий ворклист 3",Source.Types.WorkList, "описание 7"),
                new Source("Некая база данных 4", Source.Types.DataBase, "описание 8"),
                new Source("Некая база данных 5", Source.Types.DataBase, "описание 9"),
                new Source("Некий ворклист 4",Source.Types.WorkList, "описание 10"),
                new Source("Некая база данных 6", Source.Types.DataBase, "описание 11")
            };
        }

        public List<Source> GetAllSources()
        {
            return _sourceList;
        }

        public void AddSource(Source newSource)
        {
            _sourceList.Add(newSource);
        }

        public void DeleteSource(Source source)
        {
            _sourceList.Remove(source);
        }

        public List<Source> GetSourcesByType(Source.Types type)
        {
            return _sourceList.Where(t => t.Type == type).ToList();
        }

    }
}
