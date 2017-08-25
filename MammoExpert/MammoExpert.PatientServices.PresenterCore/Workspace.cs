using System;
using System.Collections.ObjectModel;

namespace MammoExpert.PatientServices.PresenterCore
{
    public class Workspace
    {
        private static readonly Lazy<ObservableCollection<ViewModelBase>> Creator = 
            new Lazy<ObservableCollection<ViewModelBase>>(() => new ObservableCollection<ViewModelBase>());
        public static ObservableCollection<ViewModelBase> Instance => Creator.Value;

        public Workspace() { }
    }
}
