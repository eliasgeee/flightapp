using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightAppEliasGryp.Models
{
    public class SeatNumber
    {
        public int Row { get; set; }
        public char Chair { get; set; }
        public Passenger Passenger { get; set; }

        public SeatNumber()
        {

        }

        public override string ToString()
        {
            return Row.ToString() + Chair.ToString();
        }

    }
}
