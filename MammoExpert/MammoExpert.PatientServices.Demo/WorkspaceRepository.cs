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

namespace MammoExpert.PatientServices.Demo
{
    /// <summary>
    /// Класс для создания репозитория рабочих областей
    /// </summary>
    public class WorkspaceRepository
    {
        public ObservableCollection<ViewModelBase> Workspaces = new ObservableCollection<ViewModelBase>();

        public WorkspaceRepository()
        {
            Workspaces.Add(new ManualInputViewModel());
        }

        /// <summary>
        /// Добавляет рабочую область в репозиторий
        /// </summary>
        public void Add(ViewModelBase workspace)
        {
            if (workspace == null) return;
            Workspaces.Add(workspace);
            SetActiveWorkspace(workspace);
        }

        /// <summary>
        /// Возвращает список имеющихся рабочих областей
        /// </summary>
        public ObservableCollection<ViewModelBase> GetAll()
        {
            return Workspaces;
        }

        /// <summary>
        /// Убрает рабочую область из репозитория
        /// </summary>
        public void Delete(ViewModelBase workspace)
        {
            if (Workspaces != null && Workspaces.Contains(workspace))
            {
                Workspaces.Remove(workspace);
            }
        }

        /// <summary>
        /// При создании новой рабочей области делает ее активной
        /// </summary>
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
