using FlightAppEliasGryp.Helpers;
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

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace FlightAppEliasGryp.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class OrdersManagementPage : Page
    {
        private OrderManagementViewModel ViewModel
        {
            get { return ViewModelLocator.Current.OrderManagementViewModel; }
        }

        private IEnumerable<OrderStatus> OrderStatuses
        {
            get { return EnumHelper.GetValues<OrderStatus>(); }
        }

        public OrdersManagementPage()
        {
            this.InitializeComponent();
            OrderDetailsPanel.Visibility = Visibility.Collapsed;
        }

        private void OrderItems_ItemClick(object sender, ItemClickEventArgs e)
        {
            var item = e.ClickedItem as Order;
            ViewModel.SelectedItem = item;
            OrderDetailsPanel.Visibility = Visibility.Visible;
        }
    }
}
