using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MammoExpert.PatientServices.Core.Exceptions
{
    public class DateAbsentException : ApplicationException
    {
        public DateAbsentException()
        {
        }

        public DateAbsentException(string message) : base(message)
        {
        }
    }
}
