# Consul.Net
Consul REST API wrapper for the .NET


### Usage

------------------------------
To run a local consul server:
* Open a command prompt and cd to the "consul" folder.
* Run .\consul.exe agent -dev


```csharp
IConsulConfig config = new ConsulConfig()
{
    ApiPath = "http://localhost:8500"
};

IConsulClient client = new ConsulClient(config);

ConsulResponse response = client.Get(Endpoints.Members).ResultAs<AgentMember[]>();
````

### Key / Value Set
```csharp
Todo todo = new Todo() { Description = "Sample Description", Title = "Sample Title" };

ConsulResponse response = client.Put($"{Endpoints.KV}{CacheKey}", todo);
````

## Using with .NET Core and Mono
