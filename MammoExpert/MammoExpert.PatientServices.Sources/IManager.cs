using System.Collections.Generic;

namespace MammoExpert.PatientServices.Sources
{
    public interface IManager<T> where T: class
    {
        void RewriteFile();
        IEnumerable<T> Load();
    }
}