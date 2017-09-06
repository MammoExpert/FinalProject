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
using MammoExpert.PatientServices.Core;

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
        public List<SourceTypeOption> SourceTypeOptions => _sourceTypeOptions ?? (_sourceTypeOptions = GetAllTypes());

        #endregion // Properties

        #region Commands

        public ICommand AddWorkspaceCommand => new ActionCommand(AddWorkspace);

        public ICommand AddSourceCommand => new ActionCommand<SourceTypeOption>(CreateSource, param => SelectedType != null);

        public ICommand EditSourceCommand => new ActionCommand(EditSource, param => SelectedSource != null);

        public ICommand DeleteSourceCommand => new ActionCommand(DeleteSource, param => SelectedSource != null);

        public ICommand ChangeSourceListByType => new ActionCommand<SourceTypeOption>(param => ChangeSourceList(param.Type));

        #endregion // Commands

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

            // для теста
            //var data = new List<Patient>()
            //{
            //    new Patient() {PatientId = "12", FirstName = "Иван", LastName = "Кудин", BirthDate = new DateTime(1988, 02, 12), MiddleName = "Сергеевич", NumberOfPassport = "МР1234589", Telephone = "+375296548596"},
            //    new Patient() {PatientId = "23", FirstName = "Сергей", LastName = "Береза", BirthDate = new DateTime(1956, 01, 01).Date, MiddleName = "Олегович", NumberOfPassport = "МР1250006", Telephone = "+375295478122"},
            //    new Patient() {PatientId = "581", FirstName = "Светлана", LastName = "Дмитрюкова", Sex = Sex.Female, BirthDate = new DateTime(2001, 12, 30).Date, MiddleName = "Васильевна", NumberOfPassport = "МР7774529", Telephone = "+375299652333"}
            //};

            WorkspaceRepository.Add(new PatientSearchViewModel(SelectedSource));
            CloseAction();
        }

        // создает окно для подключения к новому источнику, согласно выбранному типу источника
        private void CreateSource(SourceTypeOption option)
        {
            ViewFactory.CreateConfigurationView(this, new Source(option.Type));
        }

        // создает окно для редактирования источника
        private void EditSource()
        {
            ViewFactory.CreateConfigurationView(this, SelectedSource);
        }

        // удаляет источник
        private void DeleteSource()
        {
            if (SelectedSource == null) return;
            Messager.ShowAskToDeleteMessage(SelectedSource.Name, delegate ()
            {
                SourceRepository.Delete(SelectedSource);
                ChangeSourceList(SelectedSource.Type);
                //WorkspaceRepository.Delete(???);
            });
        }

        // обновляет список источников согласно выбранному типу источника
        private void ChangeSourceList(SourceType type)
        {
            var collection = SourceRepository.GetByType(type);
            if (collection != null) Sources = new ObservableCollection<Source>(collection);
        }

        public void AddOrCreateSource(Source source)
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

        #endregion // Private Methods
    }
}
