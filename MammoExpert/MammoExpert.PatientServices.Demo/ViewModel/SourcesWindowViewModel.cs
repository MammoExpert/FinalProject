using System.Collections.Generic;
using System.Windows.Input;
using MammoExpert.PatientServices.Demo.Properties;
using MammoExpert.PatientServices.Sources;
using MammoExpert.PatientServices.PresenterCore;
using MammoExpert.PatientServices.UI.Controls.ViewModel;
using System;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Windows;

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
            base.DisplayName = Resources.SourcesWindowViewModel_DisplayName;

            _sources = new ObservableCollection<Source>(SourceRepository.GetAllSources());
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

        public ICommand AddSourceCommand => new ActionCommand<SourceType>(OpenConfigurationWindow);

        public ICommand EditSourceCommand => new ActionCommand<Source>(EditSource);

        public ICommand DeleteSourceCommand => new ActionCommand<Source>(DeleteSource);

        public ICommand ChangeSourceListByType => new ActionCommand<SourceType>(ChangeSourceList);

        #endregion // Commands

        #region Private Methods

        private void AddWorkspace(Source source)
        {
            if (source != null)
            {
                CreateWorkspace(new PatientSearchViewModel(source));
                CloseAction();
            }
        }

        private void OpenConfigurationWindow(SourceType type)
        {
            WindowFactory.CreateConfigurationWindow(type);
        }

        private void EditSource(Source source)
        {
            if (source != null) WindowFactory.CreateConfigurationWindow(source);
        }

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
                    SourceRepository.DeleteSource(source);
                    ChangeSourceList(source.Type);
                }
            }
        }
        
        // метод, обновляющий список источников согласно выбранному типу источника
        private void ChangeSourceList(SourceType type)
        {
            var collection = SourceRepository.GetSourcesByType(type);
            Sources = new ObservableCollection<Source>(collection);
        }

        #endregion // Private Methods
    }
}
