using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlightAppEliasGryp.Models;

namespace FlightAppEliasGryp.Services
{
    public class WeatherDataService : IWeatherDataService
    {
        private readonly string baseUrl = "Weather/";
        private HttpClientService _clientService;
        private DataService<WeatherForecast> _dataService;

        public WeatherDataService(HttpClientService clientService)
        {
            _clientService = clientService;
            _dataService = new DataService<WeatherForecast>(_clientService);
        }

        public async Task<WeatherForecast> GetCurrentWeatherForDestination(Location location)
        {
            var request = await _dataService.MakeRequest(new ApiRequest(ApiRequestType.GET) {
                Uri = baseUrl + location.Latitude + "/" + location.Longitude
            });
            return request.AsSingle();
        }
    }
}
