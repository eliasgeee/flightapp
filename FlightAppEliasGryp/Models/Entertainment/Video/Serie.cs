using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightAppEliasGryp.Models.Entertainment.Video
{
    public class Serie : MultiMedia
    {
        public List<Episode> Episodes { get; set; }
        public int AmountOfEpisode { get { return Episodes.Count; } }
        public VideoGenre VideoGenre { get; set; } 
    }
}
