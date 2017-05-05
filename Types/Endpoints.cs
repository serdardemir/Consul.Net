namespace Consul.Net.Types
{
    public static class Endpoints
    {
        //AGENT

        public const string Members = "agent/members";
        public const string Services = "agent/services";
        public const string ReloadAgent = "agent/reload";

        //KEY / VALUE STORE
        public const string KV = "kv/";

        //HEALTH

        public const string ServiceHealthCheck = "health/checks/";
    }
}
