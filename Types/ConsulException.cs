using System;

namespace Consul.Net.Types
{
    public class ConsulException : Exception
    {
        public ConsulException() : base()
        {
        }

        public ConsulException(string message) : base(message)
        {
        }

        public ConsulException(string format, params object[] args) : base(string.Format(format, args))
        {
        }

        public ConsulException(string message, System.Exception innerException) : base(message, innerException)
        {
        }

        public ConsulException(string format, System.Exception innerException, params object[] args) : base(string.Format(format, args), innerException)
        {
        }
    }
}