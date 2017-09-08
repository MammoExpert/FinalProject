using System.Collections.Generic;
using System.Windows.Input;
using MammoExpert.PatientServices.DB;
using MammoExpert.PatientServices.Sources;
using MammoExpert.PatientServices.PresenterCore;
using System;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Linq;
using System.Windows;
using System.Windows.Forms;
using MammoExpert.PatientServices.Core;
using MammoExpert.PatientServices.Infrastructure;

namespace MammoExpert.PatientServices.Demo.ViewModel
{
    public class SourcesWindowViewModel : MainWindowViewModel
    {
        #region Fields

        private List<SourceTypeOption> _sourceTypeOptions;
        private ObservableCollection<Source> _sources;
        private Source _selectedSource;
        private SourceTypeOption _selectedType;

        #endregion // Fields

        #region Constructor

        public SourcesWindowViewModel()
        {
            base.DisplayName = Properties.Resources.SourcesWindowViewModel_DisplayName;
            var sourcesList = SourceRepository.GetAll();
            if (sourcesList != null) Sources = new ObservableCollection<Source>(sourcesList);
            SourceTypeOptions = _sourceTypeOptions ?? (_sourceTypeOptions = GetAllTypes());
        }

        #endregion // Constructor

        #region Properties

        // выбранный тип источника из ComboBox
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

        // выбранный источник
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

        // список отображаемых источников
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

        // здесь храним все типы источников для отображения в ComboBox
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
        public ICommand ChangeSourceListByType => new ActionCommand<SourceTypeOption>(param => ChangeSourceList(param.Type));

        #endregion // Commands

        #region Public Methods

        // добавляет новый источник
        public void Create(Source source)
        {
            SourceRepository.Create(source);
            ChangeSourceList(source.Type);
        }

        // сохраняет в существующий источник новые данные
        public void Update(Source source)
        {
            foreach (var s in Sources)
            {
                if (s.Id == source.Id)
                {
                    SourceRepository.Update(source);
                    ChangeSourceList(source.Type);
                }
            }
        }

        #endregion // Public Methods

        #region Private Methods

        // возвращает коллекцию объектов, описывающих типы источников
        private static List<SourceTypeOption> GetAllTypes()
        {
            var listOfTypes = Enum.GetValues(typeof(SourceType)).Cast<SourceType>().Select(value => value).ToList();
            return listOfTypes.Select(type => new SourceTypeOption(type)).ToList();
        }

        // создает рабочую область поиска пациента в заданном источнике
        private void AddWorkspace()
        {
            if (SelectedSource == null) return;
            var ws = new PatientSearchViewModel(SelectedSource);
            if(ws.Patients == null) return;
            if (IsOpened(ws)) WorkspaceRepository.SetActiveWorkspace(ws);
            else WorkspaceRepository.Add(ws);        
            CloseAction();
        }

        // проверяет, открытали уже такая область/вкладка
        private bool IsOpened(ViewModelBase ws)
        {
            return Workspaces.Any(item => item.DisplayName == ws.DisplayName);
        }

        // создает окно для подключения к новому источнику, согласно выбранному типу источника
        private void CreateSource(SourceTypeOption option)
        {
            ViewFactory.CreateConfigurationView(new Source(option.Type), true);
        }

        // создает окно для редактирования источника
        private void EditSource()
        {
            ViewFactory.CreateConfigurationView(SelectedSource, false);
        }

        // удаляет источник
        private void DeleteSource()
        {
            if (SelectedSource == null) return;
            Messager.ShowAskToDeleteMessage(SelectedSource.Name, delegate ()
            {
                var vm = FindWorkspace();
                if (vm != null) WorkspaceRepository.Delete(vm);
                SourceRepository.Delete(SelectedSource);
                ChangeSourceList(SelectedSource.Type);              
            });
        }

        // находит среди списка открытых рабочих областей ту, которая относитчя к выбранному источнику
        private ViewModelBase FindWorkspace()
        {
            foreach (var item in Workspaces)
            {
                if (item.GetType() == typeof(PatientSearchViewModel))
                {
                    if (item.DisplayName == SelectedSource.Name)
                    {
                        if (Workspaces.Contains(item)) return item;
                    }
                }
            }
            return null;
        }

        // обновляет список источников согласно выбранному типу источника
        private void ChangeSourceList(SourceType type)
        {
            var collection = SourceRepository.GetByType(type);
            if (collection != null) Sources = new ObservableCollection<Source>(collection);
        }

        #endregion // Private Methods
    }
}
