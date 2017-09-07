using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using MammoExpert.PatientServices.Core;
using MammoExpert.PatientServices.DB;
using MammoExpert.PatientServices.PresenterCore;
using MammoExpert.PatientServices.Sources;

namespace MammoExpert.PatientServices.Demo.ViewModel
{
    public class PatientSearchViewModel : ViewModelBase
    {
        private ObservableCollection<Patient> _patients;
        private static PacientRepositoryEf _patientRepository;
        //private List<Patient> data = new List<Patient>();
        public PatientSearchViewModel(Source source)
        {
            base.DisplayName = source.Name;
            var data = GetData(source);
            //// для теста
            //data = new List<Patient>()
            //{
            //    new Patient() {PatientId = "12", FirstName = "Иван", LastName = "Кудин", BirthDate = new DateTime(1988, 02, 12), MiddleName = "Сергеевич", NumberOfPassport = "МР1234589", Telephone = "+375296548596", AccessionNumber = String.Empty, Contingent = String.Empty, InsuranceCompany = String.Empty, Sex = Sex.Male, PatientComments = String.Empty, Job = String.Empty, MedicalRecordLocator = String.Empty, NumberPolicy = String.Empty, PatientAddress = String.Empty, PatientCategory = String.Empty, PatientWorkAddress = String.Empty},
            //    new Patient() {PatientId = "23", FirstName = "Сергей", LastName = "Береза", BirthDate = new DateTime(1956, 01, 01).Date, MiddleName = "Олегович", NumberOfPassport = "МР1250006", Telephone = "+375295478122", AccessionNumber = String.Empty, Contingent = String.Empty, InsuranceCompany = String.Empty, Sex = Sex.Male, PatientComments = String.Empty, Job = String.Empty, MedicalRecordLocator = String.Empty, NumberPolicy = String.Empty, PatientAddress = String.Empty, PatientCategory = String.Empty, PatientWorkAddress = String.Empty},
            //    new Patient() {PatientId = "581", FirstName = "Светлана", LastName = "Дмитрюкова", Sex = Sex.Female, BirthDate = new DateTime(2001, 12, 30).Date, MiddleName = "Васильевна", NumberOfPassport = "МР7774529", Telephone = "+375299652333", AccessionNumber = String.Empty, Contingent = String.Empty, InsuranceCompany = String.Empty, PatientComments = String.Empty, Job = String.Empty, MedicalRecordLocator = String.Empty, NumberPolicy = String.Empty, PatientAddress = String.Empty, PatientCategory = String.Empty, PatientWorkAddress = String.Empty}
            //};

            if (data != null) Patients = data;
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

        private string _searchString;
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

        public ICommand ChoosePatientCommand => new ActionCommand<Patient>( ViewFactory.CreatePatientDitailsView, param => param != null);

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
            // для теста
            //SearchString = SearchString.ToLower();
            //var p = data.Where(s => s != null).Where(s => s.AccessionNumber.Contains(SearchString) ||
            //                                                                         s.FirstName.ToLower().Contains(SearchString) ||
            //                                                                         s.InsuranceCompany.ToLower().Contains(SearchString) ||
            //                                                                         s.LastName.ToLower().Contains(SearchString) ||
            //                                                                         s.MiddleName.ToLower().Contains(SearchString) ||
            //                                                                         s.NumberOfPassport.ToLower().Contains(SearchString) ||
            //                                                                         s.NumberPolicy.ToLower().Contains(SearchString) ||
            //                                                                         s.PatientAddress.ToLower().Contains(SearchString) ||
            //                                                                         s.PatientId.ToLower().Contains(SearchString)).ToList();
            //Patients = new ObservableCollection<Patient>(p);
            if (!string.IsNullOrEmpty(SearchString)) _patientRepository.FindPatientsByValue(SearchString);
        });

        // возвращает данные из источника
        private static ObservableCollection<Patient> GetData(Source source)
        {
            try
            {
                // стринг указан пока для тестирования
                // в будущем должно быть:
                // _patientRepository = new PacientRepositoryEf(Source.ConnectinString);
                _patientRepository = new PacientRepositoryEf(@"Data Source = (localDb)\v11.0; AttachDbFilename = D:\FinalProject\Data\PatientServices.mdf; Integrated Security = True");
                var patients = _patientRepository.GetAllPatients().ToList();
                return new ObservableCollection<Patient>(patients);
            }
            catch (Exception e)
            {
                Messager.ShowConnectionErrorMessage(e);
                return null;
            }
        }

    }
}
