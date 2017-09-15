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

namespace MammoExpert.PatientServices.Demo.ViewModel
{
    /// <summary>
    /// Модель представления окна и элементов управления конфигурацией соединения
    /// </summary>
    public class ConfigurationWindowViewModel : ViewModelBase
    {
        #region Fields

        private Source _source;
        private SourceType _type;
        private List<string> _listProviders;
        private readonly DbConnectionConfiguration _configuration;
        private bool _isConnected;
        private readonly bool _isNew;
        private readonly SourcesWindowViewModel _parent;

        #endregion // Fields

        #region Constructor

        public ConfigurationWindowViewModel(ViewModelBase vm, Source source, bool isNew)
        {
            base.DisplayName = Resources.ConfigurationWindowViewModel_DisplayName;
            _parent = vm as SourcesWindowViewModel;
            _isNew = isNew;
            Type = source.Type;
            Source = source;
            _configuration = new DbConnectionConfiguration();
            ListProviders = _configuration.GetListProviders();
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
                _source = value;
                RaisePropertyChanged("Source");
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
        public SourceType Type
        {
            get { return _type; }
            set
            {
                _type = value;
                RaisePropertyChanged("Type");
            }
        }

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
        public ICommand CreateCommand => new ActionCommand(CallCreateOrUpdateEvent);

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
        /// Вызывает событие на редактирование или создание источника
        /// </summary>
        private void CallCreateOrUpdateEvent()
        {
            if (_isNew)
            {
                _parent.Create(Source);
            }
            else
            {
                _parent.Update(Source);
            }
            CloseAction();
        }

        /// <summary>
        /// Вызывает проверку подключения к базе данных
        /// </summary>
        private void CheckDbConnection()
        {
            _configuration.DbSource = SourceSerializer.DbDeserialize(Source);
            if (_configuration.GetStateConnection()) IsConnected = true;
        }

        /// <summary>
        /// Вызывает проверку подключения к рабочему списку DICOM
        /// </summary>
        private void CheckWorklistConnection() { }

        #endregion // Private Methods
    }
}
