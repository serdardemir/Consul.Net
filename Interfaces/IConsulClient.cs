using Consul.Net.Types;
using System.Threading.Tasks;

namespace Consul.Net.Interfaces
{
    public interface IConsulClient
    {
        ConsulResponse Get(string path);

        Task<ConsulResponse> GetAsync(string path);

        Task<ConsulResponse> SetAsync<T>(string path, T data);
    }
}