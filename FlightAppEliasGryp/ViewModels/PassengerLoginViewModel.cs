using FlightAppEliasGryp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightAppEliasGryp.ViewModels
{
    public class PassengerLoginViewModel
    {
        private IAuthenticationService _accountService;

        public PassengerLoginViewModel(IAuthenticationService accountService)
        {
            _accountService = accountService;
        }

        public void Login(int row, char chair)
        {
            _accountService.PassengerLogIn(row, chair);
        }
    }
}
