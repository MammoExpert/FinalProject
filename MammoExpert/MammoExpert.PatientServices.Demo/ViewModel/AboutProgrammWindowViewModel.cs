using MammoExpert.PatientServices.PresenterCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using MammoExpert.PatientServices.Demo.Properties;
using MammoExpert.PatientServices.Core;
using MammoExpert.PatientServices.DB;
using MammoExpert.PatientServices.Worklist;

namespace MammoExpert.PatientServices.Demo.ViewModel
{
    public class AboutProgrammWindowViewModel : ViewModelBase
    {
        #region Constructor

        public AboutProgrammWindowViewModel()
        {
            base.DisplayName = Properties.Resources.AboutProgrammWindowViewModel_DisplayName;
        }

        #endregion // Constructor

        #region Properties

        // версия программы
        public string Version => Assembly.GetExecutingAssembly().GetName().Version.ToString();

        // название программы
        public string ApplicationName => Assembly.GetExecutingAssembly().GetName().Name;

        // список загруженных библиотек реализующих интерфейс источника данных пациента
        public List<string> Moduls => GetModuls(); 
        #endregion // Properties

        //метод получающий библиотеки реализующие интерфейс источника данных пациента
        private static List<string> GetModuls()
        {
            var mammoExpertDb = typeof(PacientRepositoryEf);
            var mammoExpertWorkList = typeof(PatientRepositoryDicom);
            var typeInterface = typeof(IPatientRepository);

            var assebleTypes = AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(s => s.GetTypes())
                .Where(p => p.GetInterfaces().Contains(typeInterface))
                .SelectMany(a=>new List<string>
                {
                    a.Assembly.GetName().Name +
                    " Версия " + a.Assembly.GetName().Version.ToString()
                }).ToList();

            return assebleTypes;
        }
    }
}
