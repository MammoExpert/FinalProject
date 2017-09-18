using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using MammoExpert.PatientServices.Core;
using MammoExpert.PatientServices.DB;
using MammoExpert.PatientServices.Infrastructure;
using MammoExpert.PatientServices.PresenterCore;
using MammoExpert.PatientServices.Sources;
using MammoExpert.PatientServices.Worklist;

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
        private Patient _selectedPatient;
        private string _searchString;
        public string SourceName;
        private readonly MainWindowViewModel _parent;

        #endregion // Fields

        #region Constructor

        public PatientSearchViewModel(ViewModelBase parent, Source source)
        {
            base.DisplayName = source.Name;
            _parent = parent as MainWindowViewModel;
            SourceName = source.Name;
            Patients = GetData(source);
        }

        #endregion // Constructor

        #region Properties

        /// <summary>
        /// Содержит список всех пациентов текущего источника
        /// </summary>
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

        public ICommand CancelCommand => new ActionCommand(CloseCurrentWorkspace);

        public ICommand ClearSearchAreaCommand => new ActionCommand(() => SearchString = string.Empty);

        public ICommand FindPatientCammand => new ActionCommand(FindPatient);

        #endregion // Commands

        #region Private Methods

        /// <summary>
        /// Закрывает текущую рабочую область
        /// </summary>
        private void CloseCurrentWorkspace()
        {
            _parent.WorkspaceRepository.Delete(this);
        }

        /// <summary>
        /// Открывает окно с данными выбранного пациента
        /// </summary>
        private void OpenPatientDitailsView()
        {
            ViewFactory.CreatePatientDitailsView(this);
        }

        /// <summary>
        /// Осуществляет поиск поциентов согласно строке поиска
        /// </summary>
        private void FindPatient()
        {
            var p = _patientRepository.FindPatientsByValue(SearchString);
            Patients = new ObservableCollection<Patient>(p);
        }

        /// <summary>
        /// Возвращает коллекцию поциентов из текущего источника
        /// </summary>
        private static ObservableCollection<Patient> GetData(Source source)
        {
            switch (source.TypeEnum)
            {
                case SourceTypeEnum.DataBase:
                {
                    try
                    {
                        var configuration = new DbConnectionHelper(SourceSerializer.DbDeserialize(source));
                        _patientRepository = new PatientDbConnectionRepository(configuration);
                        var patients = _patientRepository.GetAllPatients().ToList();
                        return new ObservableCollection<Patient>(patients);
                    }
                    catch (Exception e)
                    {
                        Messenger.ShowConnectionDbErrorMessage(e);
                        return null;
                    }
                }
                case SourceTypeEnum.Worklist:
                {
                    try
                    {
                        _patientRepository = new PatientRepositoryDicom(SourceSerializer.WorklistDeserialize(source));
                        var patients = _patientRepository.GetAllPatients().ToList();
                        return new ObservableCollection<Patient>(patients);
                    }
                    catch (Exception e)
                    {
                        Messenger.ShowConnectionWorklistErrorMessage(e);
                        return null;
                    }
                }

                default: return null;
            }    
        }

        #endregion // Private Methods
    }
}
