using System.Collections.Generic;

namespace MammoExpert.PatientServices.Sources
{
    public interface IRepository<T>
    {
        List<T> GetAll();

        void Add(T item);

        void Delete(T item);

        List<T> GetByType();
    }
}
