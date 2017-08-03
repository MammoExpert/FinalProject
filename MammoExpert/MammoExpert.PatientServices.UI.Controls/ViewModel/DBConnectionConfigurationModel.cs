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
        private IDataSourcePatient _service;
        private List<string> _listProviders;
        private Source _source;

        public List<string> ListProviders
        {
            get { return _listProviders; }
            set
            {
                if (_listProviders != value)
                {
                    _listProviders = new List<string>() { "SqlClient Data Provider", "Oracle Data Provider" };
                    RaisePropertyChanged("ListProviders");
                }
            }
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


        public DBConnectionConfigurationModel()
        {
            base.DisplayName = Resources.DBConnectionConfigurationModel_DisplayName;
        }

        public DBConnectionConfigurationModel(Source source)
        {
            base.DisplayName = Resources.DBConnectionConfigurationModel_DisplayName;
            _source = source;

        }

        public ICommand CheckConnectionDb => new ActionCommand(() =>
        {
            _service = new PacientRepositoryEf("Data Source=(localdb)\v11.0;AttachDbFilename=../Data/PatientServices.mdf;Integrated Security=True");
            MessageBox.Show(string.Format("{0}", _service.CheckConnection()), "Проверка соединения",
                MessageBoxButton.OK);
        });

        public void Search()
        {
            throw new NotImplementedException();
        }
    }
}
