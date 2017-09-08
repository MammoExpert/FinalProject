using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using MammoExpert.PatientServices.Demo.Properties;
using MammoExpert.PatientServices.PresenterCore;
using MammoExpert.PatientServices.Infrastructure;

namespace MammoExpert.PatientServices.Demo.ViewModel
{
    public class ManualInputViewModel : ViewModelBase
    {
        public ManualInputViewModel()
        {
            base.DisplayName = Resources.ManualInputViewModel_DisplayName;
        }

        public ICommand CreatePatientCommand => new ActionCommand(Messager.ShowPatientCreationMessage);
    }
}
