using System;

namespace MammoExpert.PatientServices.Core.Exceptions
{
    public class RequiredException : ApplicationException
    {
        public RequiredException()
        {
        }

        public RequiredException(string message) : base(message)
        {
        }
        
    }
}