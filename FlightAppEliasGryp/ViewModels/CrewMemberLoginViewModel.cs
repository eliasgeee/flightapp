using FlightAppEliasGryp.Models;
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
    public class CrewMemberLoginViewModel : ViewModelBase
    {
        private CrewMember _crewMember;
        public CrewMember CrewMember { get { return _crewMember; } set { Set(ref _crewMember, value); } }

        private string _errorMsg = "";
        public string ErrorMsg { get { return _errorMsg; } set { Set(ref _errorMsg, value); } }

        private string _username = "";
        private string _password = "";

        private IAuthenticationService _accountService;
        private NavigationServiceEx NavigationService => ViewModelLocator.Current.NavigationService;

        private ICommand _loginClickedCommand;

        public CrewMemberLoginViewModel(IAuthenticationService accountService)
        {
            _accountService = accountService;
            CrewMember = new CrewMember();
        }

        public ICommand LoginClickedCommand => _loginClickedCommand ??
            (_loginClickedCommand = new RelayCommand(OnLoginClicked));

        public async void OnLoginClicked()
        {
            try
            {
                CrewMember.UserName = _username;
                CrewMember.Password = _password;
                var user = await _accountService.CrewMemberLogIn(CrewMember.UserName, CrewMember.Password);
                if(user != null)
                    NavigationService.NavigateAndClearBackstack(typeof(CrewDashboardViewModel).FullName);
            }
            catch (ArgumentException ex)
            {
                ErrorMsg = ex.Message;
            }
        }


        public void ValidateLogin(string username, string password)
        {
            _password = password;
            _username = username;
        }
    }
}
