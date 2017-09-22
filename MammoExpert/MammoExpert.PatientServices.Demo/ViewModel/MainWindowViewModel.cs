using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
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
        
        private static ObservableCollection<ViewModelBase> _workspaces;

        #endregion // Fields

        #region Constructors

        public MainWindowViewModel()
        {
            base.DisplayName = Resources.MainWindowViewModel_DisplayName;
            _workspaces = ConvertSourcesToViewModel(App.SourceRepository.GetAll());
            App.SourceRepository.SourceList.CollectionChanged += OnWorkspacesChanged;
        }

        #endregion // Constructors

        #region Properties

        /// <summary>
        /// Содержит коллекцию рабочих обсластей окна
        /// </summary>
        public ObservableCollection<ViewModelBase> Workspaces
        {
            get { return _workspaces; }
            set
            {
                if (_workspaces != value)
                {
                    _workspaces = value;
                    RaisePropertyChanged("Workspaces");
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
            App.Factory.CreateAboutProgrammView();
        });

        /// <summary>
        /// Открывает окно управления источниками
        /// </summary>
        public ICommand OpenSourcesWindowCommand => new ActionCommand(() =>
        {
            App.Factory.CreateSourcesView();
        });

        #endregion // Commands

        #region Private Methods

        /// <summary>
        /// Обновляет список рабочих областей
        /// </summary>
        private void OnWorkspacesChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.NewItems != null && e.NewItems.Count != 0)
                foreach (Source source in e.NewItems)
                {
                    var vs = new PatientSearchViewModel(source);
                    Workspaces.Add(vs);
                    SetActiveWorkspace(vs);
                }

            if (e.OldItems != null && e.OldItems.Count != 0)
                foreach (Source source in e.OldItems)
                    Workspaces.Remove(FindWorkspace(source));
        }

        /// <summary>
        /// При создании новой рабочей области делает ее активной
        /// </summary>
        private void SetActiveWorkspace(ViewModelBase workspace)
        {
            foreach (var item in Workspaces)
            {
                if (item.DisplayName != workspace.DisplayName) continue;

                var collectionView = CollectionViewSource.GetDefaultView(Workspaces);
                if (collectionView != null)
                    collectionView.MoveCurrentTo(item);
            }
        }

        /// <summary>
        /// Находит среди списка открытых рабочих областей ту, которая относитчя к выбранному источнику
        /// </summary>
        private ViewModelBase FindWorkspace(Source source)
        {
            foreach (var item in Workspaces)
            {
                if (item.GetType() == typeof(PatientSearchViewModel))
                {
                    if (item.DisplayName == source.Name)
                    {
                        if (Workspaces.Contains(item)) return item;
                    }
                }
            }
            return null;
        }

        /// <summary>
        /// Создает коллелкцию рабочих областей по списку источников
        /// </summary>
        private ObservableCollection<ViewModelBase> ConvertSourcesToViewModel(IEnumerable<Source> collection)
        {
            var result = new ObservableCollection<ViewModelBase>();
            result.Add(new ManualInputViewModel());
            foreach (var source in collection)
            {
                result.Add(new PatientSearchViewModel(source));
            }
            return result;
        }

        #endregion // Private Methods
    }
}
