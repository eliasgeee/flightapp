using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightAppEliasGryp.Models.Entertainment.Audio
{
    public class AudioFeed
    {
        public List<Podcast> Podcasts { get; set; }
        public List<Artist> Artists { get; set; }
        public List<Track> Tracks { get; set; }
        public List<Album> Albums { get; set; }
    }
}
