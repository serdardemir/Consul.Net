using Consul.Net.Interfaces;
using System;

namespace Consul.Net
{
    public class ConsulConfig : IConsulConfig
    {
        private string pathBase;

        public ConsulConfig()
        {
        }

        public string PathBase
        {
            get
            {
                return pathBase.EndsWith("/") ? pathBase : $"{pathBase}/";
            }
            set { pathBase = value; }
        }

        public string Host { get; set; }

        public TimeSpan? RequestTimeout { get; set; }

        //TODO :Need abstraction
        public ISerializer Serializer { get; set; }

        public string Version { get; set; } = "v1";
    }
}