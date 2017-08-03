using System;
using System.Windows;
using MammoExpert.PatientServices.Demo.ViewModel;
using MammoExpert.PatientServices.Sources;

namespace MammoExpert.PatientServices.Demo.View
{
    /// <summary>
    /// Interaction logic for SourcesWindow.xaml
    /// </summary>
    public partial class SourcesWindow : Window
    {
        public SourcesWindow(SourceRepository rep)
        {
            InitializeComponent();
            var vm = new SourcesWindowViewModel(rep);
            DataContext = vm;
            if (vm.CloseAction == null)
                vm.CloseAction = new Action(() => this.Close());
        }
    }
}
