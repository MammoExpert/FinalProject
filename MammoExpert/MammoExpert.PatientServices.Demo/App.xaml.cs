using MammoExpert.PatientServices.Core;
using MammoExpert.PatientServices.DB;
using MammoExpert.PatientServices.Worklist;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

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
            var mammoExpertDb = typeof(PatientDbConnectionRepository);
            var mammoExpertWorkList = typeof(PatientRepositoryDicom);
            // Создаем главное окно
            ViewFactory.CreateMainView();
        }
    }
}
