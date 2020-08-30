using FlightAppEliasGryp.Models.Entertainment;
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
    public class VideoDetailViewModel : ViewModelBase
    {
        public NavigationServiceEx NavigationService => ViewModelLocator.Current.NavigationService;

        public void PlayMedia(MultiMedia media)
        {
            NavigationService.Navigate("FlightAppEliasGryp.ViewModels.MediaPlayerViewModel", media);
        }
    }
}
