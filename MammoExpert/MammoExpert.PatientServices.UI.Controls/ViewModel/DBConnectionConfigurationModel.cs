﻿using System.Windows.Input;
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

        #region Constructors

        public DBConnectionConfigurationModel()
        {
            base.DisplayName = Resources.DBConnectionConfigurationModel_DisplayName;
            _source = new Source(type: SourceType.DataBase);
        }

        public DBConnectionConfigurationModel(Source source)
        {
            base.DisplayName = Resources.DBConnectionConfigurationModel_DisplayName;
            _source = source;

        }

        #endregion // Constructors

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
