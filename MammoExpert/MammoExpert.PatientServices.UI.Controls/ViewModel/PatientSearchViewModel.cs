using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Documents;
using MammoExpert.PatientServices.Core;
using MammoExpert.PatientServices.PresenterCore;
using MammoExpert.PatientServices.Sources;

namespace MammoExpert.PatientServices.UI.Controls.ViewModel
{
    public class PatientSearchViewModel : ViewModelBase
    {
        private ObservableCollection<Patient> _patients;
        public PatientSearchViewModel(string sourceName, List<Patient> patientList)
        {
            base.DisplayName = sourceName;
            _patients = new ObservableCollection<Patient>(patientList);
        }

        public ObservableCollection<Patient> Patients
        {
            get { return _patients; }
            set
            {
                if (_patients == value) return;
                _patients = value;
                RaisePropertyChanged("Patients");
            }
        }

    }
}
