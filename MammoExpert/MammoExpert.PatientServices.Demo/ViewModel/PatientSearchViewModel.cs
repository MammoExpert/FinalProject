using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
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
            var data = GetData(source);
            if(data != null) _patients = new ObservableCollection<Patient>(data);
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
