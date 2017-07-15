using MammoExpert.PatientServices.Demo.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using MammoExpert.PatientServices.Demo.Sources;
using MammoExpert.PatientServices.Demo.View;
using MammoExpert.PatientServices.UI.Controls.View;

namespace MammoExpert.PatientServices.Demo.ViewModel
{
    public class SourcesWindowViewModel : ViewModelBase
    {
        public List<string> SourceTypes => Enum.GetNames(typeof(Source.Types)).ToList();

        private object _selectedType;
        public object SelectedType
        {
            get { return _selectedType; }
            set
            {
                if (_selectedType != value)
                {
                    _selectedType = value;
                    RaisePropertyChanged("SelectedType");
                }
            }
        }

        private List<Source> _sources = SourceHandler.SourceList;
        public List<Source> Sources
        {
            get { return _sources; }
            set
            {
                if (_sources != value)
                {
                    _sources = value;
                    RaisePropertyChanged("Sources");
                }
            }
        }

        private object _selectedSource;

        public object SelectedSource
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

        public SourcesWindowViewModel() { }

        public ICommand SourceTypeChanging => new ActionCommand(() =>
        {
            Sources = SelectedType != null ? SourceHandler.SourceList.Where(t => t.Type.ToString() == SelectedType.ToString()).ToList() : SourceHandler.SourceList;
        });

        public ICommand AddSource => new ActionCommand(() =>
        {
            //MainWindowViewModel.AddTab("Поиск", new UcPatientSearch());
        });

        public ICommand EditSource
        {
            get
            {
                return new ActionCommand(() =>
                {

                });
            }
        }

        public ICommand DeleteSource
        {
            get
            {
                return new ActionCommand(() =>
                {

                });
            }
        }
    }
}
