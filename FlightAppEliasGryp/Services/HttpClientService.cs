using FlightAppEliasGryp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace FlightAppEliasGryp.Services
{
    public class HttpClientService
    {
        private readonly string baseUri;
        private HttpClientHandler _httpClientHandler;
        private HttpClient _client;

        public HttpClientService()
        {
            baseUri = Models.Environment.GetBaseUri();
        }

        private async Task InitClient()
        {
            _httpClientHandler = new HttpClientHandler();
            _httpClientHandler.ServerCertificateCustomValidationCallback = (message, cert, chain, errors) => { return true; };
            _client = new HttpClient(_httpClientHandler)
            {
                BaseAddress = new Uri(baseUri)
            };
        }

        public async Task<HttpClient> GetHttpClient()
        {
            if (_client == null)
                await InitClient();
            return _client;
        }

        public void Authenticate(string token)
        {
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
        }
    }
}
