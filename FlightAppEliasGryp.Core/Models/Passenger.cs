using System;
using System.Collections.Generic;
using System.Text;

namespace FlightAppEliasGryp.Core.Models
{
    public class Passenger
    {
        public int Id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }

        public string GetFullName()
        {
            return $"{Firstname} {Lastname}";
        }
    }
}
