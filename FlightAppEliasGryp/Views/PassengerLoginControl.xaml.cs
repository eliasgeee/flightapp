using FlightAppEliasGryp.Models;
using FlightAppEliasGryp.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Microsoft.AspNetCore.SignalR.Client;
using Microsoft.Toolkit.Uwp.UI.Controls;

// The User Control item template is documented at https://go.microsoft.com/fwlink/?LinkId=234236

namespace FlightAppEliasGryp.Views
{
    public sealed partial class PassengerLoginControl : UserControl
    {
        private SeatViewModel ViewModel
        {
            get { return ViewModelLocator.Current.SeatViewModel; }
        }

        private ShellViewModel ShellViewModel
        {
            get { return ViewModelLocator.Current.ShellViewModel; }
        }

        private ConversationsViewModel ConversationsViewModel
        {
            get { return ViewModelLocator.Current.ConversationsViewModel; }
        }

        private PassengerLoginViewModel LoginViewModel
        {
            get { return ViewModelLocator.Current.PassengerLogInViewModel; }
        }

        public PassengerLoginControl()
        {
            this.InitializeComponent();
            LoadDataAsync();
        }

        private async void LoadDataAsync()
        {
            await ViewModel.LoadDataAsync();
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            var user = await LoginViewModel.OnLoginClicked(Seatnumber.SelectedItem as Seat);
            LoadChatSignalRAsync();
            LoadSignalRNotifications();
            LoginViewModel.NavigateToDashboard();
        }

        private async void LoadSignalRNotifications()
        {
            try
            {
                if (LoginViewModel.NotificationService.Connection() == null) await LoginViewModel.NotificationService.InitConnection();
                LoginViewModel.NotificationService.Connection().On<string>("NewPromotionNotification", async (msg) => {
                    ShellViewModel.Grid.Content = msg;
                    ShellViewModel.Grid.Show();
                });
                LoginViewModel.NotificationService.Connection().On<ChatMessage>("NewPassengerNotification", async (msg) => {
                    ShellViewModel.Grid.Content = msg.Text;
                    ShellViewModel.Grid.Show();
                });
            }
            catch (Exception e) { }
        }

        private async void LoadChatSignalRAsync()
        {
            try
            {
                if (LoginViewModel.ConversationService.Connection() == null) await LoginViewModel.ConversationService.InitConnection();
                LoginViewModel.ConversationService.Connection().On<ChatMessage>("ReceiveMessage", async (chat) =>
                {
                    ShellViewModel.Grid.Content = chat.ToString();
                    ShellViewModel.Grid.Show();
                    await ConversationsViewModel.LoadDataAsync();
                });
            }
            catch (Exception e) { }
        }
    }
}
