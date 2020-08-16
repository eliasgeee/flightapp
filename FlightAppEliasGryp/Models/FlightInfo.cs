using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightAppEliasGryp.Models
{
    public class FlightInfo
    {
        public Flight Flight { get; set; }
        public DateTime RemainingDurationFlight { get; set; }
        public double DistanceToDestination { get; set; }
        public double CurrentAltitude { get; set; }
    }
}
