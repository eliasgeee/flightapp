using FlightAppEliasGryp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightAppEliasGryp.Services
{
    public interface IFlightService
    {
        Task<IList<Seat>> GetSeatsAsync();
        Task<IList<Seat>> SwitchSeatsAsync(Seat seat1, Seat seat2);
        Task<FlightInfo> GetInfoCurrentFlight();
        Task<ICollection<ApplicationUser>> GetTravelGroup(Passenger passenger);
    }
}
