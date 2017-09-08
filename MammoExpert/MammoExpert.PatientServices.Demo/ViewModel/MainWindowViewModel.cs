using System;
using System.Windows.Input;
using MammoExpert.PatientServices.PresenterCore;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Diagnostics;
using System.Windows;
using System.Windows.Data;
using MammoExpert.PatientServices.Core;
using MammoExpert.PatientServices.Demo.Properties;
using MammoExpert.PatientServices.Sources;

namespace MammoExpert.PatientServices.Demo.ViewModel
{
    public class MainWindowViewModel : ViewModelBase
    {
        #region Fields

        internal static SourceRepository SourceRepository;
        private ObservableCollection<ViewModelBase> _workspaces;
        internal static WorkspaceRepository WorkspaceRepository;

        #endregion // Fields

        #region Constructors

        public MainWindowViewModel() { }

        public MainWindowViewModel(string path)
        {
            base.DisplayName = Resources.MainWindowViewModel_DisplayName;
            SourceRepository = new SourceRepository(path);
            WorkspaceRepository = new WorkspaceRepository();
        }

        #endregion // Constructors

        #region Properties

        // коллекция рабочих областей окна
        public ObservableCollection<ViewModelBase> Workspaces
        {
            get
            {
                if (_workspaces == null)
                {
                    _workspaces = WorkspaceRepository.GetAll();
                    RaisePropertyChanged("Workspaces");
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

        #endregion // Properties

        #region Commands

        // открывает окно с информацией о программе
        public ICommand OpenAboutProgrammWindowCommand => new ActionCommand(() =>
        {
            ViewFactory.CreateAboutProgrammView();
        });

        // открывает окно управления источниками
        public ICommand OpenSourcesWindowCommand => new ActionCommand(() =>
        {
            ViewFactory.CreateSourcesView();
        });

        #endregion // Commands

        #region Private Methods

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

        #endregion // Private Methods
    }
}
