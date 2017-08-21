using System.Collections.Generic;
using System.Windows.Input;
using MammoExpert.PatientServices.Demo.Properties;
using MammoExpert.PatientServices.Sources;
using MammoExpert.PatientServices.PresenterCore;
using MammoExpert.PatientServices.UI.Controls.ViewModel;


namespace MammoExpert.PatientServices.Demo.ViewModel
{
    public class SourcesWindowViewModel : MainWindowViewModel
    {
        private string _type;
        private string[] _sourceTypeOptions;
        private Source _selectedSource;
        private List<Source> _sources;

        public SourcesWindowViewModel()
        {

            base.DisplayName = Resources.SourcesWindowViewModel_DisplayName;
            _type = Resources.SourcesWindowViewModel_SourceTypeOption_NotSpecified;

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

        // выбранный пользователем тип источника; от него будет зависеть список отображаемых источников
        public string Type
        {
            get { return _type; }
            set
            {
                if (value == _type || string.IsNullOrEmpty(value))
                    return;

                _type = value;

                ChangeSourceListByType();

                RaisePropertyChanged("Type");
            }
        }

        // здесь храним все типы источников для отображения в ComboBox
        public string[] SourceTypeOptions
        {
            get
            {
                if (_sourceTypeOptions == null)
                {
                    _sourceTypeOptions = new[]
                    {
                        Resources.SourcesWindowViewModel_SourceTypeOption_NotSpecified,
                        Resources.SourcesWindowViewModel_SourceTypeOption_DataBase,
                        Resources.SourcesWindowViewModel_SourceTypeOption_Worklist
                    };
                }
                return _sourceTypeOptions;
            }
        }

        // выбранный пользователем источник
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

        public ICommand AddWorkspaceCommand => new ActionCommand(() =>
        {
            Workspaces.Add(new PatientSearchViewModel(SelectedSource));
            CloseAction();
        });

        public ICommand AddSourceCommand => new ActionCommand(() =>
        {
            if (_type != string.Empty)
            {
                if (_type == Resources.SourcesWindowViewModel_SourceTypeOption_DataBase)
                    WindowFacrtory.CreateConfigurationWindow(SourceType.DataBase);
                if (_type == Resources.SourcesWindowViewModel_SourceTypeOption_Worklist)
                    WindowFacrtory.CreateConfigurationWindow(SourceType.Worklist);
            }
        });

        public ICommand EditSourceCommand => new ActionCommand(() =>
        {
            if (SelectedSource != null) WindowFacrtory.CreateConfigurationWindow(SelectedSource);
        });

        public ICommand DeleteSourceCommand => new ActionCommand(() =>
        {
            if (SelectedSource != null)
            {

            }
        });

        // метод, загружающий источники всех типов
        private void LoadAllSources()
        {
            if (SourceRepository != null)
            {
                _sources = SourceRepository.GetAllSources();
            }
        }

        // метод, обновляющий список источников согласно выбранному типу источника
        private void ChangeSourceListByType()
        {
            if (_type != string.Empty)
            {
                if (_type == Resources.SourcesWindowViewModel_SourceTypeOption_DataBase)
                    Sources = SourceRepository.GetSourcesByType(PatientServices.Sources.SourceType.DataBase);
                if (_type == Resources.SourcesWindowViewModel_SourceTypeOption_Worklist)
                    Sources = SourceRepository.GetSourcesByType(PatientServices.Sources.SourceType.Worklist);
            }
        }
    }
}
