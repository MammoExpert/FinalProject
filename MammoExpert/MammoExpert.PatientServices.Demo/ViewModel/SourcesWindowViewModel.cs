using System.Collections.Generic;
using System.Windows.Input;
using MammoExpert.PatientServices.DB;
using MammoExpert.PatientServices.Sources;
using MammoExpert.PatientServices.PresenterCore;
using MammoExpert.PatientServices.UI.Controls.ViewModel;
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

        private List<SourceType> _sourceTypeOptions;
        private ObservableCollection<Source> _sources;

        #endregion // Fields

        #region Constructor

        public SourcesWindowViewModel()
        {
            base.DisplayName = Properties.Resources.SourcesWindowViewModel_DisplayName;

            _sources = new ObservableCollection<Source>(SourceRepository.GetAll());
        }

        #endregion // Constructor

        #region Properties

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
        public List<SourceType> SourceTypeOptions
        {
            get
            {
                if (_sourceTypeOptions == null)
                {
                    _sourceTypeOptions = Enum.GetValues(typeof(SourceType)).Cast<SourceType>().Select(v => v).ToList();
                }
                return _sourceTypeOptions;
            }
        }

        #endregion // Properties

        #region Commands

        public ICommand AddWorkspaceCommand => new ActionCommand<Source>(AddWorkspace);

        public ICommand AddSourceCommand => new ActionCommand<SourceType>(CreateSource);

        public ICommand EditSourceCommand => new ActionCommand<Source>(EditSource);

        public ICommand DeleteSourceCommand => new ActionCommand<Source>(DeleteSource);

        public ICommand ChangeSourceListByType => new ActionCommand<SourceType>(ChangeSourceList);

        #endregion // Commands

        #region Private Methods

        // создает рабочую область поиска пациента в заданном источнике
        private void AddWorkspace(Source source)
        {
            if (source != null)
            {
                var data = GetData(source);
                if (data != null)
                {
                    base.CreateWorkspace(new PatientSearchViewModel(source.Name, data));
                    CloseAction();
                }              
            }
        }

        // возвращает данные из источника
        private List<Patient> GetData(Source source)
        {
            try
            {
                List<Patient> patients;
                // стринг указан пока для тестирования
                var rep = new PacientRepositoryEf();
                patients = (List<Patient>)rep.GetAllPatients();
                return patients;//(List<Patient>)rep.GetAllPatients();
            }
            catch (Exception e)
            {
                MessageBoxResult result = MessageBox.Show(
                    "Не возможно подключиться к " + source.Name + "\n" + e.Message,
                    "Ошибка подключения",
                    MessageBoxButton.OK,
                    MessageBoxImage.Error);
            }
            return null;
        }

        // создает окно для подключения к новому источнику, согласно выбранному типу источника
        private void CreateSource(SourceType type)
        {
            ViewFactory.CreateConfigurationWindow(type);
        }

        // создает окно для редактирования источника
        private void EditSource(Source source)
        {
            if (source != null) ViewFactory.CreateConfigurationWindow(source);
        }

        // удаляет источник
        private void DeleteSource(Source source)
        {
            if (source != null)
            {
                MessageBoxResult result = MessageBox.Show(
                "Вы уверены, что хотите удалить " + source.Name  + "?",
                "ВНИМАНИЕ!!!",
                MessageBoxButton.YesNo,
                MessageBoxImage.Question);
                if (result == MessageBoxResult.Yes)
                {
                    SourceRepository.Delete(source);
                    ChangeSourceList(source.Type);
                }
            }
        }
        
        // обновляет список источников согласно выбранному типу источника
        private void ChangeSourceList(SourceType type)
        {
            var collection = SourceRepository.GetByType(type);
            Sources = new ObservableCollection<Source>(collection);
        }

        #endregion // Private Methods
    }
}
