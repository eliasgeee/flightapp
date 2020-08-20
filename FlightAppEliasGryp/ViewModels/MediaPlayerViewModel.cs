using FlightAppEliasGryp.Services;
using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Media.Core;
using Windows.Media.Playback;
using Windows.Storage.Streams;
using FlightAppEliasGryp.Models;
using Environment = FlightAppEliasGryp.Models.Environment;

namespace FlightAppEliasGryp.ViewModels
{
    public class MediaPlayerViewModel : ViewModelBase
    {

        private IMediaPlaybackSource _source;

        public IMediaPlaybackSource Source
        {
            get { return _source; }
            set { Set(ref _source, value); }
        }

        private string _posterSource;

        public string PosterSource
        {
            get { return _posterSource; }
            set { Set(ref _posterSource, value); }
        }

        public MediaPlayerViewModel()
        {
           
        }

        public void DisposeSource()
        {
            var mediaSource = Source as MediaSource;
            mediaSource?.Dispose();
            Source = null;
        }
    }
}
