using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MammoExpert.PatientServices.Core.Exceptions
{
    public class HasLetterException : ApplicationException
    {
        public HasLetterException()
        {
        }

        public HasLetterException(string message) : base(message)
        {
        }
    }
}
