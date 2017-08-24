using System.Collections.Generic;
using System.Windows.Input;
using MammoExpert.PatientServices.Demo.Properties;
using MammoExpert.PatientServices.Sources;
using MammoExpert.PatientServices.PresenterCore;
using MammoExpert.PatientServices.UI.Controls.ViewModel;
using System;
using System.Linq;

namespace MammoExpert.PatientServices.Demo.ViewModel
{
    public class SourcesWindowViewModel : MainWindowViewModel
    {
        private List<SourceType> _sourceTypeOptions;
        private List<Source> _sources;

        public SourcesWindowViewModel()
        {

            base.DisplayName = Resources.SourcesWindowViewModel_DisplayName;

            LoadAllSources();
        }

        // список отображаемых источников
        public List<Source> Sources
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

        public ICommand AddWorkspaceCommand => new ActionCommand<Source>(AddWorkspace);

        public ICommand AddSourceCommand => new ActionCommand<SourceType>(OpenConfigurationWindow);

        public ICommand EditSourceCommand => new ActionCommand<Source>(EditSource);

        public ICommand DeleteSourceCommand => new ActionCommand<Source>(DeleteSource);

        public ICommand ChangeSourceListByType => new ActionCommand<SourceType>(ChangeSourceList);

        public void AddWorkspace(Source source)
        {
            if (source != null)
            {
                CreateWorkspace(new PatientSearchViewModel(source));
                CloseAction();
            }
        }

        public void EditSource(Source source)
        {
            if (source != null) WindowFactory.CreateConfigurationWindow(source);
        }

        public void DeleteSource(Source source)
        {
            if (source != null)
            {
                SourceRepository.DeleteSource(source);
            }
        }

        public void OpenConfigurationWindow(SourceType type)
        {
            WindowFactory.CreateConfigurationWindow(type);
        }

        // метод, загружающий источники всех типов
        private void LoadAllSources()
        {
            if (SourceRepository != null)
            {
                _sources = SourceRepository.GetAllSources();
            }
        }

        // метод, обновляющий список источников согласно выбранному типу источника
        private void ChangeSourceList(SourceType type)
        {
            Sources = SourceRepository.GetSourcesByType(type);
        }
    }
}
