using Newtonsoft.Json;
using System.Net;

namespace Consul.Net.Types
{
    public class ConsulResponse
    {
        public string Body { get; set; }
        public HttpStatusCode StatusCode { get; }

        public ConsulResponse(string body, HttpStatusCode statusCode)
        {
            this.Body = body;
            this.StatusCode = statusCode;
        }

        public virtual T ResultAs<T>()
        {
            return JsonConvert.DeserializeObject<T>(Body);
        }
    }
}