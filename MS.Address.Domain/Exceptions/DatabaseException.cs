using System;

namespace MS.Address.Domain.Exceptions
{
    public class DatabaseException : Exception
    {
        public DatabaseException(string message, Exception innerException)
            : base(message, innerException)
        { }
    }
}