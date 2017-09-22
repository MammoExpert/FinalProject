using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace MammoExpert.PatientServices.Sources
{
    public interface ISourceRepository
    {
        ObservableCollection<Source> SourceList { get; set; }
        void Add(Source newItem);
        void Delete(Source item);
        ObservableCollection<Source> GetAll();
        void Update(Source newSource, Source oldSource);
    }
}