using FlightAppEliasGryp.Models;
using FlightAppEliasGryp.Services;
using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightAppEliasGryp.ViewModels
{
    public class OrderManagementViewModel : ViewModelBase
    {
        public ICollection<Order> UncompletedOrders { get; set; }
        public Order SelectedItem { get; set; }

        private IOrderDataService _orderDataService { get; set; }
        public NavigationServiceEx NavigationService => ViewModelLocator.Current.NavigationService;

        public OrderManagementViewModel(IOrderDataService orderDataService)
        {
            _orderDataService = orderDataService;
            UncompletedOrders = new ObservableCollection<Order>();

            LoadDataAsync();
        }

        public async void LoadDataAsync()
        {
            UncompletedOrders.Clear();
            var data = await _orderDataService.GetUncompletedOrders();
            foreach (var item in data)
            {
                UncompletedOrders.Add(item);
            }
        }
    }
}
