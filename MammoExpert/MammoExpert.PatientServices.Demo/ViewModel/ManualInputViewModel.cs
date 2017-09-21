using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using MammoExpert.PatientServices.Core;
using MammoExpert.PatientServices.Demo.Properties;
using MammoExpert.PatientServices.Infrastructure;
using MammoExpert.PatientServices.PresenterCore;

namespace MammoExpert.PatientServices.Demo.ViewModel
{
    /// <summary>
    /// Модель представления элемента управления с ручным вводом пациента
    /// </summary>
    public class ManualInputViewModel : ViewModelBase
    {
        private Patient _patient;
        private readonly INotificationActionMessenger _actionMessenger;

        public ManualInputViewModel()
        {
            base.DisplayName = Resources.ManualInputViewModel_DisplayName;
            _actionMessenger = new NotificationActionMessenger();
            Patient = new Patient();
        }

        /// <summary>
        /// Содержит в себе данные нового пациента
        /// </summary>
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

        /// <summary>
        /// Подтверждает создание нового пациента
        /// </summary>
        public ICommand CreatePatientCommand => new ActionCommand(CreatePatient, param => Patient.IsValid);

        /// <summary>
        /// Сохраняет нового пациента
        /// </summary>
        private void CreatePatient()
        {
            _actionMessenger.ShowPatientCreationMessage();
        }
    }
}
