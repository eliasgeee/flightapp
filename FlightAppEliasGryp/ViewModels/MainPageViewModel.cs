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

namespace FlightAppEliasGryp.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {
        private IAuthenticationService _accountService;

        public NavigationServiceEx NavigationService => ViewModelLocator.Current.NavigationService;

        //  private ICommand _loginClickedCommand;

        //    public ICommand Logout => _loginClickedCommand ?? (_loginClickedCommand = new RelayCommand(OnLoginClicked));

        public MainPageViewModel()
        {
        }
    }
}
