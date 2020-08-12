using FlightAppEliasGryp.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FlightAppEliasGryp.Core.Interfaces
{
    public interface IFlightDataService
    {
        Task<IList<Seat>> GetSeatsAsync();
        Task<IList<Seat>> SwitchSeatsAsync(Seat seat1, Seat seat2);
    }
}
