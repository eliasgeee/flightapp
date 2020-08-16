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

        private long _flightNumber;

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
        public long FlightNumber
        {
            get { return _flightNumber; }

            set
            {
                Set("FlightNumber", ref _flightNumber, value);
            }
        }
        private DateTime eat;
        public DateTime Eat
        {
            get { return eat; }
            set
            {
                this.eat = value;
                RaisePropertyChanged();
            }
        }

        public Location FindDestination { get { return Locations.Where(e => e.Type == LocationType.DESTINATION).FirstOrDefault(); } }
        public Location FindOrigin { get { return Locations.Where(e => e.Type == LocationType.ORIGIN).FirstOrDefault(); } }
    }
}
