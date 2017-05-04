using Consul.Net.Interfaces;
using Consul.Net.Types.Agent;

namespace Consul.Net
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            IConsulConfig config = new ConsulConfig()
            {
                ApiPath = "http://localhost:8500"
            };

            IConsulClient client = new ConsulClient(config);

            var result = client.Get("agent/members").ResultAs<AgentMember[]>();

            var services = client.Get("agent/services").ResultAs<AgentService>();
        }
    }
}