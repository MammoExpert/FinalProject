using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MammoExpert.PatientServices.Core.Exceptions
{
    public class ForbiddenSymbolException : ApplicationException
    {
        public ForbiddenSymbolException()
        {
        }

        public ForbiddenSymbolException(string message) : base(message)
        {
        }
    }
}
