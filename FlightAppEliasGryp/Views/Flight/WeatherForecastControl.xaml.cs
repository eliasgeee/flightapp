using FlightAppEliasGryp.Models;
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

// The User Control item template is documented at https://go.microsoft.com/fwlink/?LinkId=234236

namespace FlightAppEliasGryp.Views.Flight
{
    public sealed partial class WeatherForecastControl : UserControl
    {
        private WeatherForecastViewModel ViewModel
        {
            get; set;
        }

        public Location Location
        {
            get { return (Location)GetValue(LocationProperty); }
            set {
                SetValue(LocationProperty, value);
            }
        }

        public static readonly DependencyProperty LocationProperty =
       DependencyProperty.Register("Location", typeof(Location), typeof(WeatherForecast), new PropertyMetadata(null));

        public WeatherForecastControl()
        {
            this.InitializeComponent();
            ViewModel = new WeatherForecastViewModel(ViewModelLocator.Current.WeatherDataService);
        }

        private void Control_Loaded(object sender, RoutedEventArgs e)
        {
            if (Location != null)
                ViewModel.GetCurrentWeatherAsync(Location);
        }

    }
}
