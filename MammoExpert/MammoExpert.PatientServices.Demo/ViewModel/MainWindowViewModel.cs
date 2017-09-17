using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using MammoExpert.PatientServices.Demo.Properties;
using MammoExpert.PatientServices.PresenterCore;
using MammoExpert.PatientServices.Sources;

namespace MammoExpert.PatientServices.Demo.ViewModel
{
    /// <summary>
    /// Модель представления главного окна
    /// </summary>
    public class MainWindowViewModel : ViewModelBase
    {
        #region Fields

        internal static IRepository<Source> SourceRepository;
        private ObservableCollection<ViewModelBase> _workspaces;
        internal static WorkspaceRepository WorkspaceRepository;

        #endregion // Fields

        #region Constructors

        public MainWindowViewModel() : this(null) { }

        public MainWindowViewModel(string path)
        {
            base.DisplayName = Resources.MainWindowViewModel_DisplayName;
            SourceRepository = new SourceRepository(path);
            WorkspaceRepository = new WorkspaceRepository();
        }

        #endregion // Constructors

        #region Properties

        /// <summary>
        /// Содержит коллекцию рабочих обсластей окна
        /// </summary>
        public ObservableCollection<ViewModelBase> Workspaces
        {
            get
            {
                if (_workspaces == null)
                {
                    _workspaces = WorkspaceRepository.GetAll() as ObservableCollection<ViewModelBase>;
                    RaisePropertyChanged(nameof(Workspaces));
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

        /// <summary>
        /// Открывает окно с информацией о программе
        /// </summary>
        public ICommand OpenAboutProgrammWindowCommand => new ActionCommand(() =>
        {
            ViewFactory.CreateAboutProgrammView();
        });

        /// <summary>
        /// Открывает окно управления источниками
        /// </summary>
        public ICommand OpenSourcesWindowCommand => new ActionCommand(() =>
        {
            ViewFactory.CreateSourcesView();
        });

        #endregion // Commands

        #region Private Methods

        /// <summary>
        /// При изменении количества рабочих областей подписывается (отписывается) на событие RequestClose
        /// </summary>
        private void OnWorkspacesChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.NewItems != null && e.NewItems.Count != 0)
                foreach (ViewModelBase workspace in e.NewItems)
                    workspace.RequestClose += OnWorkspaceRequestClose;

            if (e.OldItems != null && e.OldItems.Count != 0)
                foreach (ViewModelBase workspace in e.OldItems)
                    workspace.RequestClose -= OnWorkspaceRequestClose;
        }

        /// <summary>
        /// Закрывает рабочую область
        /// </summary>
        private void OnWorkspaceRequestClose(object sender, EventArgs e)
        {
            var workspace = sender as ViewModelBase;
            Workspaces.Remove(workspace);
        }

        #endregion // Private Methods
    }
}
