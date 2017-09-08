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

        // добавляет рабочую область
        public void Add(ViewModelBase workspace)
        {
            if (workspace == null) return;
            Workspaces.Add(workspace);
            SetActiveWorkspace(workspace);
        }

        // возвращает список рабочих областей
        public ObservableCollection<ViewModelBase> GetAll()
        {
            return Workspaces;
        }

        // убирает рабочую область
        public void Delete(ViewModelBase workspace)
        {
            if (Workspaces != null && Workspaces.Contains(workspace))
            {
                Workspaces.Remove(workspace);
            }
        }

        // метод, который при создании новой рабочей области делает ее активной
        public void SetActiveWorkspace(ViewModelBase workspace)
        {
            foreach (var item in Workspaces)
            {
                if (item.DisplayName != workspace.DisplayName) continue;
                Debug.Assert(Workspaces.Contains(item));

                var collectionView = CollectionViewSource.GetDefaultView(Workspaces);
                if (collectionView != null)
                    collectionView.MoveCurrentTo(item);
            }
            
        }
    }
}
