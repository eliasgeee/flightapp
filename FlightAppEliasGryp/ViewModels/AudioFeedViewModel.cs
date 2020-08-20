using FlightAppEliasGryp.Models.Entertainment.Audio;
using FlightAppEliasGryp.Services;
using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightAppEliasGryp.ViewModels
{
    public class AudioFeedViewModel : ViewModelBase
    {
        public NavigationServiceEx NavigationService => ViewModelLocator.Current.NavigationService;

        private AudioFeed _audioFeed;
        public AudioFeed AudioFeed { get { return _audioFeed; } set { Set(ref _audioFeed, value); } }

        private readonly IEntertainmentService _entertainmentService;

        public AudioFeedViewModel(IEntertainmentService entertainmentService)
        {
            _entertainmentService = entertainmentService;
        }

        public async void LoadDataAsync()
        {
            var data = await _entertainmentService.GetAudioFeed();
            AudioFeed = data;
        }
    }
}
