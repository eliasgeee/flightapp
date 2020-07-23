using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightAppEliasGryp.Helpers
{
    public static class SeatHelper
    {
        public static char[] alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();

        public static List<char> GetChairs(int chairCount)
        {
            return Enumerable.Range('A', alphabet[chairCount- 1] - 'A' + 1).Select(i => (char)i).ToList();
        }

        public static List<int> GetRows(int rowCount)
        {
            List<int> rows = new List<int>();
            for (int i = 1; i <= rowCount; i++) {
                rows.Add(i);
            }
            return rows;
        }
    }
}
