using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using MammoExpert.PatientServices.Infrastructure;
using MammoExpert.PatientServices.PresenterCore;
using MammoExpert.PatientServices.Sources;

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
        private MainWindowViewModel _parent;

        #endregion // Fields

        #region Constructor

        public SourcesWindowViewModel(ViewModelBase vm)
        {
            _parent = vm as MainWindowViewModel;
            base.DisplayName = Properties.Resources.SourcesWindowViewModel_DisplayName;
            if (_parent != null) Sources = new ObservableCollection<Source>(_parent.SourceRepository.GetAll());
            SourceTypeOptions = _sourceTypeOptions ?? (_sourceTypeOptions = GetAllTypes());
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
                if (_sources == value) return;
                _sources = value;
                RaisePropertyChanged("Sources");
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
                if (_sourceTypeOptions == value) return;
                _sourceTypeOptions = value;
                RaisePropertyChanged("SourceTypeOptions");
            }
        }

        #endregion // Properties

        #region Commands

        // открыть рабочую область в новой вкладке
        public ICommand AddWorkspaceCommand => new ActionCommand(AddWorkspace);

        // открыть окно для содания нового источника
        public ICommand AddSourceCommand => new ActionCommand<SourceTypeOption>(CreateSource, param => SelectedType != null);

        // открыть окно для редактирования источника
        public ICommand EditSourceCommand => new ActionCommand(EditSource, param => SelectedSource != null);

        // удалить выбранный источник
        public ICommand DeleteSourceCommand => new ActionCommand(DeleteSource, param => SelectedSource != null);

        // срабатывает при смене значения в ComboBox
        public ICommand ChangeSourceListByType => new ActionCommand<SourceTypeOption>(param => ChangeSourceList(param.TypeEnum));

        #endregion // Commands

        #region Public Methods

        /// <summary>
        /// Добавляет новый источник
        /// </summary>
        public void Create(Source source)
        {
            _parent.SourceRepository.Add(source);
            ChangeSourceList(source.TypeEnum);
        }

        /// <summary>
        /// Сохраняет в существующий источник новые данные
        /// </summary>
        public void Update(Source source)
        {
            foreach (var s in Sources)
            {
                if (s.Id == source.Id)
                {
                    _parent.SourceRepository.Update(source);
                    ChangeSourceList(source.TypeEnum);
                }
            }
        }

        #endregion // Public Methods

        #region Private Methods

        /// <summary>
        /// Возвращает коллекцию объектов, описывающих типы источников
        /// </summary>
        private static List<SourceTypeOption> GetAllTypes()
        {
            var listOfTypes = Enum.GetValues(typeof(SourceTypeEnum)).Cast<SourceTypeEnum>().Select(value => value).ToList();
            return listOfTypes.Select(type => new SourceTypeOption(type)).ToList();
        }

        /// <summary>
        /// Создает рабочую область поиска пациента в заданном источнике
        /// </summary>
        private void AddWorkspace()
        {
            if (SelectedSource == null) return;
            var ws = new PatientSearchViewModel(_parent, SelectedSource);
            if (ws.Patients == null) return;
            if (IsOpened(ws)) _parent.WorkspaceRepository.SetActiveWorkspace(ws);
            else _parent.WorkspaceRepository.Create(ws);
            CloseAction();
        }

        /// <summary>
        /// Возвращает true, если такая рабочая область уже открыта
        /// </summary>
        private bool IsOpened(ViewModelBase ws)
        {
            return _parent.Workspaces.Any(item => item.DisplayName == ws.DisplayName);
        }

        /// <summary>
        /// Создает окно для подключения к новому источнику, согласно выбранному типу источника
        /// </summary>
        private void CreateSource(SourceTypeOption option)
        {
            ViewFactory.CreateConfigurationView(this, new Source(option.TypeEnum), true);
        }

        /// <summary>
        /// Создает окно для редактирования источника
        /// </summary>
        private void EditSource()
        {
            ViewFactory.CreateConfigurationView(this, SelectedSource, false);
        }

        /// <summary>
        /// Удаляет источник
        /// </summary>
        private void DeleteSource()
        {
            if (SelectedSource == null) return;
            Messenger.ShowAskToDeleteMessage(SelectedSource.Name, delegate ()
            {
                var vm = FindWorkspace();
                if (vm != null) _parent.WorkspaceRepository.Delete(vm);
                _parent.SourceRepository.Delete(SelectedSource);
                ChangeSourceList(SelectedSource.TypeEnum);
            });
        }

        /// <summary>
        /// Находит среди списка открытых рабочих областей ту, которая относитчя к выбранному источнику
        /// </summary>
        private ViewModelBase FindWorkspace()
        {
            foreach (var item in _parent.Workspaces)
            {
                if (item.GetType() == typeof(PatientSearchViewModel))
                {
                    if (item.DisplayName == SelectedSource.Name)
                    {
                        if (_parent.Workspaces.Contains(item)) return item;
                    }
                }
            }
            return null;
        }

        /// <summary>
        /// Обновляет список источников согласно выбранному типу источника
        /// </summary>
        private void ChangeSourceList(SourceTypeEnum typeEnum)
        {
            var collection = _parent.SourceRepository.GetByType(typeEnum);
            Sources = new ObservableCollection<Source>(collection);
        }

        #endregion // Private Methods
    }
}
