using System.Windows;
using MammoExpert.PatientServices.Sources;
using MammoExpert.PatientServices.Demo.ViewModel;

namespace MammoExpert.PatientServices.Demo.View
{
    /// <summary>
    /// Interaction logic for ConfigurationWindow.xaml
    /// </summary>
    public partial class ConfigurationWindow : Window
    {
        public ConfigurationWindow(SourceType type)
        {
            InitializeComponent();
            var vm = new ConfigurationWindowViewModel(type);
            DataContext = vm;
            grid.Children.Add(vm.Content);
        }
        public ConfigurationWindow(Source source)
        {
            InitializeComponent();
            var vm = new ConfigurationWindowViewModel(source);
            DataContext = vm;
            grid.Children.Add(vm.Content);
        }
    }
}
