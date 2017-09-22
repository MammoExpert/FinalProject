using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using MammoExpert.PatientServices.Core;
using MammoExpert.PatientServices.DB;
using MammoExpert.PatientServices.PresenterCore;
using MammoExpert.PatientServices.Sources;
using MammoExpert.PatientServices.Worklist;
using MammoExpert.PatientServices.Infrastructure;

namespace MammoExpert.PatientServices.Demo.ViewModel
{
    /// <summary>
    /// Модель представления элемента управления для поиска пациента
    /// </summary>
    public class PatientSearchViewModel : ViewModelBase
    {
        #region Fields

        private ObservableCollection<Patient> _patients;
        private static IPatientRepository _patientRepository;
        private static INotificationConnectionMessenger _connectionMessenger;
        private Patient _selectedPatient;
        private string _searchString;
        private Source _source;

        #endregion // Fields

        #region Constructor

        public PatientSearchViewModel(Source source)
        {
            base.DisplayName = source.Name;
            _source = source;
            _connectionMessenger = new NotificationConnectionMessenger();
        }

        #endregion // Constructor

        #region Properties

        /// <summary>
        /// Содержит список всех пациентов текущего источника
        /// </summary>
        public ObservableCollection<Patient> Patients
        {
            get
            {
                if(_patients == null) return new ObservableCollection<Patient>();
                return _patients;
            }
            set
            {
                if (_patients == value) return;
                _patients = value;
                RaisePropertyChanged("Patients");
            }
        }

        /// <summary>
        /// Текст, вводимый при поиске пациента
        /// </summary>
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

        /// <summary>
        /// Выбранный пользователем пациент
        /// </summary>
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

        public ICommand ChoosePatientCommand => new ActionCommand(OpenPatientDitailsView, param => param != null);

        //public ICommand CancelCommand => new ActionCommand(CloseCurrentWorkspace);

        public ICommand ClearSearchAreaCommand => new ActionCommand(ClearSearchArea);

        public ICommand FindPatientCammand => new ActionCommand(FindPatient);

        #endregion // Commands

        #region Private Methods

        /// <summary>
        /// Очищает строку поиска
        /// </summary>
        private void ClearSearchArea()
        {
            SearchString = string.Empty;
        }

        /// <summary>
        /// Открывает окно с данными выбранного пациента
        /// </summary>
        private void OpenPatientDitailsView()
        {
            App.Factory.CreatePatientDitailsView(SelectedPatient);
        }

        /// <summary>
        /// Возвращает коллекцию поциентов из текущего источника
        /// </summary>
        private void FindPatient()
        {
            if (!string.IsNullOrEmpty(SearchString))
            {
                switch (_source.TypeEnum)
                {
                    case SourceTypeEnum.DataBase:
                    {
                        try
                        {
                            var configuration = new DbConnectionHelper(SourceSerializer.DbDeserialize(_source));
                            _patientRepository = new PatientDbConnectionRepository(configuration);
                            var patients = _patientRepository.FindPatientsByValue(SearchString);
                            Patients = new ObservableCollection<Patient>(patients);
                        }
                        catch (Exception e)
                        {
                            _connectionMessenger.ShowConnectionErrorMessage(e);
                            ClearSearchArea();
                        }
                    }
                        return;
                    case SourceTypeEnum.Worklist:
                    {
                        try
                        {
                            _patientRepository = new PatientRepositoryDicom(SourceSerializer.WorklistDeserialize(_source));
                            var patients = _patientRepository.FindPatientsByValue(SearchString);
                            Patients = new ObservableCollection<Patient>(patients);
                        }
                        catch (Exception e)
                        {
                            _connectionMessenger.ShowConnectionErrorMessage(e);
                            ClearSearchArea();
                        }
                    }
                        return;
                }
            }

            Patients.Clear();
        }

        #endregion // Private Methods
    }
}
