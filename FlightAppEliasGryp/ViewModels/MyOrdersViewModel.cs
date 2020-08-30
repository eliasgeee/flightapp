using FlightAppEliasGryp.Models;
using FlightAppEliasGryp.Services;
using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Media.Animation;

namespace FlightAppEliasGryp.ViewModels
{
    public class MyOrdersViewModel : ViewModelBase
    {
        public ICollection<Order> MyOrders { get; set; }
        private IOrderDataService _orderDataService { get; set; }
        public NavigationServiceEx NavigationService => ViewModelLocator.Current.NavigationService;

        private Order _selectedOrder;
        public Order SelectedOrder { get { return _selectedOrder; } set { Set("SelectedOrder", ref _selectedOrder, value); } }

        public MyOrdersViewModel(IOrderDataService orderDataService)
        {
            _orderDataService = orderDataService;
            MyOrders = new ObservableCollection<Order>();
        }

        public async Task LoadDataAsync()
        {
            MyOrders = new ObservableCollection<Order>();
            MyOrders.Clear();
            var data = await _orderDataService.GetPassengerOrders();
            foreach (var item in data)
            {
                MyOrders.Add(item);
            }
        }

        public string GetMyOrdersCount()
        {
            return $"My Orders ({MyOrders.Count})";
        }

        internal void ViewOrderDetails(Order order)
        {
            NavigationService.Navigate("FlightAppEliasGryp.ViewModels.OrderDetailsViewModel", order, new DrillInNavigationTransitionInfo());
        }
    }
}
