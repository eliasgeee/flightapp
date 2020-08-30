using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightAppEliasGryp.Models.Entertainment.Audio
{
    public class Album : MultiMedia
    {
        public Artist Artist { get; set; }
        public MusicGenre MusicGenre { get; set; }
        public List<Track> Tracks { get; set; }
    }
}
