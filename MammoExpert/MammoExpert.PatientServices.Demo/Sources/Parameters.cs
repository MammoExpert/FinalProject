using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MammoExpert.PatientServices.Demo.Sources
{
    public class Parameters
    {
        public string DisplayedName;
        public string Header;
        public string Ip;
        public string Port;
        public string Timeout;
        public string Driver;
        public string UserName;
        public string Password;

        public Parameters()
        {
            DisplayedName = string.Empty;
            Header = string.Empty;
            Ip = string.Empty;
            Port = string.Empty;
            Timeout = string.Empty;
            Driver = string.Empty;
            UserName = string.Empty;
            Password = string.Empty;
        }
    }
}
