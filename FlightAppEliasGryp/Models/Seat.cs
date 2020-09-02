using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightAppEliasGryp.Models
{
    public class Seat : ObservableObject
    {
        public int Row { get; set; }
        public char Chair { get; set; }

        private Passenger _passenger;
        public Passenger Passenger { get { return _passenger; } set { Set("Passenger", ref _passenger, value); } }

        public Seat() { }

        public string GetPassenger()
        {
            if (Passenger == null)
                return "Empty seat";
            else
                return Passenger.GetFullName();
        }

        public override string ToString() { return $"{Row}{Chair}"; }
    }
}
