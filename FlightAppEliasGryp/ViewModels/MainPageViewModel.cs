using FlightAppEliasGryp.Services;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace FlightAppEliasGryp.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {
        private IAuthenticationService _accountService;

        public NavigationServiceEx NavigationService => ViewModelLocator.Current.NavigationService;

        //  private ICommand _loginClickedCommand;

        //    public ICommand Logout => _loginClickedCommand ?? (_loginClickedCommand = new RelayCommand(OnLoginClicked));

        public MainPageViewModel(IAuthenticationService accountService)
        {
            _accountService = accountService;
        }

        public async void OnPassengerLoginClicked(int row, char chair)
        {
            var user = await _accountService.PassengerLogIn(row, chair);
            if (user != null) NavigationService.NavigateAndClearBackstack("FlightAppEliasGryp.ViewModels.DetailsViewModel");
        }
    }
}
