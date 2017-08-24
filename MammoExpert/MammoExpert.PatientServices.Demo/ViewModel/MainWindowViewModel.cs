using System;
using System.Windows.Input;
using MammoExpert.PatientServices.PresenterCore;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Diagnostics;
using System.Windows.Data;
using MammoExpert.PatientServices.Demo.Properties;
using MammoExpert.PatientServices.Sources;
using MammoExpert.PatientServices.UI.Controls.ViewModel;

namespace MammoExpert.PatientServices.Demo.ViewModel
{
    public class MainWindowViewModel : ViewModelBase
    {
        internal static SourceRepository SourceRepository;
        private ObservableCollection<ViewModelBase> _workspaces;

        public MainWindowViewModel() { }
        public MainWindowViewModel(string path)
        {
            SourceRepository = new SourceRepository(path);
            base.DisplayName = Resources.MainWindowViewModel_DisplayName;

            // Добавляем рабочую область для ручного ввода пациета (по умолчанию)
            CreateWorkspace(new ManualInputViewModel());
        }

        // коллекция рабочих областей
        public ObservableCollection<ViewModelBase> Workspaces
        {
            get
            {
                if (_workspaces == null)
                {
                    _workspaces = Workspace.Instance;
                    _workspaces.CollectionChanged += OnWorkspacesChanged;
                }
                return _workspaces;
            }
            set
            {
                if (_workspaces != value)
                {
                    _workspaces = value;
                    RaisePropertyChanged("Workspaces");
                    _workspaces.CollectionChanged += OnWorkspacesChanged;
                }

            }
        }

        public ICommand OpenAboutProgrammWindowCommand => new ActionCommand(() =>
        {
            WindowFactory.CreateAboutProgrammWindow();
        });

        public ICommand OpenSourcesWindowCommand => new ActionCommand(() =>
        {
            WindowFactory.CreateSourcesWindow();
        });

        // метод, добавляющий новую рабочую область
        public void CreateWorkspace(ViewModelBase vm)
        {
            Workspaces.Add(vm);
            SetActiveWorkspace(vm);
        }

        // метод, который при создании новой рабочей области делает ее активной
        private void SetActiveWorkspace(ViewModelBase workspace)
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
                foreach (ViewModelBase workspace in e.NewItems)
                    workspace.RequestClose += OnWorkspaceRequestClose;

            if (e.OldItems != null && e.OldItems.Count != 0)
                foreach (ViewModelBase workspace in e.OldItems)
                    workspace.RequestClose -= OnWorkspaceRequestClose;
        }

        // метод, вызываемый при событиии, которое требует закрытия рабочей области
        private void OnWorkspaceRequestClose(object sender, EventArgs e)
        {
            var workspace = sender as ViewModelBase;
            Workspaces.Remove(workspace);
        }
    }
}
