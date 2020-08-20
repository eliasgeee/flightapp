using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightAppEliasGryp.Models.Entertainment.Video
{
    public class Movie : MultiMedia
    {
        public VideoGenre VideoGenre { get; set; }
    }

    public enum VideoGenre
    {
        DOCUMENTARY, ACTION, COMEDY, THRILLER
    }
}
