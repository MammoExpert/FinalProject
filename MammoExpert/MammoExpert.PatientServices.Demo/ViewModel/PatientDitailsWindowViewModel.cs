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
        private Patient _patient;

        public PatientDitailsWindowViewModel(Patient patient)
        {
            base.DisplayName = Properties.Resources.PatientDitailsWindowViewModel_DisplayName;
            Patient = patient;
        }

        public Patient Patient
        {
            get { return _patient; }
            set
            {
                if (_patient == value) return;
                _patient = value;
                RaisePropertyChanged("Patient");
            }
        }
    }
}
