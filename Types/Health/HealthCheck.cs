using Consul.Net.Converter;
using Newtonsoft.Json;

namespace Consul.Net.Types.Health
{
    public class HealthCheck
    {
        public string Node { get; set; }
        public string CheckID { get; set; }
        public string Name { get; set; }

        [JsonConverter(typeof(HealthStatusConverter))]
        public HealthStatus Status { get; set; }

        public string Notes { get; set; }
        public string Output { get; set; }
        public string ServiceID { get; set; }
        public string ServiceName { get; set; }
    }
}