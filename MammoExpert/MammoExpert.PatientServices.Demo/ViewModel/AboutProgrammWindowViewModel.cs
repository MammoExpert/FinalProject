using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using MammoExpert.PatientServices.Core;
using MammoExpert.PatientServices.DB;
using MammoExpert.PatientServices.Demo.Properties;
using MammoExpert.PatientServices.PresenterCore;
using MammoExpert.PatientServices.Worklist;

namespace MammoExpert.PatientServices.Demo.ViewModel
{
    /// <summary>
    /// Модель представления окна с информацией о программе
    /// </summary>
    public class AboutProgrammWindowViewModel : ViewModelBase
    {
        #region Constructor

        public AboutProgrammWindowViewModel()
        {
            base.DisplayName = Resources.AboutProgrammWindowViewModel_DisplayName;
        }

        #endregion // Constructor

        #region Properties

        /// <summary>
        /// Версия программы
        /// </summary>
        public string Version => Assembly.GetExecutingAssembly().GetName().Version.ToString();

        /// <summary>
        /// Название программы
        /// </summary>
        public string ApplicationName => Assembly.GetExecutingAssembly().GetName().Name;

        /// <summary>
        /// Содержит список загруженных библиотек реализующих интерфейс источника данных пациента
        /// </summary>
        public List<string> Moduls => GetModuls();

        #endregion // Properties

        #region Private Methods

        /// <summary>
        /// Возвращает список библиотек, реализующих интерфейс источника данных пациента
        /// </summary>
        private static List<string> GetModuls()
        {
            var mammoExpertDb = typeof(PatientDbConnectionRepository);
            var mammoExpertWorkList = typeof(PatientRepositoryDicom);
            var typeInterface = typeof(IPatientRepository);

            var assebleTypes = AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(s => s.GetTypes())
                .Where(p => p.GetInterfaces().Contains(typeInterface))
                .SelectMany(a => new List<string>
                {
                    a.Assembly.GetName().Name +
                    " Версия " + a.Assembly.GetName().Version.ToString()
                }).ToList();

            return assebleTypes;
        }

        #endregion // Private Methods
    }
}
