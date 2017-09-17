using System;

namespace MammoExpert.PatientServices.Core.Exceptions
{
    public class IncorrectSymbolException : ApplicationException
    {
        public IncorrectSymbolException()
        {
        }

        public IncorrectSymbolException(string message) : base(message)
        {
        }
    }
}