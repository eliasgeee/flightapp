﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightAppEliasGryp.Models
{
    public class Passenger
    {
        public int Id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public Seat SeatNumber { get; set; }

        public string GetFullName()
        {
            return Firstname + " " + Lastname;
        }
    }
}