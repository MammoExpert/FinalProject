using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using MammoExpert.PatientServices.Demo.Properties;
using MammoExpert.PatientServices.Sources;
using MammoExpert.PatientServices.Demo.View;
using MammoExpert.PatientServices.PresenterCore;
using MammoExpert.PatientServices.UI.Controls.View;
using MammoExpert.PatientServices.UI.Controls.ViewModel;

namespace MammoExpert.PatientServices.Demo.ViewModel
{
    public class SourcesWindowViewModel : MainWindowViewModel
    {
        private readonly SourceRepository _sourceRepository;
        private string _sourceType;
        private string[] _sourceTypeOptions;
        private Source _selectedSource;

        public SourcesWindowViewModel(SourceRepository sourceRepository)
        {
            if (sourceRepository == null)
                throw new ArgumentNullException("sourceRepository");

            base.DisplayName = Resources.SourcesWindowViewModel_DisplayName;

            _sourceRepository = sourceRepository;
            _sourceType = Resources.SourcesWindowViewModel_SourceTypeOption_NotSpecified;

            LoadAllSources();
        }

        // список отображаемых источников
        public List<Source> Sources { get; private set; }

        // выбранный пользователем тип источника; от него будет зависеть список отображаемых источников
        public string SourceType
        {
            get { return _sourceType; }
            set
            {
                if (value == _sourceType || string.IsNullOrEmpty(value))
                    return;

                _sourceType = value;

                ChangeSourceListByType();

                base.RaisePropertyChanged("SourceType");
            }
        }

        // здесь храним все типы источников для отображения в ComboBox
        public string[] SourceTypeOptions
        {
            get
            {
                if (_sourceTypeOptions == null)
                {
                    _sourceTypeOptions = new string[]
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
                if (_selectedSource != value)
                {
                    _selectedSource = value;
                    RaisePropertyChanged("SelectedSource");
                }
            }
        }
        
        public ICommand AddWorkspaceCommand => new ActionCommand(() =>
        {
            base.AddWorkspace(new PatientSearchViewModel(SelectedSource));
            CloseAction();
        });

        public ICommand AddSourceCommand => new ActionCommand(() =>
        {
            if (_sourceType != string.Empty)
            {
                if (_sourceType == Resources.SourcesWindowViewModel_SourceTypeOption_DataBase)
                    new ConfigurationWindow(PatientServices.Sources.SourceType.DataBase).Show();
                if (_sourceType == Resources.SourcesWindowViewModel_SourceTypeOption_Worklist)
                    new ConfigurationWindow(PatientServices.Sources.SourceType.Worklist).Show();
            }
        });

        public ICommand EditSourceCommand => new ActionCommand(() =>
        {
            var win = new ConfigurationWindow(SelectedSource);
            win.Show();
        });

        public ICommand DeleteSourcenewCommand => new ActionCommand(() =>
        {
            if (_selectedSource != null)
            {

            }
        });

        // метод, загружающий источники всех типов
        private void LoadAllSources()
        {
            var all = _sourceRepository.GetAllSources();
            Sources = new List<Source>(all);
            base.RaisePropertyChanged("Sources");
        }

        // метод, обновляющий список источников согласно выбранному типу источника
        private void ChangeSourceListByType()
        {
            if (_sourceType != string.Empty)
            {
                if (_sourceType == Resources.SourcesWindowViewModel_SourceTypeOption_DataBase)
                    Sources = _sourceRepository.GetSourcesByType(PatientServices.Sources.SourceType.DataBase);
                if (_sourceType == Resources.SourcesWindowViewModel_SourceTypeOption_Worklist)
                    Sources = _sourceRepository.GetSourcesByType(PatientServices.Sources.SourceType.Worklist);

                base.RaisePropertyChanged("Sources");
            }
        }
    }
}
