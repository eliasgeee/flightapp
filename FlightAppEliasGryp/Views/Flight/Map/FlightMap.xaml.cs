using FlightAppEliasGryp.Models;
using FlightAppEliasGryp.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Devices.Geolocation;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Maps;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The User Control item template is documented at https://go.microsoft.com/fwlink/?LinkId=234236

namespace FlightAppEliasGryp.Views.Map
{
    public sealed partial class FlightMap : UserControl
    {
        private FlightViewModel ViewModel
        {
            get { return ViewModelLocator.Current.FlightViewModel; }
        }

        public FlightMap()
        {
            this.InitializeComponent();
            InitMap();
        }

        private async void InitMap()
        {
            await ViewModel.LoadDataAsync();

            for (var i = 0; i < ViewModel.Flight.Locations.Count; i++)
            {
                AddMarker(ViewModel.Flight.Locations.ElementAt(i));
            }

            GetCurrentLocation();
            DrawLine();
        }

        private void DrawLine()
        {
            List<BasicGeoposition> geopositions = new List<BasicGeoposition>();
            for (var i = 0; i < ViewModel.Flight.Locations.Count; i++)
            {
                geopositions.Add(new BasicGeoposition()
                {
                    Latitude = ViewModel.Flight.Locations.ElementAt(i).Latitude,
                    Longitude = ViewModel.Flight.Locations.ElementAt(i).Longitude
                });
            }
           
            var mapPolyline = new MapPolyline
            {
                Path = new Geopath(geopositions),
                StrokeColor = Colors.Black,
                StrokeThickness = 3
            };

            var MyLines = new List<MapElement>();

            MyLines.Add(mapPolyline);

            var LinesLayer = new MapElementsLayer
            {
                ZIndex = 1,
                MapElements = MyLines
            };

            Map.Layers.Add(LinesLayer);
        }

        private async void GetCurrentLocation()
        {
           var data = (BasicGeoposition) await ViewModel.GetCurrentLocationPlane();
           var position = new Geopoint(data);
           
           Map.Center = position;
           Map.ZoomLevel = 8;

            var marker = new FlightMarker
            {
                DataContext = ViewModel.Flight
            };

            Map.Children.Add(marker);
            MapControl.SetLocation(marker, position);
            MapControl.SetNormalizedAnchorPoint(marker, new Point(0.5, 0.5));
        }

        private void AddMarker(Location location)
        {
            var marker = new LocationMarker
            {
                DataContext = location
            };

            var geopoint = new Geopoint(new BasicGeoposition()
            {
                Latitude = location.Latitude,
                Longitude = location.Longitude
            });

            Map.Children.Add(marker);
            MapControl.SetLocation(marker, geopoint);
            MapControl.SetNormalizedAnchorPoint(marker, new Point(0.5, 0.5));
        }
    }
}
