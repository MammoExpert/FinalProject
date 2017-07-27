using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using MammoExpert.PatientServices.Sources;
using MammoExpert.PatientServices.PresenterCore;
using MammoExpert.PatientServices.UI.Controls.View;

namespace MammoExpert.PatientServices.Demo.ViewModel
{
    public class ConfigurationWindowViewModel : ViewModelBase
    {
        private UIElement _content;
        public UIElement Content
        {
            get { return _content; }
            set
            {
                if (_content != value)
                {
                    _content = value;
                    RaisePropertyChanged("Content");
                }
            }
        }
        public ConfigurationWindowViewModel(SourceType type)
        {
            switch (type)
            {
                case SourceType.DataBase: _content = new UcDBConnectionConfigurationViewmodel();
                    break;
                case SourceType.WorkList: _content = new UcWorklistConnectionConfiguration();
                    break;
                default:
                    break;
            }
        }
        public ConfigurationWindowViewModel(Source source)
        {
            switch (source.Type)
            {
                case SourceType.DataBase:
                    _content = new UcDBConnectionConfigurationViewmodel(source);
                    break;
                case SourceType.WorkList:
                    _content = new UcWorklistConnectionConfiguration(source);
                    break;
                default:
                    break;
            }
        }
    }
}
