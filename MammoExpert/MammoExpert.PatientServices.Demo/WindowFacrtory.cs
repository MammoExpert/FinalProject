using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MammoExpert.PatientServices.Demo.Properties;
using MammoExpert.PatientServices.Demo.View;
using MammoExpert.PatientServices.Demo.ViewModel;
using MammoExpert.PatientServices.Sources;

namespace MammoExpert.PatientServices.Demo
{
    public class WindowFacrtory
    {
        public WindowFacrtory() { }

        public static void CreateMainWindow(string sourcePath)
        {
            var view = new MainWindow();
            var viewModel = new MainWindowViewModel(sourcePath);
            view.DataContext = viewModel;
            view.Show();
        }

        public static void CreateSourcesWindow()
        {
            var view = new SourcesWindow();
            var viewModel = new SourcesWindowViewModel();
            if (viewModel.CloseAction == null) viewModel.CloseAction = new Action(view.Close);
            view.DataContext = viewModel;
            view.ShowDialog();
        }

        public static void CreateAboutProgrammWindow()
        {
            var view = new AboutProgrammWindow();
            var viewModel = new AboutProgrammWindowViewModel();
            view.DataContext = viewModel;
            view.ShowDialog();
        }

        public static void CreateConfigurationWindow(SourceType type)
        {
            var view = new ConfigurationWindow();
            var viewModel = new ConfigurationWindowViewModel(type);
            view.DataContext = viewModel;
            if (viewModel.CloseAction == null) viewModel.CloseAction = new Action(view.Close);
            view.DataContext = viewModel;
            view.ShowDialog();
        }

        public static void CreateConfigurationWindow(Source source)
        {
            var view = new ConfigurationWindow();
            var viewModel = new ConfigurationWindowViewModel(source);
            view.DataContext = viewModel;
            if (viewModel.CloseAction == null) viewModel.CloseAction = new Action(view.Close);
            view.DataContext = viewModel;
            view.ShowDialog();
        }
    }
}
