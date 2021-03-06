﻿using System;
using GalaSoft.MvvmLight;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlightAppEliasGryp.Models;
using FlightAppEliasGryp.Services;
using Windows.Devices.Geolocation;

namespace FlightAppEliasGryp.ViewModels
{
    public class FlightViewModel : ViewModelBase
    {
        public Flight Flight { get; set; }
        private IFlightService _flightDataService { get; set; }
        public NavigationServiceEx NavigationService => ViewModelLocator.Current.NavigationService;
        private ILocationService _locationService { get; set; }

        public BasicGeoposition CurrentLocation { get; set; }

        public FlightViewModel(IFlightService flightDataService, ILocationService locationService)
        {
            _flightDataService = flightDataService;
            _locationService = locationService;
        }

        public async Task LoadDataAsync()
        {
            var data = await _flightDataService.GetInfoCurrentFlight();
            Flight = data.Flight;
        }

        public async Task<object> GetCurrentLocationPlane()
        {
            var data = await _locationService.GetCurrentLocationPlane();
            CurrentLocation = data;
            return data;
        }
    }
}
