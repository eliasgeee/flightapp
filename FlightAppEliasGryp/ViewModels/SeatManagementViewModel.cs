using FlightAppEliasGryp.Helpers;
using FlightAppEliasGryp.Models;
using FlightAppEliasGryp.Services;
using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightAppEliasGryp.ViewModels
{
    public class SeatManagementViewModel : ViewModelBase
    {
        public NavigationServiceEx NavigationService => ViewModelLocator.Current.NavigationService;
        private IFlightService _flightService { get; set; }
        public ICollection<Seat> Seats { get; set; }
        public List<char> Chairs { get; set; }
        public List<int> Rows { get; set; }

        public SeatManagementViewModel(IFlightService flightService)
        {
            _flightService = flightService;
            Seats = new ObservableCollection<Seat>();
        }

        public async Task LoadDataAsync()
        {
            Seats.Clear();
            var data = await _flightService.GetSeatsAsync();
            foreach (var item in data)
            {
                Seats.Add(item);
            }
            Chairs = SeatHelper.GetChairs(GetAmountOfChairs());
            Rows = SeatHelper.GetRows(GetAmountOfRows());
        }

        public int GetAmountOfChairs() { return Seats.GroupBy(t => t.Chair).Count(); }
        public int GetAmountOfRows() { return Seats.GroupBy(t => t.Row).Count(); }

        public async void SwitchSeats(Seat seat1, Seat seat2) { await _flightService.SwitchSeatsAsync(seat1, seat2); }
    }
}
