using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MammoExpert.PatientServices.Core;
using MammoExpert.PatientServices.Sources;

namespace MammoExpert.PatientServices.Demo
{
    public interface IViewFactory
    {
        void CreateMainView();
        void CreateSourcesView();
        void CreateAboutProgrammView();
        void CreateConfigurationView(SourceTypeEnum type);
        void CreateUpdateConfigurationView(Source source);
        void CreatePatientDitailsView(Patient patient);
    }
}
