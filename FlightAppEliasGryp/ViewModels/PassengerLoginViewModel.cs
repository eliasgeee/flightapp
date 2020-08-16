using FlightAppEliasGryp.Models;
using FlightAppEliasGryp.Services;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace FlightAppEliasGryp.ViewModels
{
    public class PassengerLoginViewModel
    {
        private IAuthenticationService _accountService;
        private NavigationServiceEx NavigationService => ViewModelLocator.Current.NavigationService;

        private ICommand _loginClickedCommand;

        public ICommand LoginClickedCommand => _loginClickedCommand ??
            (_loginClickedCommand = new RelayCommand<Seat>(OnLoginClicked));

        public PassengerLoginViewModel(IAuthenticationService accountService)
        {
            _accountService = accountService;
        }

        public async void OnLoginClicked(Seat seat)
        {
            var user = await _accountService.PassengerLogIn(seat.Row, seat.Chair);
            if (user != null)
                NavigationService.NavigateAndClearBackstack("FlightAppEliasGryp.ViewModels.DetailsViewModel");
        } 
    }
}
