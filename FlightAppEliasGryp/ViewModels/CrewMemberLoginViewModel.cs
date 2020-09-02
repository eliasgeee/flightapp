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
using Microsoft.AspNetCore.SignalR.Client;

namespace FlightAppEliasGryp.ViewModels
{
    public class CrewMemberLoginViewModel : ViewModelBase
    {
        private ShellViewModel ShellViewModel
        {
            get { return ViewModelLocator.Current.ShellViewModel; }
        }

        private CrewMember _crewMember;
        public CrewMember CrewMember { get { return _crewMember; } set { Set(ref _crewMember, value); } }

        private string _errorMsg = "";
        public string ErrorMsg { get { return _errorMsg; } set { Set(ref _errorMsg, value); } }

        private string _username = "";
        private string _password = "";

        private IAuthenticationService _accountService;
        private NavigationServiceEx NavigationService => ViewModelLocator.Current.NavigationService;

        private ICommand _loginClickedCommand;

        public IConversationService ConversationService;
        public INotificationService NotificationService;

        public CrewMemberLoginViewModel(IAuthenticationService accountService, INotificationService notificationService, IConversationService conversationService)
        {
            _accountService = accountService;
            CrewMember = new CrewMember();
            ConversationService = conversationService;
            NotificationService = notificationService;
            ConversationService = conversationService;
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
                await LoadChatSignalRAsync();
                await LoadSignalRNotifications();
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

        private async Task LoadSignalRNotifications()
        {
            try
            {
                if (NotificationService.Connection() == null) await NotificationService.InitConnection();
                ConversationService.Connection().On<string>("NewPromotionNotification", async (msg) => {
                    ShellViewModel.Grid.Content = msg;
                    ShellViewModel.Grid.Show();
                });

            }
            catch (Exception e) { }
        }

        private async Task LoadChatSignalRAsync()
        {
            try
            {
                if (ConversationService.Connection() == null) await ConversationService.InitConnection();
                ConversationService.Connection().On<ChatMessage>("ReceiveMessage", async (chat) =>
                {
                    ShellViewModel.Grid.Content = chat.ToString();
                    ShellViewModel.Grid.Show();
                });
                if (NotificationService.Connection() == null) await NotificationService.InitConnection();
                NotificationService.Connection().On<string>("NewOrder", async (chat) =>
                {
                    ShellViewModel.Grid.Content = chat;
                    ShellViewModel.Grid.Show();
                });
            }
            catch (Exception e) { }
        }
    }
}
