using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using MammoExpert.PatientServices.Demo.ViewModel;
using MammoExpert.PatientServices.PresenterCore;
using MammoExpert.PatientServices.Sources;

namespace MammoExpert.PatientServices.Demo
{
    public class WorkspaceRepository
    {
        public ObservableCollection<ViewModelBase> Workspaces = new ObservableCollection<ViewModelBase>();
        public WorkspaceRepository()
        {
            Workspaces.Add(new ManualInputViewModel());
        }

        public void Add(ViewModelBase workspace)
        {
            if (workspace == null) return;
            if (Workspaces != null && Workspaces.Contains(workspace))
            {
                SetActiveWorkspace(workspace);
            }
            else
            {
                Workspaces.Add(workspace);
                SetActiveWorkspace(workspace);
            }
        }

        public ObservableCollection<ViewModelBase> GetAll()
        {
            return Workspaces;
        }

        public void Delete(ViewModelBase workspace)
        {
            if (Workspaces != null && Workspaces.Contains(workspace))
            {
                Workspaces.Remove(workspace);
            }
        }


        // метод, который при создании новой рабочей области делает ее активной
        private void SetActiveWorkspace(ViewModelBase workspace)
        {
            Debug.Assert(Workspaces.Contains(workspace));

            var collectionView = CollectionViewSource.GetDefaultView(Workspaces);
            if (collectionView != null)
                collectionView.MoveCurrentTo(workspace);
        }
    }
}
