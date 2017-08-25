using MammoExpert.PatientServices.PresenterCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using MammoExpert.PatientServices.Demo.Properties;

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
        public List<string> Moduls => new List<string>() { "Фейковый модуль 1", "Фейковый модуль 2" };

        #endregion // Properties
    }
}
