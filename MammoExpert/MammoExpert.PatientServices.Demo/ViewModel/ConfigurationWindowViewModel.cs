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

        #region Constructor

        // конструктор при загрузке окна для редактирования выбранного источника
        public ConfigurationWindowViewModel(Source source)
        {
            base.DisplayName = Properties.Resources.ConfigurationWindowViewModel_DisplayName;
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
