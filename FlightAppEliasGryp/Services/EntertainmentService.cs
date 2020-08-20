using FlightAppEliasGryp.Models;
using FlightAppEliasGryp.Models.Entertainment.Audio;
using FlightAppEliasGryp.Models.Entertainment.Video;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage.Streams;

namespace FlightAppEliasGryp.Services
{
    public class EntertainmentService : IEntertainmentService
    {
        private readonly string baseUri = "Entertainment/";
        private HttpClientService _clientService;
        private DataService<VideoFeed> _videoDataService;
        private DataService<AudioFeed> _audioDataService;

        public EntertainmentService(HttpClientService clientService)
        {
            _clientService = clientService;
            _videoDataService = new DataService<VideoFeed>(_clientService);
            _audioDataService = new DataService<AudioFeed>(_clientService);
        }

        public async Task<AudioFeed> GetAudioFeed()
        {
            var request = await _audioDataService.MakeRequest(new ApiRequest(ApiRequestType.GET)
            {
                Uri = baseUri + "AudioFeed"
            });
            return request.AsSingle();
        }

        public async Task<VideoFeed> GetVideoFeed()
        {
            var request = await _videoDataService.MakeRequest(new ApiRequest(ApiRequestType.GET)
            {
                Uri = baseUri + "VideoFeed"
            });
            return request.AsSingle();
        }
    }
}
