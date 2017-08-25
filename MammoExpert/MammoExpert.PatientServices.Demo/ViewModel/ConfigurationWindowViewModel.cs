using System;
using MammoExpert.PatientServices.PresenterCore;
using MammoExpert.PatientServices.Sources;
using MammoExpert.PatientServices.UI.Controls.ViewModel;

namespace MammoExpert.PatientServices.Demo.ViewModel
{
    public class ConfigurationWindowViewModel : ViewModelBase
    {
        #region Fields and Properties

        private ViewModelBase _currentViewModel;

        public ViewModelBase CurrentViewModel
        {
            get { return _currentViewModel; }
            set
            {
                _currentViewModel = value;
                RaisePropertyChanged("CurrentViewModel");
            }
        }

        #endregion // Fields and Properties

        #region Constructors

        // конструктор при загрузке окна для создания нового источника
        public ConfigurationWindowViewModel(SourceType type)
        {
            base.DisplayName = Properties.Resources.ConfigurationWindowViewModel_DisplayName;
            SetCurrentViewModel(type);
        }

        // конструктор при загрузке окна для редактирования выбранного источника
        public ConfigurationWindowViewModel(Source source)
        {
            base.DisplayName = Properties.Resources.ConfigurationWindowViewModel_DisplayName;
            SetCurrentViewModel(source);
        }

        #endregion // Constructors

        #region Private Methods

        // устанавливает значение для текущей модели представления в зависимости от переданного типа источника
        private void SetCurrentViewModel(SourceType type)
        {
            switch (type)
            {
                case SourceType.DataBase:
                    _currentViewModel = new DBConnectionConfigurationModel();
                    break;
                case SourceType.Worklist:
                    _currentViewModel = new WorklistConnectionConfigurationModel();
                    break;
                default: throw new ArgumentNullException("type");
            }
        }

        // устанавливает значение для текущей модели представления в зависимости от переданного источника
        private void SetCurrentViewModel(Source source)
        {
            switch (source.Type)
            {
                case SourceType.DataBase:
                    _currentViewModel = new DBConnectionConfigurationModel(source);
                    break;
                case SourceType.Worklist:
                    _currentViewModel = new WorklistConnectionConfigurationModel(source);
                    break;
                default: throw new ArgumentNullException("source");
            }
        }

        #endregion // Private Methods
    }
}
