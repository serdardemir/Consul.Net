using Newtonsoft.Json;

namespace Consul.Net.Types.Agent
{
    public class AgentService
    {
        public string ID { get; set; }

        [JsonProperty("Service")]
        public string Service { get; set; }

        public int Port { get; set; }
    }
}