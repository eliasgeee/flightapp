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
using Windows.UI.Xaml.Media.Animation;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace FlightAppEliasGryp.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MyOrdersPage : Page
    {
        private Order _lastSelectedItem;

        public MyOrdersPage()
        {
            this.InitializeComponent();
            ViewModel.LoadDataAsync();
        }

        private MyOrdersViewModel ViewModel
        {
            get { return ViewModelLocator.Current.MyOrdersViewModel; }
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            if (e.Parameter != null)
            {
                var order = (Order)e.Parameter;
                _lastSelectedItem =
                    ViewModel.MyOrders.Where((item) => item.Id == order.Id).FirstOrDefault();
            }
            else
            {
                _lastSelectedItem = null;
            }

            UpdateForVisualState(AdaptiveStates.CurrentState);

            DisableContentTransitions();
        }

            private void LayoutRoot_Loaded(object sender, RoutedEventArgs e)
        {
            OrdersOverViewListView.SelectedItem = _lastSelectedItem;
        }

        private void OrdersOverViewListView_ItemClick(object sender, ItemClickEventArgs e)
        {
            var clickedItem = (Order)e.ClickedItem;
            _lastSelectedItem = clickedItem;

            if (AdaptiveStates.CurrentState == NarrowState)
            {
                ViewModel.ViewOrderDetails(clickedItem);              
            }
            else
            {
                EnableContentTransitions();
            }
        }

        private void AdaptiveStates_CurrentStateChanged(object sender, VisualStateChangedEventArgs e)
        {
            UpdateForVisualState(e.NewState, e.OldState);
        }

        private void UpdateForVisualState(VisualState newState, VisualState oldState = null)
        {
            var isNarrow = newState == NarrowState;

            if (isNarrow && oldState == DefaultState && _lastSelectedItem != null)
            {
                Frame.Navigate(typeof(OrderDetailPage), _lastSelectedItem, new SuppressNavigationTransitionInfo());
            }

            EntranceNavigationTransitionInfo.SetIsTargetElement(OrdersOverViewListView, isNarrow);
            if (DetailContentPresenter != null)
            {
                EntranceNavigationTransitionInfo.SetIsTargetElement(DetailContentPresenter, !isNarrow);
            }
        }

        private void EnableContentTransitions()
        {
            DetailContentPresenter.ContentTransitions.Clear();
            DetailContentPresenter.ContentTransitions.Add(new EntranceThemeTransition());
        }

        private void DisableContentTransitions()
        {
            if (DetailContentPresenter != null)
            {
                DetailContentPresenter.ContentTransitions.Clear();
            }
        }

    }
}
