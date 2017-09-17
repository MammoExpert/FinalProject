using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using MammoExpert.PatientServices.Demo.View;
using MammoExpert.PatientServices.Demo.ViewModel;
using MammoExpert.PatientServices.PresenterCore;
using MammoExpert.PatientServices.Sources;

namespace MammoExpert.PatientServices.Demo
{
    /// <summary>
    /// Статический класс, создает представления с их моделями представления
    /// </summary>
    public class ViewFactory
    {
        #region Public Methods

        /// <summary>
        /// Создает главное окно
        /// </summary>
        public static void CreateMainView()
        {
            var view = new MainWindow();
            var viewModel = new MainWindowViewModel();
            view.DataContext = viewModel;
            view.Show();
        }

        /// <summary>
        /// Создает окно управления источниками
        /// </summary>
        public static void CreateSourcesView()
        {
            var view = new SourcesWindow();
            var viewModel = new SourcesWindowViewModel();
            if (viewModel.CloseAction == null) viewModel.CloseAction = new Action(view.Close);
            view.DataContext = viewModel;
            view.ShowDialog();
        }

        /// <summary>
        /// Создает окно с информацией о программе
        /// </summary>
        public static void CreateAboutProgrammView()
        {
            var view = new AboutProgrammWindow();
            var viewModel = new AboutProgrammWindowViewModel();
            view.DataContext = viewModel;
            view.ShowDialog();
        }

        /// <summary>
        /// Создает окно для создания нового или редактирования выбранного источника
        /// </summary>
        public static void CreateConfigurationView(ViewModelBase vm, Source source, bool isNew)
        {
            var view = new ConfigurationWindow();
            var viewModel = new ConfigurationWindowViewModel(vm, source, isNew);
            if (viewModel.CloseAction == null) viewModel.CloseAction = new Action(view.Close);
            view.DataContext = viewModel;
            view.ShowDialog();
        }

        /// <summary>
        /// Создает окно для просмотра данных пациента
        /// </summary>
        public static void CreatePatientDitailsView(ViewModelBase viewModel)
        {
            var view = new PatientDitailsWindow();
            view.DataContext = viewModel;
            view.ShowDialog();
        }


        //private void ShowDialog(FrameworkElement body, ViewModelBase vm)
        //{
        //    if(body == null || vm == null)
        //        throw new NullReferenceException();
        //    body.DataContext = vm;
        //    (body as Window)?.ShowDialog();
        //}


        #endregion // Public Methods
    }
}
