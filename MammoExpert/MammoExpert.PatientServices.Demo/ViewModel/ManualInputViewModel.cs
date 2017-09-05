using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using MammoExpert.PatientServices.Demo.Properties;
using MammoExpert.PatientServices.PresenterCore;

namespace MammoExpert.PatientServices.Demo.ViewModel
{
    public class ManualInputViewModel : ViewModelBase
    {
        public ManualInputViewModel()
        {
            base.DisplayName = Resources.ManualInputViewModel_DisplayName;
        }

        public ICommand CreatePatientCommand => new ActionCommand(() =>
        {
            MessageBox.Show(
                "Пациент создан",
                "Подтверждение",
                MessageBoxButton.OK,
                MessageBoxImage.Information);
        });
    }
}
