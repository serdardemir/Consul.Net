using Consul.Net.Types;

namespace Consul.Net.Helpers
{
    public class ValidationHelper
    {
        public static void ValidateNull(object field, string fieldName)
        {
            if (field == null || string.IsNullOrEmpty(field.ToString()))

                throw new ParameterException(string.Format("{0} cannot contain null values.", fieldName));
        }
    }
}