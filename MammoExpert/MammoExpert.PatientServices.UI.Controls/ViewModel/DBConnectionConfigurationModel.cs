using System.Collections.Generic;
using System.Windows;
using System.Windows.Input;
using MammoExpert.PatientServices.Sources;
using MammoExpert.PatientServices.PresenterCore;
using MammoExpert.PatientServices.DB;
using MammoExpert.PatientServices.Core;

namespace MammoExpert.PatientServices.UI.Controls.ViewModel
{
    public class DBConnectionConfigurationModel: ViewModelBase
    {
        private IDataSourcePatient _service;
        private List<string> _listProviders;
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


        public DBConnectionConfigurationModel(){}

        public DBConnectionConfigurationModel(Source source)
        {
            
        }

        public ICommand CheckConnectionDb => new ActionCommand(() =>
        {
            _service = new PacientRepositoryEf("Data Source=(localdb)\v11.0;AttachDbFilename=../Data/PatientServices.mdf;Integrated Security=True");
            MessageBox.Show(string.Format("{0}", _service.CheckConnection()), "Проверка соединения",
                MessageBoxButton.OK);
        });



    }
}
