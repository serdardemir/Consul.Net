using Consul.Net.Interfaces;
using System;

namespace Consul.Net
{
    public class ConsulConfig : IConsulConfig
    {
        private string apiPath;

        public ConsulConfig()
        {
        }

        public string ApiPath
        {
            get
            {
                return apiPath.EndsWith("/") ? apiPath : $"{apiPath}/";
            }
            set { apiPath = value; }
        }

        public string Host { get; set; }

        public TimeSpan? RequestTimeout { get; set; }

        //TODO :Need abstraction
        public ISerializer Serializer { get; set; }

        public string Version { get; set; } = "v1";
    }
}
