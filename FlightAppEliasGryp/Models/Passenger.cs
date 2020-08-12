using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightAppEliasGryp.Models
{
    public class Passenger : ApplicationUser
    {
        public int TravelGroupId { get; set; }

        public override string GetFullName()
        {
            return base.GetFullName();
        }
    }
}
