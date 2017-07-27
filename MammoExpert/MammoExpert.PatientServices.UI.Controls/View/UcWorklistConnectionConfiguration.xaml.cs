using MammoExpert.PatientServices.Sources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using MammoExpert.PatientServices.UI.Controls.ViewModel;

namespace MammoExpert.PatientServices.UI.Controls.View
{
    /// <summary>
    /// Логика взаимодействия для UcWorklistConnectionConfiguration.xaml
    /// </summary>
    public partial class UcWorklistConnectionConfiguration : UserControl
    {
        public UcWorklistConnectionConfiguration()
        {
            InitializeComponent();
            DataContext = new WorklistConnectionConfigurationModel();
        }

        public UcWorklistConnectionConfiguration(Source source)
        {
            InitializeComponent();
            DataContext = new WorklistConnectionConfigurationModel(source);
        }
    }
}
