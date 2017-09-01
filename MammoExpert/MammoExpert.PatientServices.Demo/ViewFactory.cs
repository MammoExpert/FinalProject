using System;
using MammoExpert.PatientServices.Core;
using MammoExpert.PatientServices.Demo.View;
using MammoExpert.PatientServices.Demo.ViewModel;
using MammoExpert.PatientServices.Sources;

namespace MammoExpert.PatientServices.Demo
{
    public class ViewFactory
    { 
        #region Public Methods

        // создает главное окно
        public static void CreateMainView()
        {
            var view = new MainWindow();
            var viewModel = new MainWindowViewModel("../../Data/all_sources.json");
            view.DataContext = viewModel;
            view.Show();
        }

        // создает окно управления источниками
        public static void CreateSourcesView()
        {
            var view = new SourcesWindow();
            var viewModel = new SourcesWindowViewModel();
            if (viewModel.CloseAction == null) viewModel.CloseAction = new Action(view.Close);
            view.DataContext = viewModel;
            view.ShowDialog();
        }

        // создает окно с информацией о программе
        public static void CreateAboutProgrammView()
        {
            var view = new AboutProgrammWindow();
            var viewModel = new AboutProgrammWindowViewModel();
            view.DataContext = viewModel;
            view.ShowDialog();
        }

        // создает окно для редактирования источниов
        public static void CreateConfigurationView(Source source)
        {
            var view = new ConfigurationWindow();
            var viewModel = new ConfigurationWindowViewModel(source);
            view.DataContext = viewModel;
            if (viewModel.CloseAction == null) viewModel.CloseAction = new Action(view.Close);
            view.DataContext = viewModel;
            view.ShowDialog();
        }

        // Создает окно для просмотри информации о пациенте
        public static void CreatePatientDitailsView(Patient patient)
        {
            var view = new PatientDitailsWindow();
            var viewModel = new PatientDitailsWindowViewModel(patient);
            view.DataContext = viewModel;
            view.DataContext = viewModel;
            view.ShowDialog();
        }

        #endregion // Public Methods
    }
}
