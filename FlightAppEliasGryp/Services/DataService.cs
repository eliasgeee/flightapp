using FlightAppEliasGryp.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace FlightAppEliasGryp.Services
{
    public class DataService<T>
    {
        private HttpClientService _httpClientService;
        private Uri baseUri;
        private HttpClient _client;

        private string _json { get; set; }
        private ApiRequest _apiRequest { get; set; } 

        public DataService(HttpClientService httpClientService)
        {
            _httpClientService = httpClientService;
        }

        public async Task Init()
        {
            var client = await _httpClientService.GetHttpClient();
            _client = client;
            baseUri = client.BaseAddress;
        }

        public async Task<DataService<T>> MakeRequest(ApiRequest apiRequest)
        {
            if (_client == null) await Init();

            _json = null;

            switch (apiRequest.ApiRequestType)
            {
                case ApiRequestType.GET:
                    await Get(apiRequest);
                    break;
                case ApiRequestType.POST:
                    await Post(apiRequest);
                    break;
                case ApiRequestType.PUT:
                    await Put(apiRequest);
                    break;
                case ApiRequestType.DELETE:
                    await Delete(apiRequest);
                    break;
            }

            return this;
        }

        private async Task<DataService<T>> Get(ApiRequest apiRequest) {
            _json = await _client.GetStringAsync(baseUri + apiRequest.Uri); return this; }

        private async Task Post(ApiRequest apiRequest) {
            var response = await _client.PostAsync(new Uri(baseUri + apiRequest.Uri),
                new StringContent(JsonConvert.SerializeObject(apiRequest.Body), System.Text.Encoding.UTF8, "application/json"));
            if (response.IsSuccessStatusCode)
                _json = await response.Content.ReadAsStringAsync();
        }

        private async Task Put (ApiRequest apiRequest) {
            var response = await _client.PutAsync(new Uri(baseUri + apiRequest.Uri),
                new StringContent(JsonConvert.SerializeObject(apiRequest.Body), System.Text.Encoding.UTF8, "application/json"));
            if (response.IsSuccessStatusCode)
                _json = await response.Content.ReadAsStringAsync();
        }

        private async Task Delete (ApiRequest apiRequest) {
            var response = await _client.DeleteAsync(new Uri(apiRequest.Uri));
            if (response.IsSuccessStatusCode)
                _json = await response.Content.ReadAsStringAsync();
        }

        //TODO switch to Either return
        public T AsSingle() {
            try { return JsonConvert.DeserializeObject<T>(_json); }
            catch (Exception e) { return default(T);  }
           }

        public ICollection<T> AsList() {
            try { return JsonConvert.DeserializeObject<ICollection<T>>(_json); }
            catch (Exception e) { return default(ICollection<T>);  }
        }
    }
}
