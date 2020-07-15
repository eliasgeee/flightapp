using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightAppEliasGryp.Helpers
{
    public static class TimeHelper
    {
        public static List<string> GetMinutes()
        {
            List<String> minutes = new List<string>();

            for(int i=1; i < 60; i++)
            {
               minutes.Add(i.ToString());
            }
            return minutes;
        }

        public static List<string> GetHours()
        {
            List<String> hours = new List<string>();

            for (int i = 1; i < 60; i++)
            {
               hours.Add(i.ToString());
            }
            return hours;
        }
    }
}
