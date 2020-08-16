using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightAppEliasGryp.Models
{
    public class WeatherForecast
    {
        public Location Location { get; set; }
        public DateTime Time { get; set; }

        public double TempInCelsius { get; set; }
        public double TempInFahrenheit { get; set; }

        public double MinTempInCelsius { get; set; }
        public double MinTempInFahrenheit { get; set; }

        public double MaxTempInCelsius { get; set; }
        public double MaxTempInFahrenheit { get; set; }

        public int Pressure { get; set; }
        public int Humidity { get; set; }

        public int Cloudiness { get; set; }
        public double WindSpeed { get; set; }

        public string Description { get; set; }

        public string Title { get { return $"Weather in {Location.City}"; } }

        public string TempInCelsiusFormatter { get { return $"{TempInCelsius} °C"; } }
        public string TempInFahrenheitFormatter { get { return $"{TempInFahrenheit} °F"; } }

        public string MaxTempInCelsiusFormatter { get { return $"{MaxTempInCelsius} °C"; } }
        public string MaxTempInFahrenheitFormatter { get { return $"{MaxTempInFahrenheit} °F"; } }

        public string MinTempInCelsiusFormatter { get { return $"{MinTempInCelsius} °C"; } }
        public string MinTempInFahrenheitFormatter { get { return $"{MinTempInFahrenheit} °F"; } }

        public string PressureFormatted { get { return $"{Pressure} Fa"; } }
        public string CloudinessFormatted { get { return $"{Cloudiness} %"; } }
        public string HumidityFormatted { get { return $"{Humidity} %"; } }
        public string WindspeedFormatted { get { return $"{WindSpeed} m/s"; } }
    }
}
