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
        public SourcesWindowViewModel() { }

        // здесь храним все типы источников для отображения в ComboBox
        public List<string> SourceTypes => Enum.GetNames(typeof(Source.Types)).ToList();

        // выбранный пользователем тип источника; от него будет зависеть список отображаемых источников
        private Source.Types _selectedType;
        public Source.Types SelectedType
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

        // отображаемый список источников
        private List<Source> _sources;
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

        // выбранный пользователем источник
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

        public ICommand SourceTypeChanging => new ActionCommand(() =>
        {
                // создаем список источников согласно выбранному типу
        });

        public ICommand AddSource => new ActionCommand(() =>
        {
            var win = new ConfigurationWindow(SelectedType);
            win.Show();
        });

        public ICommand EditSource => new ActionCommand(() =>
        {
            // редактируем выбранный источник
        });

        public ICommand DeleteSourcenew => new ActionCommand(() =>
        {
            // удаляем из списка

            // и удаляем вкладку, если открыта
        });
    }
}
