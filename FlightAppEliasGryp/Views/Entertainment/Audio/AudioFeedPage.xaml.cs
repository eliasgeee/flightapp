using FlightAppEliasGryp.ViewModels;
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

namespace FlightAppEliasGryp.Views.Entertainment.Audio
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class AudioFeedPage : Page
    {
        private AudioFeedViewModel ViewModel
        {
            get { return ViewModelLocator.Current.AudioFeedViewModel; }
        }

        public AudioFeedPage()
        {
            this.InitializeComponent();
            ViewModel.LoadDataAsync();
        }

        private void AlbumsGrid_ItemClick(object sender, ItemClickEventArgs e)
        {
            
        }

        private void TracksGrid_ItemClick(object sender, ItemClickEventArgs e)
        {

        }

        private void ArtistsGrid_ItemClick(object sender, ItemClickEventArgs e)
        {

        }
    }
}
