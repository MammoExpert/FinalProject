using MammoExpert.PatientServices.PresenterCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Versioning;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using MammoExpert.PatientServices.Sources;
using MammoExpert.PatientServices.DB;
using MammoExpert.PatientServices.Demo.Properties;

namespace MammoExpert.PatientServices.Demo.ViewModel
{
    public class ConfigurationWindowViewModel : SourcesWindowViewModel
    {
        #region Fields
 
        private Source _source;
        private SourceType _type;
        private List<string> _listProviders;
        private readonly DbConnectionConfiguration _configuration;
        private bool _isConnected;
        private readonly bool _isNew;

        private delegate void SourceEventHandler(Source source);
        private event SourceEventHandler OnCreate, OnUpdate;

        #endregion // Fields

        #region Constructor

        public ConfigurationWindowViewModel(Source source, bool isNew)
        {
            base.DisplayName = Resources.ConfigurationWindowViewModel_DisplayName;
            _isNew = isNew;
            Type = source.Type;   
            Source = source;
            OnCreate += Create;
            OnUpdate += Update;
            _configuration = new DbConnectionConfiguration();
            ListProviders = _configuration.GetListProviders();        
        }

        #endregion // Constructor     
       
        #region Properties

        // текущий источник
        public Source Source
        {
            get { return _source; }
            set
            {
                _source = value;
                RaisePropertyChanged("Source");
            }
        }

        // флаг, говорящий о возможности подключения к источнику
        public bool IsConnected
        {
            get { return _isConnected; }
            set
            {
                _isConnected = value;
                RaisePropertyChanged("IsConnected");
            }
        }

        // тип источника, по нему мы определяем необходимый UserControl
        public SourceType Type
        {
            get { return _type; }
            set
            {
                _type = value;
                RaisePropertyChanged("Type");
            }
        }

        // список провайдеров
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

        // команда отмены настройки источника
        public ICommand CancelCommand => new ActionCommand(() =>
        {
            CloseAction();
        });

        // команда подтверждения на создание источника
        public ICommand CreateCommand => new ActionCommand(() =>
        {
            if (_isNew)
            {
                if (OnCreate != null) OnCreate(Source);
            }
            else
            {
                if (OnUpdate != null) OnUpdate(Source);
            }
            CloseAction();
        }, param => IsConnected);

        // команда проверки соедиения с базой данных
        public ICommand CheckDbConnectionCommand => new ActionCommand(() =>
        {
            _configuration.DbSource = SourceSerializer.DbDeserialize(Source);
            if (_configuration.GetStateConnection()) IsConnected = true;
        });

        // команда проверки соединения с DICOM
        public ICommand CheckWorklistConnectionCommand => new ActionCommand(() =>
        {
            
        });

        #endregion // Commands
    }
}
