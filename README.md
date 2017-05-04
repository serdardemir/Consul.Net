# Consul.Net
Consul REST API wrapper for the .NET


### Usage

------------------------------

```csharp
IConsulConfig config = new ConsulConfig()
{
    ApiPath = "http://localhost:8500"
};

IConsulClient client = new ConsulClient(config);

var result = client.Get("agent/members").ResultAs<AgentMember[]>();
````
