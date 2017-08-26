using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using MammoExpert.PatientServices.Core;
using MammoExpert.PatientServices.PresenterCore;

namespace MammoExpert.PatientServices.Demo.ViewModel
{
    public class PatientDitailsWindowViewModel : ViewModelBase
    {
        private readonly Patient _patient;

        public PatientDitailsWindowViewModel(Patient patient)
        {
            base.DisplayName = Properties.Resources.PatientDitailsWindowViewModel_DisplayName;
            _patient = patient;
        }

        public Patient Patient
        {
            get { return _patient; }
        }
    }
}
