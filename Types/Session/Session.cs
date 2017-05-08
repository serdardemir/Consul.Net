using Consul.Net.Converter;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Consul.Net.Types.Session
{
    public class Session
    {
        public ulong CreateIndex { get; set; }

        public string ID { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string Name { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string Node { get; set; }

        public List<string> Checks { get; set; }
        
        public long? LockDelay { get; set; }
        [JsonConverter(typeof(SessionBehaviorConverter))]
        public SessionBehavior Behavior { get; set; }
        
        public long? TTL { get; set; }

        public Session()
        {
            Checks = new List<string>();
        }
    }
}
