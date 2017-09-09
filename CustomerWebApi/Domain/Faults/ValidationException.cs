using System;

namespace CustomerWebApi.Domain.Faults
{
    public class ValidationException : Exception
    {
        public ValidationException(string message) : base(message)
        {
        }
    }
}