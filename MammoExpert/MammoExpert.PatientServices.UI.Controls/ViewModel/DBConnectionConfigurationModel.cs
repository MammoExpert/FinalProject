using System.Windows.Input;
using MammoExpert.PatientServices.Sources;
using MammoExpert.PatientServices.PresenterCore;
using MammoExpert.PatientServices.UI.Controls.Properties;

namespace MammoExpert.PatientServices.UI.Controls.ViewModel
{
    public class DBConnectionConfigurationModel: ViewModelBase
    {
        #region Fields

        private Source _source;

        #endregion // Fields

        #region Constructor

        public DBConnectionConfigurationModel(Source source)
        {
            base.DisplayName = Resources.DBConnectionConfigurationModel_DisplayName;
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

        #region Commands

        public ICommand CancelCreateConnectionDbCommand => new ActionCommand(Create);

        #endregion // Commands

        #region Private Methods

        private void Create()
        {
            
            CloseAction();
        }

        #endregion // Private Methods
    }
}
