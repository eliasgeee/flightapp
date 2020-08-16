using System;

using FlightAppEliasGryp.ViewModels;
using FlightAppEliasGryp.Views.Flight;
using Windows.UI.Xaml.Controls;

namespace FlightAppEliasGryp.Views
{
    public sealed partial class DetailsPage : Page
    {
        private DetailsViewModel ViewModel
        {
            get { return ViewModelLocator.Current.DetailsViewModel; }
        }

        public DetailsPage()
        {
            InitializeComponent();
            LoadDataAsync();
        }

        public async void LoadDataAsync()
        {
            await ViewModel.LoadDataAsync();
            var origin = new LocationCard() { Location = ViewModel.FlightInfo.Flight.FindOrigin };
            RootGrid.Children.Add(origin);
            Grid.SetColumn(origin, 0);
            var destination = new LocationCard() { Location = ViewModel.FlightInfo.Flight.FindDestination };
            RootGrid.Children.Add(destination);
            Grid.SetColumn(destination, 1);
        }
    }
}
