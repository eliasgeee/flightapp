using FlightAppEliasGryp.Models.Entertainment.Video;
using FlightAppEliasGryp.Services;
using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightAppEliasGryp.ViewModels
{
    public class VideoFeedViewModel : ViewModelBase
    {
        public NavigationServiceEx NavigationService => ViewModelLocator.Current.NavigationService;

        private VideoFeed _videoFeed;
        public VideoFeed VideoFeed { get { return _videoFeed; } set { Set(ref _videoFeed, value); } }

        private readonly IEntertainmentService _entertainmentService;

        public VideoFeedViewModel(IEntertainmentService entertainmentService)
        {
            _entertainmentService = entertainmentService;
        }

        public async Task LoadDataAsync()
        {
            var data = await _entertainmentService.GetVideoFeed();
            VideoFeed = data;
        }

    }
}
