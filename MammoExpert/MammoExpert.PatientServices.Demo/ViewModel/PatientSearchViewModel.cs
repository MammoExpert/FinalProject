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
        public PatientSearchViewModel(Source source)
        {
            base.DisplayName = source.Name;
            //var data = GetData(source);            
            // для теста
            var data = new List<Patient>()
            {
                new Patient() {PatientId = "12", FirstName = "Иван", LastName = "Кудин", BirthDate = new DateTime(1988, 02, 12), MiddleName = "Сергеевич", NumberOfPassport = "МР1234589", Telephone = "+375296548596"},
                new Patient() {PatientId = "23", FirstName = "Сергей", LastName = "Береза", BirthDate = new DateTime(1956, 01, 01).Date, MiddleName = "Олегович", NumberOfPassport = "МР1250006", Telephone = "+375295478122"},
                new Patient() {PatientId = "581", FirstName = "Светлана", LastName = "Дмитрюкова", Sex = Sex.Female, BirthDate = new DateTime(2001, 12, 30).Date, MiddleName = "Васильевна", NumberOfPassport = "МР7774529", Telephone = "+375299652333"}
            };

            if (data != null) _patients = new ObservableCollection<Patient>(data);
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

        public ICommand CrearSearchAreaCommand => new ActionCommand(() =>
        {
            SearchString = string.Empty;
        });

        // возвращает данные из источника
        private static List<Patient> GetData(Source source)
        {
            try
            {
                // стринг указан пока для тестирования
                // в будущем должно быть:
                // var rep = new PacientRepositoryEf(Source.ConnectinString);
                var rep = new PacientRepositoryEf(@"Data Source = (localDb)\v11.0; AttachDbFilename = D:\FinalProject\Data\PatientServices.mdf; Integrated Security = True");
                var patients = rep.GetAllPatients().ToList();
                return patients;
            }
            catch (Exception e)
            {
                Messager.ShowConnectionErrorMessage(e);
                return null;
            }
        }

    }
}
