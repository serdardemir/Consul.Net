using Consul.Net.Helpers;
using Consul.Net.Interfaces;
using Consul.Net.Types;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Consul.Net
{
    public class RequestManager : IRequestManager
    {
        private readonly IConsulConfig config;
        private readonly HttpClient httpClient;

        public RequestManager(IConsulConfig config)
        {
            ValidationHelper.ValidateNull(config, "Configuration");

            this.config = config;

            httpClient = new HttpClient();

            var basePath = config.ApiPath.EndsWith("/") ? config.ApiPath : config.ApiPath + "/";
            httpClient.BaseAddress = new Uri(basePath);

            if (config.RequestTimeout.HasValue)
            {
                httpClient.Timeout = config.RequestTimeout.Value;
            }
            this.config = config;
        }

        public Task<HttpResponseMessage> RequestAsync(HttpMethod method, string path, object payload)
        {
            return RequestAsync(method, path, null, payload);
        }

        public Task<HttpResponseMessage> RequestAsync(HttpMethod method, string path, QueryBuilder queryBuilder, object payload = null)
        {
            try
            {
                var uri = PrepareUri(path, queryBuilder);
                var request = PrepareRequest(method, uri, payload);

                return httpClient.SendAsync(request, HttpCompletionOption.ResponseContentRead);
            }
            catch (Exception ex)
            {
                throw new ConsulException(ex.Message);
            }
        }

        private HttpRequestMessage PrepareRequest(HttpMethod method, Uri uri, object payload)
        {
            var request = new HttpRequestMessage(method, uri);

            if (payload != null)
            {
                request.Content = new StringContent(payload as string ?? JsonConvert.SerializeObject(payload));
            }

            return request;
        }
        

        private Uri PrepareUri(string path, QueryBuilder queryBuilder)
        {
            var queryStr = string.Empty;
            if (queryBuilder != null)
            {
                queryStr = $"&{queryBuilder.ToQueryString()}";
            }

            var url = $"{config.ApiPath}{config.Version}{"/"}{path}{queryStr}";

            return new Uri(url);
        }

        public void Dispose()
        {

        }
    }
}