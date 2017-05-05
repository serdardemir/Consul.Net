using Consul.Net.Types.Health;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Consul.Net.Converter
{
    public class HealthStatusConverter : JsonConverter
    {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            serializer.Serialize(writer, ((HealthStatus)value).Status);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue,
            JsonSerializer serializer)
        {
            var status = (string)serializer.Deserialize(reader, typeof(string));
            switch (status)
            {
                case "passing":
                    return HealthStatus.Passing;
                case "warning":
                    return HealthStatus.Warning;
                case "critical":
                    return HealthStatus.Critical;
                default:
                    throw new ArgumentException("Invalid Check status value during deserialization");
            }
        }

        public override bool CanConvert(Type objectType)
        {
            if (objectType == typeof(HealthStatus))
            {
                return true;
            }
            return false;
        }
    }
}
