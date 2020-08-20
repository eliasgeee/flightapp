using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightAppEliasGryp.Models.Entertainment.Audio
{
    public class Track : MultiMedia
    {
        public Guid AlbumId { get; set; }
        public Artist Artist { get; set; }
        public MusicGenre MusicGenre { get; set; }
        public string AudioType { get; set; }
    }

    public enum MusicGenre
    {
        RAP, POP, ROCK, ELECTRONIC, JAZZ, BLUES, RNB
    }
}
