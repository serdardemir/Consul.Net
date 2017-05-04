namespace Consul.Net.Types
{
    public class ParameterException : System.Exception
    {
        public ParameterException()
            : base() { }

        public ParameterException(string message)
            : base(message) { }

        public ParameterException(string format, params object[] args)
            : base(string.Format(format, args)) { }

        public ParameterException(string message, System.Exception innerException)
            : base(message, innerException) { }

        public ParameterException(string format, System.Exception innerException, params object[] args)
            : base(string.Format(format, args), innerException) { }
    }
}