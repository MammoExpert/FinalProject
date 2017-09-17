using System.Collections.Generic;

namespace MammoExpert.PatientServices.Sources
{
    public interface IRepository<T> where T : class
    {
        void Add(T newItem);
        void Delete(T item);
        IEnumerable<T> GetAll();
        void Update(T item);
        IEnumerable<T> GetByType(SourceTypeEnum typeEnum);
    }
}