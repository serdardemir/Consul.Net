namespace Consul.Net.Types.Event
{
    public class Event
    {
        public string ID { get; set; }
        public string Name { get; set; }
        public byte[] Payload { get; set; }
        public string NodeFilter { get; set; }
        public string ServiceFilter { get; set; }
        public string TagFilter { get; set; }
        public int Version { get; set; }
        public ulong LTime { get; set; }
    }
}