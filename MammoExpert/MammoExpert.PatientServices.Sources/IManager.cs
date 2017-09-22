using System.Collections.Generic;

namespace MammoExpert.PatientServices.Sources
{
    public interface IManager
    {
        void RewriteFile(IEnumerable<Source> collection);
        IEnumerable<Source> Load();
    }
}