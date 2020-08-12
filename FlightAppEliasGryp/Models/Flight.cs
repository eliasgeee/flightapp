using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
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
        public List<Location> Locations { get; set; }
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


    }
}
