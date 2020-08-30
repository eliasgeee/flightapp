using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightAppEliasGryp.Models.Entertainment.Audio
{
    public class Podcast : MultiMedia
    {
        public List<PodcastHost> Hosts { get; private set; }
        public PodcastGenre PodcastGenre { get; set; }

        
    }

    public enum PodcastGenre
    {
        INFORMATIVE, CRIME, MUSIC, COMEDY
    }
}
