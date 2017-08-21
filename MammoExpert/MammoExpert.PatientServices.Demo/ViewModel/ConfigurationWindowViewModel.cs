using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using MammoExpert.PatientServices.Demo.Properties;
using MammoExpert.PatientServices.Sources.Types;
using MammoExpert.PatientServices.PresenterCore;
using MammoExpert.PatientServices.Sources;
using MammoExpert.PatientServices.UI.Controls.View;
using MammoExpert.PatientServices.UI.Controls.ViewModel;

namespace MammoExpert.PatientServices.Demo.ViewModel
{
    public class ConfigurationWindowViewModel : ViewModelBase
    {
        private ISearchViewModel _currentSearchViewModel;

        public ISearchViewModel CurrentSearchViewModel
        {
            get { return _currentSearchViewModel; }
            set
            {
                _currentSearchViewModel = value;
                RaisePropertyChanged("CurrentSearchViewModel");
            }
        }

        // конструктор при загрузке окна для создания нового источника
        public ConfigurationWindowViewModel(SourceType type)
        {
            base.DisplayName = Resources.ConfigurationWindowViewModel_DisplayName;
            SetCurrentSearchViewModel(type);
        }

        // конструктор при загрузке окна для редактирования выбранного источника
        public ConfigurationWindowViewModel(Source source)
        {
            base.DisplayName = Resources.ConfigurationWindowViewModel_DisplayName;
            SetCurrentSearchViewModel(source);
        }

        // метод устанавливает значение для текущего ViewModel в зависимости от переданного типа источника
        private void SetCurrentSearchViewModel(SourceType type)
        {
            switch (type)
            {
                case SourceType.DataBase:
                    _currentSearchViewModel = new DBConnectionConfigurationModel();
                    break;
                case SourceType.Worklist:
                    _currentSearchViewModel = new WorklistConnectionConfigurationModel();
                    break;
                default: throw new ArgumentNullException("type");
            }
        }

        // метод устанавливает значение для текущего ViewModel в зависимости от переданного источника
        private void SetCurrentSearchViewModel(Source source)
        {
            switch (source.Type)
            {
                case SourceType.DataBase:
                    _currentSearchViewModel = new DBConnectionConfigurationModel(source);
                    break;
                case SourceType.Worklist:
                    _currentSearchViewModel = new WorklistConnectionConfigurationModel(source);
                    break;
                default: throw new ArgumentNullException("source");
            }
        }
    }
}
