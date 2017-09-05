using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using MammoExpert.PatientServices.Demo.Properties;
using MammoExpert.PatientServices.PresenterCore;
using MammoExpert.PatientServices.Sources;

namespace MammoExpert.PatientServices.Demo.ViewModel
{
    public class WorklistConnectionConfigurationModel : ViewModelBase
    {
        #region Fields

        private Source _source;

        #endregion //Fields

        #region Constructor

        public WorklistConnectionConfigurationModel(Source source)
        {
            base.DisplayName = Resources.WorklistConnectionConfigurationModel_DisplayName;
            _source = source;
        }

        #endregion // Constructor

        #region Properties

        public Source Source
        {
            get { return _source; }
            set
            {
                if (_source != value)
                {
                    _source = value;
                    RaisePropertyChanged("Source");
                }
            }
        }

        #endregion // Properties

        public ICommand CreateCommand => new ActionCommand(() =>
        {
            MessageBox.Show(
                "Источник создан",
                "Подтверждение",
                MessageBoxButton.OK,
                MessageBoxImage.Information);
        });
    }
}
