using System;

using FlightAppEliasGryp.ViewModels;

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
        }
    }
}
