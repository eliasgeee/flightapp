using FlightAppEliasGryp.Models;
using FlightAppEliasGryp.Services;
using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Devices.Geolocation;

namespace FlightAppEliasGryp.ViewModels
{
    public class LiveFlightDataViewModel: ViewModelBase
    {
        private ILocationService _locationService { get; set; }

        public LiveFlightDataViewModel (ILocationService locationService)
        {
            _locationService = locationService;
        }

        public async Task<object> GetCurrentLocationPlane()
        {
            var data = await _locationService.GetCurrentLocationPlane();
            return data;
        }
    }
}
