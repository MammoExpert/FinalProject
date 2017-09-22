using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using MammoExpert.PatientServices.DB;
using MammoExpert.PatientServices.Demo.Properties;
using MammoExpert.PatientServices.PresenterCore;
using MammoExpert.PatientServices.Sources;
using MammoExpert.PatientServices.Worklist;
using MammoExpert.PatientServices.Core;
using MammoExpert.PatientServices.Infrastructure;

namespace MammoExpert.PatientServices.Demo.ViewModel
{
    /// <summary>
    /// Модель представления окна для создания элементов управления конфигурацией соединения
    /// </summary>
    public class ConfigurationWindowViewModel : ViewModelBase
    {
        #region Fields

        private Source _source;
        private List<string> _listProviders;
        private readonly INotificationConnectionMessenger _connectionMessenger;
        private readonly DbConnectionHelper _configuration;
        private bool _isConnected;
        private Source _previousSourceData;

        #endregion // Fields

        #region Constructor

        public ConfigurationWindowViewModel(SourceTypeEnum type)
        {
            base.DisplayName = Resources.ConfigurationWindowViewModel_DisplayName;
            _source = new Source(type);
            _configuration = new DbConnectionHelper();
            ListProviders = _configuration.GetListProviders();
            _connectionMessenger = new NotificationConnectionMessenger();
            CreateCommand = new ActionCommand(Create);
        }

        public ConfigurationWindowViewModel(Source source)
        {
            base.DisplayName = Resources.ConfigurationWindowViewModel_DisplayName;
            _previousSourceData = source;
            _source = new Source(source.TypeEnum) {Description = source.Description, Name = source.Name, Parameters = source.Parameters};
            _configuration = new DbConnectionHelper();
            ListProviders = _configuration.GetListProviders();
            _connectionMessenger = new NotificationConnectionMessenger();
            CreateCommand = new ActionCommand(Update);
        }
        #endregion // Constructor     

        #region Properties

        /// <summary>
        /// Текущий источник
        /// </summary>
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

        /// <summary>
        /// Флаг, говорящий о возможности подключения к источнику
        /// </summary>
        public bool IsConnected
        {
            get { return _isConnected; }
            set
            {
                _isConnected = value;
                RaisePropertyChanged("IsConnected");
            }
        }

        /// <summary>
        /// Тип текущего источника
        /// </summary>
        /// <remarks>
        /// По этому свойству определяется необходимый UserControl
        /// </remarks>
        public SourceTypeEnum TypeEnum => Source.TypeEnum;

        /// <summary>
        /// Содержит список провайдеров
        /// </summary>
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
        public ICommand CancelCommand => new ActionCommand(Cancel);

        // команда подтверждения на создание или редактирования источника
        public ICommand CreateCommand { get; protected set; }

        // команда проверки соедиения с базой данных
        public ICommand CheckDbConnectionCommand => new ActionCommand(CheckDbConnection);

        // команда проверки соединения с DICOM
        public ICommand CheckWorklistConnectionCommand => new ActionCommand(CheckWorklistConnection);

        #endregion // Commands

        #region Private Methods

        /// <summary>
        /// Закрывает окно без сохранения данных
        /// </summary>
        private void Cancel()
        {
            CloseAction();
        }

        /// <summary>
        /// Cоздает новый источник
        /// </summary>
        private void Create()
        {
            App.SourceRepository.Add(Source);
            CloseAction();
        }

        /// <summary>
        /// Вносит изменения в выбранный источник
        /// </summary>
        private void Update()
        {
            App.SourceRepository.Update(Source, _previousSourceData);
            CloseAction();
        }

        /// <summary>
        /// Вызывает проверку подключения к базе данных
        /// </summary>
        private void CheckDbConnection()
        {
            _configuration.DbSource = SourceSerializer.DbDeserialize(Source);
            try
            {
                if (_configuration.GetStateConnection())
                {
                    IsConnected = true;
                    _connectionMessenger.ShowConnectionSuccess("Соединение с базой данных установленно!");
                }
            }
            catch(Exception e)
            {
                IsConnected = false;
                _connectionMessenger.ShowConnectionErrorMessage(e);
            }          
        }

        /// <summary>
        /// Вызывает проверку подключения к рабочему списку DICOM
        /// </summary>
        private void CheckWorklistConnection()
        {
            try
            {
                var connectionHelper = new WorklistConnectionHelper();
                if (connectionHelper.CheckConnection(SourceSerializer.WorklistDeserialize(Source)))
                {
                    IsConnected = true;
                    _connectionMessenger.ShowConnectionSuccess("Соединение с Dicom Worklist установленно!");
                }
            }
            catch (Exception e)
            {
                IsConnected = false;
                _connectionMessenger.ShowConnectionErrorMessage(e);
            }
        }

        #endregion // Private Methods
    }
}
