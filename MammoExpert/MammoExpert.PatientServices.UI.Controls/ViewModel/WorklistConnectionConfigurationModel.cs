using System;
using MammoExpert.PatientServices.PresenterCore;
using MammoExpert.PatientServices.Sources;
using MammoExpert.PatientServices.UI.Controls.Properties;

namespace MammoExpert.PatientServices.UI.Controls.ViewModel
{
    public class WorklistConnectionConfigurationModel : ViewModelBase, ISearchViewModel
    {
        private Source _source;

        public WorklistConnectionConfigurationModel()
        {
            base.DisplayName = Resources.WorklistConnectionConfigurationModel_DisplayName;
        }

        public WorklistConnectionConfigurationModel(Source source)
        {
            base.DisplayName = Resources.WorklistConnectionConfigurationModel_DisplayName;
            _source = source;
        }

        public Source Source
        {
            get { return _source; }
            set
            {
                if (_source != value)
                {
                    _source = new Source();
                    RaisePropertyChanged("Source");
                }
            }
        }

        public void Search()
        {
            throw new NotImplementedException();
        }
    }
}
