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
    public class DBConnectionConfigurationModel : ViewModelBase
    {
        #region Fields

        private Source _source;

        #endregion // Fields

        #region Constructor

        public DBConnectionConfigurationModel(Source source)
        {
            base.DisplayName = Resources.DBConnectionConfigurationModel_DisplayName;
            Source = source;
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

        #region Commands

        public ICommand CreateCommand => new ActionCommand(Create);

        #endregion // Commands

        #region Private Methods

        private void Create()
        {
            MessageBox.Show(
                "Типа создали что-то",
                "Подтверждение",
                MessageBoxButton.OK,
                MessageBoxImage.Information);
            base.CloseAction();
        }

        #endregion // Private Methods
    }
}
