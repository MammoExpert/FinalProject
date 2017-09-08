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
            if (sourcesList != null) _sources = new ObservableCollection<Source>(sourcesList);
            SourceTypeOptions = _sourceTypeOptions ?? (_sourceTypeOptions = GetAllTypes());
        }

        #endregion // Constructor

        #region Properties

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

        public ICommand AddWorkspaceCommand => new ActionCommand(AddWorkspace);

        public ICommand AddSourceCommand => new ActionCommand<SourceTypeOption>(CreateSource, param => SelectedType != null);

        public ICommand EditSourceCommand => new ActionCommand(EditSource, param => SelectedSource != null);

        public ICommand DeleteSourceCommand => new ActionCommand(DeleteSource, param => SelectedSource != null);

        public ICommand ChangeSourceListByType => new ActionCommand<SourceTypeOption>(param => ChangeSourceList(param.Type));

        #endregion // Commands

        #region Public Methods

        public void EditOrCreateSource(Source source)
        {
            foreach (var s in Sources)
            {
                if (s.Id == source.Id)
                {
                    SourceRepository.Edit(source);
                }
            }
            SourceRepository.Create(source);
            ChangeSourceList(source.Type);
        }

        #endregion // Public Methods

        #region Private Methods

        // получает коллекцию объектов, описывающих типы источников
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
            if (IsOpened(ws)) WorkspaceRepository.SetActiveWorkspace(ws);
            else WorkspaceRepository.Add(ws);        
            CloseAction();
        }

        private bool IsOpened(ViewModelBase ws)
        {
            return Workspaces.Any(item => item.DisplayName == ws.DisplayName);
        }

        // создает окно для подключения к новому источнику, согласно выбранному типу источника
        private void CreateSource(SourceTypeOption option)
        {
            ViewFactory.CreateConfigurationView(new Source(option.Type));
        }

        // создает окно для редактирования источника
        private void EditSource()
        {
            ViewFactory.CreateConfigurationView(SelectedSource);
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
