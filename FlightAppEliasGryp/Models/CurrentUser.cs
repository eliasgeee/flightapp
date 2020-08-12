using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightAppEliasGryp.Models
{
    public class CurrentUser
    {
        public string UserID { get; set; }
        public int Row { get; set; }
        public char Chair { get; set; }
        public string Token { get; set; }
    }
}
