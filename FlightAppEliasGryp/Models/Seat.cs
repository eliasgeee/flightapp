using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightAppEliasGryp.Models
{
    public class Seat
    {
        public int Row { get; set; }
        public char Chair { get; set; }
        public Passenger Passenger { get; set; }

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
