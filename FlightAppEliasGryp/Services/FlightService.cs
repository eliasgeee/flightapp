using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using FlightAppEliasGryp.Models;
using FlightAppEliasGryp.Models.DTO_s;
using Newtonsoft.Json;

namespace FlightAppEliasGryp.Services
{
    public class FlightService : IFlightService
    {
        private readonly string baseUri = "https://localhost:44332/api/Flight/";

        public async Task<IList<Seat>> GetSeatsAsync()
        {
            using (var httpClientHandler = new HttpClientHandler())
            {
                httpClientHandler.ServerCertificateCustomValidationCallback = (message, cert, chain, errors) => { return true; };
                using (var client = new HttpClient(httpClientHandler))
                {
                    var reqUri = baseUri + "Seats";
                    var json = await client.GetStringAsync(new Uri(reqUri));
                    return JsonConvert.DeserializeObject<IList<Seat>>(json);
                }
            }
        }

        public async Task<IList<Seat>> SwitchSeatsAsync(Seat seat1, Seat seat2)
        {
            using (var httpClientHandler = new HttpClientHandler())
            {
                httpClientHandler.ServerCertificateCustomValidationCallback = (message, cert, chain, errors) => { return true; };
                using (var client = new HttpClient(httpClientHandler))
                {
                    var reqUri = baseUri + "Passenger/Seats/";
                    var json = await client.PostAsync(new Uri(reqUri), new StringContent(JsonConvert.SerializeObject(new ChangeSeatDTO(seat1, seat2)), System.Text.Encoding.UTF8, "application/json"));
                    return null;
                }
            }
        }
    }
}
