using System;
using System.Windows.Input;
using MammoExpert.PatientServices.Demo.View;
using MammoExpert.PatientServices.PresenterCore;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Diagnostics;
using System.Linq;
using System.Windows.Data;
using MammoExpert.PatientServices.Demo.Properties;
using MammoExpert.PatientServices.Sources;
using MammoExpert.PatientServices.UI.Controls.View;
using MammoExpert.PatientServices.UI.Controls.ViewModel;

namespace MammoExpert.PatientServices.Demo.ViewModel
{
    public class MainWindowViewModel : WorkspaceViewModel
    {
        private readonly SourceRepository _sourceRepository;
        private ObservableCollection<WorkspaceViewModel> _workspaces;

        public MainWindowViewModel()
        {
        }

        public MainWindowViewModel(string sourcesDataFile)
        {
            _sourceRepository = new SourceRepository(sourcesDataFile);
            base.DisplayName = Resources.MainWindowViewModel_DisplayName;

            // Добавляем рабочую область для ручного ввода пациета (по умолчанию)
            AddWorkspace(new ManualInputViewModel());
        }

        // коллекция рабочих областей
        public ObservableCollection<WorkspaceViewModel> Workspaces
        {
            get
            {
                if (_workspaces == null)
                {
                    _workspaces = new ObservableCollection<WorkspaceViewModel>();
                    _workspaces.CollectionChanged += OnWorkspacesChanged;
                }
                return _workspaces;
            }
        }

        public ICommand OpenAboutProgrammWindowCommand => new ActionCommand(() =>
        {
            var win = new AboutProgrammWindow();
            win.Show();
        });

        public ICommand OpenSourcesWindowCommand => new ActionCommand(() =>
        {
            var win = new SourcesWindow(_sourceRepository);
            win.Show();
        });

        // метод, добавляющий новую рабочую область
        public void AddWorkspace(WorkspaceViewModel vm)
        {
            Workspaces.Add(vm);
            base.RaisePropertyChanged("Workspaces");
            SetActiveWorkspace(vm);
        }

        // метод, который при создании новой рабочей области делает ее активной
        private void SetActiveWorkspace(WorkspaceViewModel workspace)
        {
            Debug.Assert(Workspaces.Contains(workspace));

            var collectionView = CollectionViewSource.GetDefaultView(Workspaces);
            if (collectionView != null)
                collectionView.MoveCurrentTo(workspace);
        }

        // метод, вызываемый при изменении количества рабочих областей
        private void OnWorkspacesChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.NewItems != null && e.NewItems.Count != 0)
                foreach (WorkspaceViewModel workspace in e.NewItems)
                    workspace.RequestClose += OnWorkspaceRequestClose;

            if (e.OldItems != null && e.OldItems.Count != 0)
                foreach (WorkspaceViewModel workspace in e.OldItems)
                    workspace.RequestClose -= OnWorkspaceRequestClose;
        }

        // метод, вызываемый при событиии, которое требует закрытия рабочей области
        private void OnWorkspaceRequestClose(object sender, EventArgs e)
        {
            var workspace = sender as WorkspaceViewModel;
            Workspaces.Remove(workspace);
        }
    }
}
