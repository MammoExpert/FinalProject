using System.Collections.Generic;
using System.Windows;
using System.Windows.Input;
using MammoExpert.PatientServices.Sources;
using MammoExpert.PatientServices.PresenterCore;
using MammoExpert.PatientServices.DB;
using MammoExpert.PatientServices.Core;
using System;
using MammoExpert.PatientServices.UI.Controls.Properties;

namespace MammoExpert.PatientServices.UI.Controls.ViewModel
{
    public class DBConnectionConfigurationModel: ViewModelBase, ISearchViewModel
    {
        private Source _source;

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


        public DBConnectionConfigurationModel()
        {
            base.DisplayName = Resources.DBConnectionConfigurationModel_DisplayName;
        }

        public DBConnectionConfigurationModel(Source source)
        {
            base.DisplayName = Resources.DBConnectionConfigurationModel_DisplayName;
            _source = source;

        }


        public void Search()
        {
            throw new NotImplementedException();
        }
    }
}
