using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace MammoExpert.PatientServices.Sources.Types
{
    public class WorklistType
    {
        public string Name { get; set; }

        public WorklistType()
        {
            Name = "Рабочий список";
        }
    }
}
