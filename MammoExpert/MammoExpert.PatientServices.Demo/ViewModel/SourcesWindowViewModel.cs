using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using MammoExpert.PatientServices.PresenterCore;
using MammoExpert.PatientServices.Sources;
using System.Windows;
using MammoExpert.PatientServices.Core;
using MammoExpert.PatientServices.Infrastructure;

namespace MammoExpert.PatientServices.Demo.ViewModel
{
    /// <summary>
    /// Модель представления для окна настройки источников данных пациента
    /// </summary>
    public class SourcesWindowViewModel : ViewModelBase
    {
        #region Fields

        private List<SourceTypeOption> _sourceTypeOptions;
        private ObservableCollection<Source> _sources;
        private Source _selectedSource;
        private SourceTypeOption _selectedType;
        private static INotificationActionMessenger _actionMessenger;
        #endregion // Fields

        #region Constructor

        public SourcesWindowViewModel()
        {
            base.DisplayName = Properties.Resources.SourcesWindowViewModel_DisplayName;
            _sources = new ObservableCollection<Source>(App.SourceRepository.GetAll());
            App.SourceRepository.SourceList.CollectionChanged += OnSourcesChanged;
            _sourceTypeOptions = GetAllTypes();
            _actionMessenger = new NotificationActionMessenger();

        }

        #endregion // Constructor

        #region Properties

        /// <summary>
        /// Выбранный пользователем тип источника
        /// </summary>
        public SourceTypeOption SelectedType
        {
            get { return _selectedType; }
            set
            {
                if (_selectedType == value) return;
                _selectedType = value;
                RaisePropertyChanged("SelectedType");
            }
        }

        /// <summary>
        /// Выбранные пользователем источник
        /// </summary>
        public Source SelectedSource
        {
            get { return _selectedSource; }
            set
            {
                if (_selectedSource == value) return;
                _selectedSource = value;
                RaisePropertyChanged("SelectedSource");
            }
        }

        /// <summary>
        /// Список отображаемых источников
        /// </summary>
        public ObservableCollection<Source> Sources
        {
            get { return _sources; }
            set
            {
                if (_sources != value)
                {
                    _sources = value;
                    RaisePropertyChanged("Sources");
                    _sources.CollectionChanged += OnSourcesChanged;
                }

            }
        }

        /// <summary>
        /// Имеющиеся типы источников
        /// </summary>
        public List<SourceTypeOption> SourceTypeOptions
        {
            get { return _sourceTypeOptions; }
            set
            {
                if (_sourceTypeOptions != value)
                {
                    _sourceTypeOptions = value;
                    RaisePropertyChanged("SourceTypeOptions");
                }
            }
        }

        #endregion // Properties

        #region Commands

        // открыть окно для содания нового источника
        public ICommand AddSourceCommand => new ActionCommand<SourceTypeOption>(CreateSource, param => SelectedType != null);

        // открыть окно для редактирования источника
        public ICommand EditSourceCommand => new ActionCommand(EditSource, param => SelectedSource != null);

        // удалить выбранный источник
        public ICommand DeleteSourceCommand => new ActionCommand(DeleteSource, param => SelectedSource != null);

        #endregion // Commands

        #region Private Methods

        /// <summary>
        /// Обновляет список источников
        /// </summary>
        private void OnSourcesChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.NewItems != null && e.NewItems.Count != 0)
                foreach (Source source in e.NewItems)
                    Sources.Add(source);

            if (e.OldItems != null && e.OldItems.Count != 0)
                foreach (Source source in e.OldItems)
                    Sources.Remove(source);
        }

        /// <summary>
        /// Возвращает коллекцию объектов, описывающих типы источников
        /// </summary>
        private static List<SourceTypeOption> GetAllTypes()
        {
            var listOfTypes = Enum.GetValues(typeof(SourceTypeEnum)).Cast<SourceTypeEnum>().Select(value => value).ToList();
            return listOfTypes.Select(type => new SourceTypeOption(type)).ToList();
        }

        /// <summary>
        /// Создает окно для подключения к новому источнику, согласно выбранному типу источника
        /// </summary>
        private void CreateSource(SourceTypeOption option)
        {
            App.Factory.CreateConfigurationView(SelectedType.TypeEnum);
        }

        /// <summary>
        /// Создает окно для редактирования источника
        /// </summary>
        private void EditSource()
        {
            App.Factory.CreateUpdateConfigurationView(SelectedSource);
        }

        /// <summary>
        /// Удаляет источник
        /// </summary>
        private void DeleteSource()
        {
            if (SelectedSource == null) return;

            _actionMessenger.ShowAskToDeleteMessage(SelectedSource.Name, delegate ()
            {
                App.SourceRepository.Delete(SelectedSource);
            });
        }

        #endregion // Private Methods
    }
}
