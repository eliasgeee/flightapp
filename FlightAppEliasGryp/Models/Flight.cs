using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace FlightAppEliasGryp.Models
{
    public class Flight : ObservableObject
    {
        public int FlightNumber { get; set; }
        public DateTime ExpectedArrivalTime { get; set; }
        public DateTime ExpectedDepartureTime { get; set; }
        public Plane Plane { get; set; }

        private Location _destination;
        public Location Destination { get { return _destination; }
            set {
                _destination = value;
                Set("Destination", ref _destination, value);
            } }

        private Location _origin;
        public Location Origin { get { return _origin; }
            set { Set(ref _origin, value); } }

        private List<Location> _locations;
        public List<Location> Locations { get { return _locations; } set {
                Set(ref _locations, value);
                Destination = FindDestination;
                Origin = FindOrigin;

            } }
        

        public Location FindDestination { get { return Locations.Where(e => e.Type == LocationType.DESTINATION).FirstOrDefault(); } }
        public Location FindOrigin { get { return Locations.Where(e => e.Type == LocationType.ORIGIN).FirstOrDefault(); } }
    }
}
