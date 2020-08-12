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
        private readonly string baseUri = "Flight/";
        private HttpClientService _clientService;
        private DataService<Flight> _flightDataService;
        private DataService<Seat> _seatDataService;
        private DataService<ApplicationUser> _userDataService;

        public FlightService(HttpClientService clientService)
        {
            _clientService = clientService;
            _flightDataService = new DataService<Flight>(_clientService);
            _seatDataService = new DataService<Seat>(_clientService);
            _userDataService = new DataService<ApplicationUser>(_clientService);
        }

        public async Task<Flight> GetInfoCurrentFlight()
        {
            var request = await _flightDataService.MakeRequest(new ApiRequest(ApiRequestType.GET)
            {
                Uri = baseUri + "Flight"
            });
            return request.AsSingle();
        }

        public async Task<IList<Seat>> GetSeatsAsync()
        {
            var request = await _seatDataService.MakeRequest(new ApiRequest(ApiRequestType.GET)
            {
                Uri = baseUri + "Seats"
            });
            return request.AsList().ToList();
        }

        public async Task<IList<Seat>> SwitchSeatsAsync(Seat seat1, Seat seat2)
        {
            var request = await _seatDataService.MakeRequest(new ApiRequest(ApiRequestType.POST)
            {
                Uri = baseUri + "Passenger/Seats/",
                Body = new ChangeSeatDTO(seat1, seat2)
            });
            return request.AsList().ToList();
        }

        public async Task<ICollection<ApplicationUser>> GetTravelGroup(Passenger passenger)
        {
            var request = await _userDataService.MakeRequest(new ApiRequest(ApiRequestType.GET)
            {
                Uri = baseUri + "Travelgroup/" + passenger.TravelGroupId
            });
            return request.AsList();
        }
    }
}
