using Consul.Net.Types;
using System;
using System.Threading.Tasks;

namespace Consul.Net.Interfaces
{
    public interface IConsulClient : IDisposable
    {
        ConsulResponse Get(string path);

        Task<ConsulResponse> GetAsync(string path);

        Task<ConsulResponse> SetAsync<T>(string path, T data);

        PutResponse Put<T>(string path, T data);

        PutResponse Put(string path);

        Task<PutResponse> PutAsync<T>(string path, T data);

        ConsulResponse Delete(string path);

        Task<ConsulResponse> DeleteAsync(string path);

    }
}