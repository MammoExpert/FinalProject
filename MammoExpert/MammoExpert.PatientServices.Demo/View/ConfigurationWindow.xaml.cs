using System.Windows;
using MammoExpert.PatientServices.Demo.Sources;
using MammoExpert.PatientServices.Demo.ViewModel;

namespace MammoExpert.PatientServices.Demo.View
{
    /// <summary>
    /// Interaction logic for ConfigurationWindow.xaml
    /// </summary>
    public partial class ConfigurationWindow : Window
    {
        public ConfigurationWindow(Source.Types type)
        {
            InitializeComponent();
            var vm = new ConfigurationWindowViewModel(type);
            DataContext = vm;
            grid.Children.Add(vm.Content);
        }
    }
}
