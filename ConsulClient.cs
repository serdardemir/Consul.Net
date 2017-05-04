using Consul.Net.Interfaces;
using Consul.Net.Types;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Consul.Net
{
    public class ConsulClient : IConsulClient
    {
        private readonly IRequestManager requestManager;

        public ConsulClient(IConsulConfig config) : this(new RequestManager(config))
        {
        }

        public ConsulClient(IRequestManager requestManager)
        {
            this.requestManager = requestManager;
        }

        public ConsulResponse Get(string path)
        {
            try
            {
                using (var response = requestManager.RequestAsync(HttpMethod.Get, path).Result)
                {
                    var content = response.Content.ReadAsStringAsync().Result;

                    return new ConsulResponse(content, response.StatusCode);
                }
            }
            catch (HttpRequestException ex)
            {
                throw new Exception();
            }
        }

        public async Task<ConsulResponse> GetAsync(string path)
        {
            try
            {
                using (var response = await requestManager.RequestAsync(HttpMethod.Get, path).ConfigureAwait(false))
                {
                    var content = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

                    return new ConsulResponse(content, response.StatusCode);
                }
            }
            catch (HttpRequestException ex)
            {
                throw new ConsulException();
            }
        }

        public Task<ConsulResponse> SetAsync<T>(string path, T data)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        ~ConsulClient()
        {
        }
    }
}