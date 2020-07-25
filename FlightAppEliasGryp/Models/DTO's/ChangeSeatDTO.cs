using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightAppEliasGryp.Models.DTO_s
{
    public class ChangeSeatDTO
    {
        public Seat Seat1 { get; set; }
        public Seat Seat2 { get; set; }

        public ChangeSeatDTO(Seat seat1, Seat seat2)
        {
            Seat1 = seat1;
            Seat2 = seat2;
        }
    }
}
