using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Consul.Net.Interfaces
{
    public interface IRequestManager : IDisposable
    {
        Task<HttpResponseMessage> RequestAsync(HttpMethod method, string path, object payload = null);

        Task<HttpResponseMessage> RequestAsync(HttpMethod method, string path, QueryBuilder queryBuilder, object payload = null);
    }
}