using FlightAppEliasGryp.Models;
using Microsoft.Toolkit.Uwp.Helpers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Core;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Animation;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace FlightAppEliasGryp.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class OrderDetailPage : Page
    {
        private PrintHelper _printHelper;
        private FrameworkElement panelToPrint;

        public Order SelectedOrder { get; set; }

        public OrderDetailPage()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            SelectedOrder = e.Parameter as Order;

            ReplaceLastBackStackEntryParameter(e.Parameter);

            SystemNavigationManager systemNavigationManager = SystemNavigationManager.GetForCurrentView();
            systemNavigationManager.BackRequested += DetailPage_BackRequested;
            systemNavigationManager.AppViewBackButtonVisibility = AppViewBackButtonVisibility.Visible;
        }

        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            base.OnNavigatedFrom(e);

            SystemNavigationManager systemNavigationManager = SystemNavigationManager.GetForCurrentView();
            systemNavigationManager.BackRequested -= DetailPage_BackRequested;
            systemNavigationManager.AppViewBackButtonVisibility = AppViewBackButtonVisibility.Collapsed;
        }

        private void OnBackRequested()
        {
            ReplaceLastBackStackEntryParameter(null);
            Frame.GoBack(new DrillInNavigationTransitionInfo());
        }

        void ReplaceLastBackStackEntryParameter(object parameter)
        {
            var backStack = Frame.BackStack;
            var backStackCount = backStack.Count;

            if (backStackCount > 0)
            {
                var entry = backStack[backStackCount - 1];
                backStack[backStackCount - 1] = new PageStackEntry(
                    entry.SourcePageType, parameter, entry.NavigationTransitionInfo);
            }
        }

        void NavigateBackForWideState(bool useTransition)
        {
            NavigationCacheMode = NavigationCacheMode.Disabled;

            if (useTransition)
            {
                Frame.GoBack(new EntranceNavigationTransitionInfo());
            }
            else
            {
                Frame.GoBack(new SuppressNavigationTransitionInfo());
            }
        }

        private bool ShouldGoToWideState()
        {
            return Window.Current.Bounds.Width >= 720;
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            if (ShouldGoToWideState())
            {
                NavigateBackForWideState(useTransition: true);
            }
            else
            {
                FindName("RootPanel");
            }

            Window.Current.SizeChanged += Window_SizeChanged;
        }

        private void Page_Unloaded(object sender, RoutedEventArgs e)
        {
            Window.Current.SizeChanged -= Window_SizeChanged;
        }

        private void Window_SizeChanged(object sender, Windows.UI.Core.WindowSizeChangedEventArgs e)
        {
            if (ShouldGoToWideState())
            {
                Window.Current.SizeChanged -= Window_SizeChanged;

                NavigateBackForWideState(useTransition: false);
            }
        }

        private void DetailPage_BackRequested(object sender, BackRequestedEventArgs e)
        {
            e.Handled = true;

            OnBackRequested();
        }

        private async void PrintButton_Click(object sender, RoutedEventArgs e)
        {
            _printHelper = new PrintHelper(Container);
            panelToPrint = RootPanel;
            Container.Children.Remove(panelToPrint);

            _printHelper.AddFrameworkElementToPrint(panelToPrint);

            var printHelperOptions = new PrintHelperOptions(false);
            printHelperOptions.Orientation = Windows.Graphics.Printing.PrintOrientation.Portrait;

            _printHelper.OnPrintCanceled += PrintHelper_OnPrintCanceled;
            _printHelper.OnPrintFailed += PrintHelper_OnPrintFailed;
            _printHelper.OnPrintSucceeded += PrintHelper_OnPrintSucceeded;

            await _printHelper.ShowPrintUIAsync("Print order", printHelperOptions);
        }

        private async void PrintHelper_OnPrintSucceeded()
        {
            ReleasePrintHelper();
            var dialog = new MessageDialog("Printing done.");
            await dialog.ShowAsync();
        }

        private async void PrintHelper_OnPrintFailed()
        {
            ReleasePrintHelper();
            var dialog = new MessageDialog("Printing failed.");
            await dialog.ShowAsync();
        }

        private void PrintHelper_OnPrintCanceled()
        {
            ReleasePrintHelper();
        }

        private void ReleasePrintHelper()
        {
            _printHelper.Dispose();

            if (!Container.Children.Contains(panelToPrint))
            {
                Container.Children.Add(panelToPrint);
            }
        }
    }
}
