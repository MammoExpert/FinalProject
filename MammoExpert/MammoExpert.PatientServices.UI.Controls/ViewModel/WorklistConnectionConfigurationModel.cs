using MammoExpert.PatientServices.PresenterCore;
using MammoExpert.PatientServices.Sources;
using MammoExpert.PatientServices.UI.Controls.Properties;

namespace MammoExpert.PatientServices.UI.Controls.ViewModel
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
    }
}
