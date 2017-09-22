using MammoExpert.PatientServices.Core;
using MammoExpert.PatientServices.DB;
using MammoExpert.PatientServices.Worklist;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using MammoExpert.PatientServices.Infrastructure;
using MammoExpert.PatientServices.Sources;

namespace MammoExpert.PatientServices.Demo
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private const string SourceFilePath = "../../Data/all_sources.json";

        public static ISourceRepository SourceRepository = new SourceRepository(SourceFilePath);
        public static IViewFactory Factory = new ViewFactory();

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            var mammoExpertDb = typeof(PatientDbConnectionRepository);
            var mammoExpertWorkList = typeof(PatientRepositoryDicom);

            // Создаем главное окно
            Factory.CreateMainView();
        }    
    }
}
