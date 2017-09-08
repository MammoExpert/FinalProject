using MammoExpert.PatientServices.PresenterCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using MammoExpert.PatientServices.Sources;
using MammoExpert.PatientServices.DB;

namespace MammoExpert.PatientServices.Demo.ViewModel
{
    public class ConfigurationWindowViewModel : SourcesWindowViewModel
    {
        #region Fields

        private delegate void AddSourceHandler(Source source);
        private event AddSourceHandler OnAddSource;
        private Source _source;
        private SourceType _type;
        private List<string> _listProviders;
        private DbConnectionConfiguration _configuration;
        #endregion // Fields

        #region Constructor

        public ConfigurationWindowViewModel(Source source)
        {
            base.DisplayName = Properties.Resources.ConfigurationWindowViewModel_DisplayName;
            Type = source.Type;   
            Source = source;
            if (source != null) OnAddSource += EditOrCreateSource;
            _configuration = new DbConnectionConfiguration();
            ListProviders = _configuration.GetListProviders();
            
        }

        #endregion // Constructor     
       
        #region Properties

        public Source Source
        {
            get { return _source; }
            set
            {
                _source = value;
                RaisePropertyChanged("Source");
            }
        }

        public SourceType Type
        {
            get { return _type; }
            set
            {
                _type = value;
                RaisePropertyChanged("Type");
            }
        }

        public List<string> ListProviders
        {
            get { return _listProviders; }
            set
            {
                _listProviders = value;
                RaisePropertyChanged("ListProviders");
            }
        }

        #endregion // Properties

        #region Commands

        public ICommand CancelCommand => new ActionCommand(() =>
        {
            CloseAction();
        });

        public ICommand CreateCommand => new ActionCommand(() =>
        {
            //Source.Description = Source.Name + " и прочее."; 
            if (OnAddSource != null) OnAddSource(Source);
            CloseAction();
        });

        public ICommand CheckDbConnectionCommand => new ActionCommand(() =>
        {
            _configuration.DbSource = SourceSerializer.DbDeserialize(Source);
            _configuration.GetStateConnection();
        });

        #endregion // Commands
    }
}
