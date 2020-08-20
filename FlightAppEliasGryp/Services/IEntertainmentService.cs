using FlightAppEliasGryp.Models.Entertainment.Audio;
using FlightAppEliasGryp.Models.Entertainment.Video;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage.Streams;

namespace FlightAppEliasGryp.Services
{
    public interface IEntertainmentService
    {
        Task<VideoFeed> GetVideoFeed();
        Task<AudioFeed> GetAudioFeed();
    }
}
