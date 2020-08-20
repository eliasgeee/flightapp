using FlightAppEliasGryp.Helpers;
using FlightAppEliasGryp.Models.Entertainment.Video;
using FlightAppEliasGryp.ViewModels;
using FlightAppEliasGryp.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace FlightAppEliasGryp.Views.Entertainment.Video
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class VideoFeedPage : Page
    {
        public IEnumerable<VideoGenre> Categories { get { return EnumHelper.GetValues<VideoGenre>() ; } }

        private VideoFeedViewModel ViewModel
        {
            get { return ViewModelLocator.Current.VideoFeedViewModel; }
        }

        public VideoFeedPage()
        {
            this.InitializeComponent();
            InitData();
        }

        private async void InitData()
        {
            if (ViewModel.VideoFeed == null) await ViewModel.LoadDataAsync();
            InitGrid();
        }

        private void InitGrid()
        {
            for(int i = 0; i < Categories.Count(); i++)
            {
                    var videos = ViewModel.VideoFeed.Movies.Where(e => e.VideoGenre == Categories.ElementAt(i)).ToList();
                    RootGrid.RowDefinitions.Add(new RowDefinition() { Height = GridLength.Auto});
                    foreach(var video in videos)
                {
                    VideoCategoryControl control = new VideoCategoryControl()
                    {
                        DataContext = new MultimediaOverviewViewModel()
                        {
                            ViewModels = ViewModel.VideoFeed.GetByCategory(Categories.ElementAt(i)).Select(e => new MultimediaViewModel(e)).ToList(),
                            Category = Categories.ElementAt(i).ToString()
                        }
                    };
                    RootGrid.Children.Add(control);
                    Grid.SetRow(control, i);
                };    
            }
        }
    }
}
