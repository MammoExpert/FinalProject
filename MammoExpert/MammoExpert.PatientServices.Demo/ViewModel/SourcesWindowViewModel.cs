using MammoExpert.PatientServices.Demo.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MammoExpert.PatientServices.Demo.ViewModel
{
    public class SourcesWindowViewModel : ViewModelBase
    {
        public SourcesWindowViewModel() { }

        public ICommand AddSource
        {
            get
            {
                return new ActionCommand(() =>
                {

                });
            }
        }

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
