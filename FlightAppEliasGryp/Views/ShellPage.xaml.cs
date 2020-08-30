using System;
using FlightAppEliasGryp.Models;
using FlightAppEliasGryp.Services;
using FlightAppEliasGryp.ViewModels;
using Microsoft.AspNetCore.SignalR.Client;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;

namespace FlightAppEliasGryp.Views
{
    // TODO WTS: Change the icons and titles for all NavigationViewItems in ShellPage.xaml.
    public sealed partial class ShellPage : Page
    {
        public ChatMessage Message;

        private ShellViewModel ViewModel
        {
            get { return ViewModelLocator.Current.ShellViewModel; }
        }

        private ConversationsViewModel ConvoViewModel
        {
            get { return ViewModelLocator.Current.ConversationsViewModel; }
        }

        public NavigationServiceEx NavigationService { get { return ViewModelLocator.Current.NavigationService; } }

        private ConversationsViewModel ConversationsViewModel
        {
            get { return ViewModelLocator.Current.ConversationsViewModel; }
        }

        public ShellPage()
        {
            InitializeComponent();
            DataContext = ViewModel;
            ViewModel.Initialize(shellFrame, navigationView, KeyboardAccelerators);
            LoadChatSignalRAsync();
            LoadSignalRNotifications();
        }

        private async void LoadSignalRNotifications()
        {
            try
            {
                if (ViewModel.NotificationService.Connection() == null) await ViewModel.NotificationService.InitConnection();
                ViewModel.ConversationService.Connection().On<string>("NewPromotionNotification", async (msg) => {
                    Notification.DataContext = msg;
                    Notification.Show();
                });
            }
            catch(Exception e) { }
        }

        private async void LoadChatSignalRAsync()
        {
            try
            {
                if (ViewModel.ConversationService.Connection() == null) await ViewModel.ConversationService.InitConnection();
                ViewModel.ConversationService.Connection().On<ChatMessage>("ReceiveMessage", async (chat) =>
                {
                    Message = chat;
                    Notification.DataContext = Message;
                    await ConversationsViewModel.LoadDataAsync();
                    Txt.Tapped += NavigateToConversation;
                    Notification.Show();
                });
            }
            catch(Exception e) { }
        }

        private void NavigateToConversation(object sender, TappedRoutedEventArgs e)
        {
            //var convo = ConvoViewModel.GetConvo(Message.ConvoId);
            //Notification.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
            //NavigationService.Navigate(typeof(ConversationsViewModel).FullName, convo);
        }

        private void Button_Tapped(object sender, TappedRoutedEventArgs e)
        {
            ViewModel.OnLogoutClicked();
        }
    }
}
