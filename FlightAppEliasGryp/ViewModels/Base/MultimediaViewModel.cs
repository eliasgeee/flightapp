using FlightAppEliasGryp.Models.Entertainment;
using FlightAppEliasGryp.Models.Entertainment.Video;
using FlightAppEliasGryp.Services;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Windows.UI.Xaml.Controls;

namespace FlightAppEliasGryp.ViewModels.Base
{
    public class MultimediaViewModel : ViewModelBase
    {
        public NavigationServiceEx NavigationService => ViewModelLocator.Current.NavigationService;
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Duration { get; set; }
        public string FileName { get; set; }
        public string Thumbnail { get; set; }
        public VideoGenre VideoGenre { get; set; }
        public List<Episode> Episodes { get; set; }
        public int AmountOfEpisode { get { return Episodes.Count; } }
        public MultiMediaType Type { get; set; }

        public MultimediaViewModel(MultiMedia multiMedia)
        {
            if (multiMedia is Serie)
                InitSerie(multiMedia as Serie);
            if (multiMedia is Movie)
                InitMovie(multiMedia as Movie);
        }

        public void InitSerie(Serie serie)
        {
            Id = serie.Id;
            Name = serie.Name;
            Description = serie.Description;
            Duration = serie.Duration;
            FileName = serie.FileName;
            Thumbnail = serie.Thumbnail;
            VideoGenre = serie.VideoGenre;
            Episodes = serie.Episodes;
            Type = MultiMediaType.SERIE;
        }

        public void InitMovie(Movie movie)
        {
            Id = movie.Id;
            Name = movie.Name;
            Description = movie.Description;
            Duration = movie.Duration;
            FileName = movie.FileName;
            Thumbnail = movie.Thumbnail;
            VideoGenre = movie.VideoGenre;
            Type = MultiMediaType.MOVIE;
        }

        public void ViewDetails()
        {
            NavigationService.Navigate("FlightAppEliasGryp.ViewModels.VideoDetailViewModel", this);
        }
    }

    public enum MultiMediaType {
        MOVIE, SERIE
    }
}
