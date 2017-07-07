using MammoExpert.PatientServices.Demo.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using MammoExpert.PatientServices.Demo.View;

namespace MammoExpert.PatientServices.Demo.ViewModel
{
    public class MainWindowViewModel : ViewModelBase
    {
        public MainWindowViewModel() { }

        public ICommand OpenAboutProgrammWindow
        {
            get
            {
                return new ActionCommand(() =>
                {
                    AboutProgrammWindow win = new AboutProgrammWindow();
                    win.Show();

                });
            }
        }

        public ICommand OpenSourcesWindow
        {
            get
            {
                return new ActionCommand(() =>
                {
                    SourcesWindow win = new SourcesWindow();
                    win.Show();
                });
            }
        }
    }
}
