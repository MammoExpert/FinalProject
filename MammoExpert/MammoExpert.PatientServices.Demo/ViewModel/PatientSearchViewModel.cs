using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Media;
using MammoExpert.PatientServices.Core;
using MammoExpert.PatientServices.DB;
using MammoExpert.PatientServices.Demo.Properties;
using MammoExpert.PatientServices.PresenterCore;
using MammoExpert.PatientServices.Sources;
using MammoExpert.PatientServices.Infrastructure;

namespace MammoExpert.PatientServices.Demo.ViewModel
{
    public class PatientSearchViewModel : ViewModelBase
    {
        #region Fields

        private ObservableCollection<Patient> _patients;
        private static PatientDbConnectionRepository _patientRepository;
        private Patient _selectedPatient;
        private string _searchString;
        public string SourceName;

        #endregion // Fields

        #region Constructor

        public PatientSearchViewModel(Source source)
        {
            base.DisplayName = source.Name;
            SourceName = source.Name;
            Patients = GetData(source);
        }

        #endregion // Constructor

        #region Properties

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

        public string SearchString
        {
            get { return _searchString; }
            set
            {
                if (_searchString == value) return;
                _searchString = value;
                RaisePropertyChanged("SearchString");
            }
        }

        public Patient SelectedPatient
        {
            get { return _selectedPatient; }
            set
            {
                if (_selectedPatient == value) return;
                _selectedPatient = value;
                RaisePropertyChanged("SelectedPatient");
            }
        }

        #endregion // Properties

        #region Commands

        public ICommand ChoosePatientCommand => new ActionCommand( () => ViewFactory.CreatePatientDitailsView(this),  param => param != null);

        public ICommand CancelCommand => new ActionCommand(() =>
        {
            MainWindowViewModel.WorkspaceRepository.Delete(this);
        });

        public ICommand ClearSearchAreaCommand => new ActionCommand(() =>
        {
            SearchString = string.Empty;
        });

        public ICommand FindPatientCammand => new ActionCommand(() =>
        {
            var p = _patientRepository.FindPatientsByValue(SearchString);
            Patients = new ObservableCollection<Patient>(p);
        });

        #endregion // Commands

        #region Private Methods

        // возвращает данные из источника
        private static ObservableCollection<Patient> GetData(Source source)
        {
            try
            {
                var configuration = new DbConnectionConfiguration(SourceSerializer.DbDeserialize(source));
                _patientRepository = new PatientDbConnectionRepository(configuration);
                var patients = _patientRepository.GetAllPatients().ToList();
                return new ObservableCollection<Patient>(patients);
            }
            catch (Exception e)
            {
                Messager.ShowConnectionErrorMessage(e);
                return null;
            }
        }

        #endregion // Private Methods
    }
}
