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

namespace FlightAppEliasGryp.ViewModels
{
    public class CrewDashboardViewModel : ViewModelBase
    {
        private readonly INotificationService _notificationService;
        private readonly IFlightService _flightService;

        public ObservableCollection<SelectedSeatViewModel> Seats { get; set; }

        private string _message;
        public string Message { get { return _message; } set { Set("Message", ref _message, value); } }

        public ICommand SendNewNotificationCommand => new RelayCommand(SendNewNotification);

        public CrewDashboardViewModel(INotificationService notificationService, IFlightService flightService)
        {
            _notificationService = notificationService;
            _flightService = flightService;
            Seats = new ObservableCollection<SelectedSeatViewModel>();
        }

        public async void LoadDataAsync()
        {
            Seats.Clear();
            var data = await _flightService.GetSeatsAsync();

            foreach(var seat in data)
            {
                if(seat.Passenger != null)
                Seats.Add(new SelectedSeatViewModel() { Seat = seat });
            }
        }

        private async void SendNewNotification()
        {
            var passengers = Seats.Where(e => e.IsSelected).Select(e => e.Seat.Passenger).ToList();
            if (_notificationService.Connection() == null) await _notificationService.InitConnection();
            await _notificationService.SendPassengerNotification(passengers, Message);
        }
    }
}
