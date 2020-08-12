using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightAppEliasGryp.Models
{
    public static class Environment
    {
        public static string GetBaseUri()
        {
            return "https://localhost:44332/api/";
        }
    }
}
