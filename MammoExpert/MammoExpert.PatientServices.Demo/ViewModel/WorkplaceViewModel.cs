using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MammoExpert.PatientServices.PresenterCore;

namespace MammoExpert.PatientServices.Demo.ViewModel
{
    public class WorkplaceViewModel : ViewModelBase
    {
        private static readonly Lazy<WorkplaceViewModel> ModelCreator = new Lazy<WorkplaceViewModel>(() => new WorkplaceViewModel());
        public static WorkplaceViewModel Instance => ModelCreator.Value;

        public MainWindowViewModel MainVM { get; set; }
        public SourcesWindowViewModel SourcesVM { get; set; }

        private WorkplaceViewModel()
        {
            MainVM = new MainWindowViewModel();
            SourcesVM = new SourcesWindowViewModel()
            {
                Workspaces = MainVM.Workspaces
            };
        }
    }
}
