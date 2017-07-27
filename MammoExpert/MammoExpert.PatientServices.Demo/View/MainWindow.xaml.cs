using System.Windows;
using MammoExpert.PatientServices.Demo.ViewModel;

namespace MammoExpert.PatientServices.Demo.View
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new MainWindowViewModel();
        }
    }
}
