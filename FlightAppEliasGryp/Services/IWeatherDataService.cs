using FlightAppEliasGryp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightAppEliasGryp.Services
{
    public interface IWeatherDataService
    {
        Task<WeatherForecast> GetCurrentWeatherForDestination(Location location);
    }
}
