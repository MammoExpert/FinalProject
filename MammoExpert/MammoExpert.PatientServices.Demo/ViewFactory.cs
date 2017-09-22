using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using MammoExpert.PatientServices.Core;
using MammoExpert.PatientServices.Demo.View;
using MammoExpert.PatientServices.Demo.ViewModel;
using MammoExpert.PatientServices.PresenterCore;
using MammoExpert.PatientServices.Sources;

namespace MammoExpert.PatientServices.Demo
{
    /// <summary>
    /// Статический класс, создает представления с их моделями представления
    /// </summary>
    public class ViewFactory : IViewFactory
    {
        #region Public Methods

        /// <summary>
        /// Создает главное окно
        /// </summary>
        public void CreateMainView()
        {
            var view = new MainWindow();
            var viewModel = new MainWindowViewModel();
            view.DataContext = viewModel;
            view.Show();
        }

        /// <summary>
        /// Создает окно управления источниками
        /// </summary>
        public void CreateSourcesView()
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
        public void CreateAboutProgrammView()
        {
            var view = new AboutProgrammWindow();
            var viewModel = new AboutProgrammWindowViewModel();
            view.DataContext = viewModel;
            view.ShowDialog();
        }

        /// <summary>
        /// Создает окно для создания нового источника
        /// </summary>

        public void CreateConfigurationView(SourceTypeEnum type)
        {
            var view = new ConfigurationWindow();
            var viewModel = new ConfigurationWindowViewModel(type);
            if (viewModel.CloseAction == null) viewModel.CloseAction = new Action(view.Close);
            view.DataContext = viewModel;
            view.ShowDialog();
        }

        /// <summary>
        /// Создает окно для редактирования выбранного источника
        /// </summary>

        public void CreateUpdateConfigurationView(Source source)
        {
            var view = new ConfigurationWindow();
            var viewModel = new ConfigurationWindowViewModel(source);
            if (viewModel.CloseAction == null) viewModel.CloseAction = new Action(view.Close);
            view.DataContext = viewModel;
            view.ShowDialog();
        }

        /// <summary>
        /// Создает окно для просмотра данных пациента
        /// </summary>
        public void CreatePatientDitailsView(Patient patient)
        {
            var view = new PatientDitailsWindow();
            view.DataContext = patient;
            view.ShowDialog();
        }

        #endregion // Public Methods
    }
}
