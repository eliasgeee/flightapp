using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightAppEliasGryp.Models
{
    public class AddPassengerNotificationDTO
    {
        public string Text { get; set; }
        public ICollection<Passenger> Receivers { get; set; }
    }
}
