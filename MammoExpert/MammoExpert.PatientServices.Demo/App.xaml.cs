using MammoExpert.PatientServices.Demo.View;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using MammoExpert.PatientServices.Demo.ViewModel;

namespace MammoExpert.PatientServices.Demo
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            WindowFacrtory.CreateMainWindow("all_sources.json");
        }
    }
}
