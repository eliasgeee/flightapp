using FlightAppEliasGryp.Models;
using FlightAppEliasGryp.Services;
using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightAppEliasGryp.ViewModels
{
    public class WeatherForecastViewModel : ViewModelBase
    {
        private WeatherForecast _weatherForecast;
        public WeatherForecast WeatherForecast { get { return _weatherForecast; }
            set { Set(ref _weatherForecast, value); }}

        private Location _location;
        public Location Location { get { return _location; } set { Set(ref _location, value); } }

        private IWeatherDataService _weatherDataService { get; set; }

        public WeatherForecastViewModel(IWeatherDataService weatherDataService)
        {
            _weatherDataService = weatherDataService;
        }

        public async void GetCurrentWeatherAsync(Location location)
        {
            var forecast = await _weatherDataService.GetCurrentWeatherForDestination(location);
            WeatherForecast = forecast;
        }
    }
}
