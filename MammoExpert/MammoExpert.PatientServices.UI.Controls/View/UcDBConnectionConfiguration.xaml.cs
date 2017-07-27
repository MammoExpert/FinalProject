using MammoExpert.PatientServices.Sources;
using MammoExpert.PatientServices.UI.Controls.ViewModel;
using System.Windows.Controls;

namespace MammoExpert.PatientServices.UI.Controls.View
{
    /// <summary>
    /// Логика взаимодействия для UcDBConnectionConfiguration.xaml
    /// </summary>
    public partial class UcDBConnectionConfigurationViewmodel : UserControl
    {
        public UcDBConnectionConfigurationViewmodel()
        {
            InitializeComponent();
        }

        public UcDBConnectionConfigurationViewmodel(Source source)
        {
            InitializeComponent();
            DataContext = new DBConnectionConfigurationModel(source);
        }
    }
}
