using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;

using FlightAppEliasGryp.Helpers;
using FlightAppEliasGryp.Models;
using FlightAppEliasGryp.Services;

using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Microsoft.Toolkit.Uwp.UI.Controls;
using Windows.System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Navigation;

using WinUI = Microsoft.UI.Xaml.Controls;

namespace FlightAppEliasGryp.ViewModels
{
    public class ShellViewModel : ViewModelBase
    {
        private const string cantGoBackParameter = "navigatedFromLogIn";

        private readonly KeyboardAccelerator _altLeftKeyboardAccelerator = BuildKeyboardAccelerator(VirtualKey.Left, VirtualKeyModifiers.Menu);
        private readonly KeyboardAccelerator _backKeyboardAccelerator = BuildKeyboardAccelerator(VirtualKey.GoBack);
        private readonly IAuthenticationService _authenticationService;

        public InAppNotification Grid { get; set; }

        private bool _isBackEnabled;
        private bool _isNavigationVisible;
        private IList<KeyboardAccelerator> _keyboardAccelerators;
        private WinUI.NavigationView _navigationView;
        private WinUI.NavigationViewItem _selected;
        private ICommand _loadedCommand;
        private ICommand _itemInvokedCommand;
        private ICommand _logoutClickedCommand;

        private CurrentUser _currentUser;

        public IConversationService ConversationService { get; }
        public INotificationService NotificationService { get; }

        public bool IsNavigationVisible
        {
            get { return _isNavigationVisible; }
            set {
                Set(ref _isNavigationVisible, value);
            }
        }

        public bool IsBackEnabled
        {
            get { return _isBackEnabled; }
            set { Set(ref _isBackEnabled, value); }
        }

        public CurrentUser CurrentUser
        {
            get { return _currentUser; }
            set { Set(ref _currentUser, value); }
        }

        public static NavigationServiceEx NavigationService => ViewModelLocator.Current.NavigationService;

        public WinUI.NavigationViewItem Selected
        {
            get { return _selected; }
            set { Set(ref _selected, value); }
        }

        public ICommand LoadedCommand => _loadedCommand ?? (_loadedCommand = new RelayCommand(OnLoaded));

        public ICommand ItemInvokedCommand => _itemInvokedCommand ?? (_itemInvokedCommand = new RelayCommand<WinUI.NavigationViewItemInvokedEventArgs>(OnItemInvoked));

        public ICommand Logout => _logoutClickedCommand ?? ( _logoutClickedCommand = new RelayCommand(OnLogoutClicked) );

        public ShellViewModel(IAuthenticationService authenticationService, IConversationService conversationService, INotificationService notificationService)
        {
            _authenticationService = authenticationService;
            ConversationService = conversationService;
            NotificationService = notificationService;
        }

        public async void Initialize(Frame frame, WinUI.NavigationView navigationView, IList<KeyboardAccelerator> keyboardAccelerators)
        {
            _navigationView = navigationView;
            _keyboardAccelerators = keyboardAccelerators;
            NavigationService.Frame = frame;
            NavigationService.NavigationFailed += Frame_NavigationFailed;
            NavigationService.Navigated += Frame_Navigated;
            _navigationView.BackRequested += OnBackRequested;
            var user = await _authenticationService.GetTokenCurrentUser();
            if (user != null)
            {
                CurrentUser = user;
                if (user.IsPassenger)
                {
                    await _authenticationService.PassengerLogIn(user.Row, user.Chair);
                    NavigationService.NavigateAndClearBackstack(typeof(FlightViewModel).FullName);
                }
                if (user.IsCrewMember)
                {
                    await _authenticationService.CrewMemberLogIn(user.UserName, user.Password);
                    NavigationService.NavigateAndClearBackstack(typeof(CrewDashboardViewModel).FullName);
                }
            }
        }

        public async void OnLogoutClicked()
        {
            var result = await ShowLogoutComfirmationDialog();

            if (result == ContentDialogResult.Primary)
            {
                await _authenticationService.LogOut();
                NavigationService.NavigateAndClearBackstack("FlightAppEliasGryp.ViewModels.MainPageViewModel");
            }
        }

        private async Task<ContentDialogResult> ShowLogoutComfirmationDialog()
        {
            ContentDialog dialog = new ContentDialog()
            {
                Title = "Log out",
                Content = "Are you sure you want to log out?",
                PrimaryButtonText = "Yes",
                CloseButtonText = "Cancel",
                DefaultButton = ContentDialogButton.Close
            };
            ContentDialogResult result = await dialog.ShowAsync();
            return result;
        }

        private async void OnLoaded()
        {
            // Keyboard accelerators are added here to avoid showing 'Alt + left' tooltip on the page.
            // More info on tracking issue https://github.com/Microsoft/microsoft-ui-xaml/issues/8
            _keyboardAccelerators.Add(_altLeftKeyboardAccelerator);
            _keyboardAccelerators.Add(_backKeyboardAccelerator);
            await Task.CompletedTask;
        }

        private void OnItemInvoked(WinUI.NavigationViewItemInvokedEventArgs args)
        {
            if (args.InvokedItem.ToString() == "Logout") OnLogoutClicked();
            else
            {
                var item = _navigationView.MenuItems
                            .OfType<WinUI.NavigationViewItem>()
                            .First(menuItem => (string)menuItem.Content == (string)args.InvokedItem);
                var pageKey = item.GetValue(NavHelper.NavigateToProperty) as string;
                NavigationService.Navigate(pageKey);
            }
        }

        private void OnBackRequested(WinUI.NavigationView sender, WinUI.NavigationViewBackRequestedEventArgs args)
        {
            NavigationService.GoBack();
        }

        private void Frame_NavigationFailed(object sender, NavigationFailedEventArgs e)
        {
            throw e.Exception;
        }

        private async void Frame_Navigated(object sender, NavigationEventArgs e)
        {
            if (e.Parameter as string == cantGoBackParameter)
            {
                IsBackEnabled = false;
                var user = await _authenticationService.GetTokenCurrentUser();
                if (user != null) { CurrentUser = user; }
            }
            else
                IsBackEnabled = NavigationService.CanGoBack;
            Selected = _navigationView.MenuItems
                            .OfType<WinUI.NavigationViewItem>()
                            .FirstOrDefault(menuItem => IsMenuItemForPageType(menuItem, e.SourcePageType));
            if (e.SourcePageType == typeof(Views.MainPage))
                IsNavigationVisible = false;
            else
                IsNavigationVisible = true;
        }

        private bool IsMenuItemForPageType(WinUI.NavigationViewItem menuItem, Type sourcePageType)
        {
            var navigatedPageKey = NavigationService.GetNameOfRegisteredPage(sourcePageType);
            var pageKey = menuItem.GetValue(NavHelper.NavigateToProperty) as string;
            return pageKey == navigatedPageKey;
        }

        private static KeyboardAccelerator BuildKeyboardAccelerator(VirtualKey key, VirtualKeyModifiers? modifiers = null)
        {
            var keyboardAccelerator = new KeyboardAccelerator() { Key = key };
            if (modifiers.HasValue)
            {
                keyboardAccelerator.Modifiers = modifiers.Value;
            }

            keyboardAccelerator.Invoked += OnKeyboardAcceleratorInvoked;
            return keyboardAccelerator;
        }

        private static void OnKeyboardAcceleratorInvoked(KeyboardAccelerator sender, KeyboardAcceleratorInvokedEventArgs args)
        {
            var result = NavigationService.GoBack();
            args.Handled = result;
        }
    }
}
