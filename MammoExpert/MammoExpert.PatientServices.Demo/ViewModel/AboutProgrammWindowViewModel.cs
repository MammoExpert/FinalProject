using MammoExpert.PatientServices.Demo.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MammoExpert.PatientServices.Demo.ViewModel
{
    public class AboutProgrammWindowViewModel : ViewModelBase
    {
        public AboutProgrammWindowViewModel() { }
        public string Version => Assembly.GetExecutingAssembly().GetName().Version.ToString();

        public string ApplicationName => Assembly.GetExecutingAssembly().GetName().Name;

        public List<string> Moduls => new List<string>() {"Фейковый модуль 1", "Фейковый модуль 2"};

    }
}
