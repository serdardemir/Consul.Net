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

        public Task<PutResponse> PutAsync<T>(string path, T data)
        {
            throw new NotImplementedException();
        }

        public PutResponse Put<T>(string path, T data)
        {
            try
            {
                using (var response = requestManager.RequestAsync(HttpMethod.Put, path, data).Result)
                {
                    var content = response.Content.ReadAsStringAsync().Result;

                    return new PutResponse(content, response.StatusCode);
                }
            }
            catch (HttpRequestException ex)
            {
                throw new ConsulException(ex.Message);
            }
        }

        public PutResponse Put(string path)
        {
            try
            {
                using (var response = requestManager.RequestAsync(HttpMethod.Put, path).Result)
                {
                    var content = response.Content.ReadAsStringAsync().Result;

                    return new PutResponse(content, response.StatusCode);
                }
            }
            catch (HttpRequestException ex)
            {
                throw new ConsulException(ex.Message);
            }
        }

        public ConsulResponse Delete(string path)
        {
            try
            {
                using (var response = requestManager.RequestAsync(HttpMethod.Delete, path).Result)
                {
                    var content = response.Content.ReadAsStringAsync().Result;

                    return new PutResponse(content, response.StatusCode);
                }
            }
            catch (HttpRequestException ex)
            {
                throw new ConsulException(ex.Message);
            }
        }

        public Task<ConsulResponse> DeleteAsync(string path)
        {
            throw new NotImplementedException();
        }

        ~ConsulClient()
        {
        }
    }
}