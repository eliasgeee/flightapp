using System;
using System.Threading.Tasks;
using FlightAppEliasGryp.Models;
using FlightAppEliasGryp.Services;
using GalaSoft.MvvmLight;

namespace FlightAppEliasGryp.ViewModels
{
    public class DetailsViewModel : ViewModelBase
    {
        public NavigationServiceEx NavigationService => ViewModelLocator.Current.NavigationService;
        private readonly IFlightService _flightService;

        private FlightInfo _flightInfo;
        public FlightInfo FlightInfo { get { return _flightInfo; } set { Set(ref _flightInfo, value); } }

        public DetailsViewModel(IFlightService flightService)
        {
            _flightService = flightService;
        }

        public async Task LoadDataAsync()
        {
            var info = await _flightService.GetInfoCurrentFlight();
            FlightInfo = info;
        }
    }
}
