using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightAppEliasGryp.Models.DTO_s
{
    public class AddConversationDTO
    {
        public string Message { get; set; }
        public List<Passenger> Users { get; set; }
    }
}
