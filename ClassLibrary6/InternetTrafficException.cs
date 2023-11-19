using System;

namespace ClassLibrary6
{
    public class InternetTrafficException : Exception
    {
        public InternetTrafficException()
        {
        }

        public InternetTrafficException(string message) : base(message)
        {
        }

        public InternetTrafficException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
