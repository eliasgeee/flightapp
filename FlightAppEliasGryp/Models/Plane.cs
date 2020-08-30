using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightAppEliasGryp.Models
{
    public class Plane
    {
        public int Id { get; set; }
        public int MaxAmountOfSeats { get; set; }
        public string Manufacturer { get; set; }
        public string Model { get; set; }

        public override string ToString()
        {
            return $"{Manufacturer} {Model}";
        }
    }
}
