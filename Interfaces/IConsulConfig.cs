using System;

namespace Consul.Net.Interfaces
{
    public interface IConsulConfig
    {
        string PathBase { get; set; }
        string Host { get; set; }
        string Version { get; set; }
        TimeSpan? RequestTimeout { get; set; }
    }
}