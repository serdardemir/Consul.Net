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

        //SESSION
        public const string CreateSession = "/session/create";
        public const string DeleteSession = "/session/destroy/";
        public const string ReadSession = "/session/info/";
        public const string SessionList = "/session/list";
        public const string RenewSession = "/session/renew/";

        //EVENT
        public const string Events = "/event/list";
        public const string FireEvent = "/event/fire/";



        //HEALTH
        public const string NodeHealthCheck = "health/node/{:nodeName}";

        public const string ServiceHealthCheck = "health/checks/";

        //ADMINISTRATION
        public const string RaftLeader = "/status/leader";

        public const string RaftPeers = "/status/peers";
        public const string Snapshot = "/snapshot";
    }
}