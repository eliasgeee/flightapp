using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightAppEliasGryp.Models.Entertainment.Video
{
    public class VideoFeed
    {
        public List<Movie> Movies { get; set; }
        public List<Serie> Series { get; set; }

        public List<MultiMedia> GetByCategory(VideoGenre videoGenre)
        {
            var series = Series.Where(e => e.VideoGenre == videoGenre);
            var movies = Movies.Where(e => e.VideoGenre == videoGenre);
            List<MultiMedia> multiMedias = new List<MultiMedia>();
            multiMedias.AddRange(series);
            multiMedias.AddRange(movies);
            return multiMedias;
        }
    }
}
