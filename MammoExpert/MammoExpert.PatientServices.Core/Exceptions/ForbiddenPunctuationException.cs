using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MammoExpert.PatientServices.Core.Exceptions
{
    public class ForbiddenPunctuationException : ApplicationException
    {
        public ForbiddenPunctuationException()
        {
        }

        public ForbiddenPunctuationException(string message) : base(message)
        {
        }
    }
}
