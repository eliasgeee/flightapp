using FlightAppEliasGryp.Helpers;
using FlightAppEliasGryp.Models;
using FlightAppEliasGryp.Services;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Windows.UI.Xaml.Controls;

namespace FlightAppEliasGryp.ViewModels
{
    public class SeatViewModel : ViewModelBase
    {
        private IFlightService _flightService { get; set; }
        public ICollection<Seat> Seats { get; set; }
        public Seat SelectedSeat { get; set; }

        private ICommand _selectedSeat;

        public ICommand SelectedSeatCommand => new RelayCommand<SelectionChangedEventArgs>(SetSelectedSeat);

        public SeatViewModel(IFlightService flightService)
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
        }

        public void SetSelectedSeat(SelectionChangedEventArgs e)
        {
            if (e.AddedItems != null)
                SelectedSeat = e.AddedItems.FirstOrDefault() as Seat;
        }
    }
}
