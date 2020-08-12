using System;
using System.Collections.Generic;
using System.Text;

namespace FlightAppEliasGryp.Core.Models
{
    public class Seat
    {
        public int Row { get; set; }
        public char Chair { get; set; }
        public Passenger Passenger { get; set; }

        public Seat()
        {

        }

        //public string GetPassenger()
        //{
        //    if (Passenger == null)
        //        return "Empty seat";
        //    else
        //        return Passenger.GetFullName();
        //}

        public override string ToString()
        {
            return Row.ToString() + Chair.ToString();
        }

    }
}
