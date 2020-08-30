using FlightAppEliasGryp.Models;
using FlightAppEliasGryp.Services;
using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightAppEliasGryp.ViewModels
{
    public class FlightDetailViewModel : ViewModelBase
    {
        private readonly IFlightService _flightService;

        private FlightInfo _flightInfo;
        public FlightInfo FlightInfo { get { return _flightInfo; } set { Set("FlightInfo", ref _flightInfo, value); } }

        public FlightDetailViewModel(IFlightService flightService)
        {
            _flightService = flightService;
        }

        public async void LoadDataAsync()
        {
            var data = await _flightService.GetInfoCurrentFlight();
            if (data != null) FlightInfo = data;
        }
    }
}
