using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MammoExpert.PatientServices.PresenterCore;

namespace MammoExpert.PatientServices.PresenterCore
{
    public class Workspace
    {
        private static readonly Lazy<ObservableCollection<ViewModelBase>> Creator = new Lazy<ObservableCollection<ViewModelBase>>(() => new ObservableCollection<ViewModelBase>());
        public static ObservableCollection<ViewModelBase> Instance => Creator.Value;

        public Workspace() { }
    }
}
