using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using MammoExpert.PatientServices.Demo.Properties;
using MammoExpert.PatientServices.PresenterCore;
using MammoExpert.PatientServices.Sources;

namespace MammoExpert.PatientServices.Demo.ViewModel
{
    public class WorklistConnectionConfigurationModel : ViewModelBase
    {
  
        #region Fields and Properties

        private delegate void AddSourceHandler(Source source);
        private event AddSourceHandler OnAddSource;

        private Source _source;

        public Source Source
        {
            get { return _source; }
            set
            {
                _source = value;
                RaisePropertyChanged("Source");
            }
        }

        #endregion // Fields and Properties

        public WorklistConnectionConfigurationModel(ViewModelBase vm, Source source)
        {
            Source = source;
            base.DisplayName = Resources.WorklistConnectionConfigurationModel_DisplayName;
            var p = vm as SourcesWindowViewModel;
            if (source != null && p != null) OnAddSource += p.EditOrCreateSource;
        }

        public ICommand CancelCommand => new ActionCommand(() =>
        {
            ConfigurationWindowViewModel.Close();
        });

        public ICommand CreateCommand => new ActionCommand(() =>
        {
            //Source.Description = Source.Name + " и прочее."; 
            if (OnAddSource != null) OnAddSource(Source);
            ConfigurationWindowViewModel.Close();
        });
    }
}
