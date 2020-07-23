using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using FlightAppEliasGryp.Models;
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
    }
}
