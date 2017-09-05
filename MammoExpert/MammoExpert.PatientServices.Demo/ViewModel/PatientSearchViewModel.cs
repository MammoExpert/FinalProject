using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using MammoExpert.PatientServices.Core;
using MammoExpert.PatientServices.PresenterCore;

namespace MammoExpert.PatientServices.Demo.ViewModel
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

        public ICommand ChoosePatientCommand => new ActionCommand(() =>
        {
            ViewFactory.CreatePatientDitailsView(new Patient());
        });

    }
}
