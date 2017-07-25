using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using MammoExpert.PatientServices.Demo.Sources;
using MammoExpert.PatientServices.UI.Controls.View;
using MammoExpert.PatientServices.Demo.Helpers;

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
        public ConfigurationWindowViewModel(Source.Types type)
        {
            switch (type)
            {
                case Source.Types.DataBase: _content = new UcDBConnectionConfiguration();
                    break;
                case Source.Types.WorkList: _content = new UcWorklistConnectionConfiguration();
                    break;
                default:
                    break;
            }
        }
    }
}
