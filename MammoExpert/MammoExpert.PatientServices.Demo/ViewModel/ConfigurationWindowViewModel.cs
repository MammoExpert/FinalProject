using MammoExpert.PatientServices.PresenterCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using MammoExpert.PatientServices.Sources;

namespace MammoExpert.PatientServices.Demo.ViewModel
{
    public class ConfigurationWindowViewModel : ViewModelBase
    {
        private ViewModelBase _currentViewModel;
        private readonly ViewModelBase _parent;
        #region Properties
        public ViewModelBase CurrentViewModel
        {
            get { return _currentViewModel; }
            set
            {
                _currentViewModel = value;
                RaisePropertyChanged("CurrentViewModel");
            }
        }

        #endregion // Properties

        #region Constructor

        // конструктор при загрузке окна для редактирования выбранного источника
        public ConfigurationWindowViewModel(ViewModelBase vm, Source source)
        {
            base.DisplayName = Properties.Resources.ConfigurationWindowViewModel_DisplayName;
            _parent = vm;
            SetCurrentViewModel(source);          
        }

        #endregion // Constructor

        #region Private Methods

        // устанавливает значение для текущей модели представления в зависимости от переданного источника
        private void SetCurrentViewModel(Source source)
        {
            switch (source.Type)
            {
                case SourceType.DataBase:
                    _currentViewModel = new DBConnectionConfigurationModel(_parent, source);
                    break;
                case SourceType.Worklist:
                    _currentViewModel = new WorklistConnectionConfigurationModel(_parent, source);
                    break;
                default: throw new ArgumentNullException("source");
            }
        }

        #endregion // Private Methods
    }
}
