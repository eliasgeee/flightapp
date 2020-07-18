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
    public class MyOrdersViewModel : ViewModelBase
    {
        public ICollection<Order> MyOrders { get; set; }

        private IOrderDataService _orderDataService { get; set; }

        public MyOrdersViewModel(IOrderDataService orderDataService)
        {
            _orderDataService = orderDataService;
            MyOrders = new ObservableCollection<Order>();

            LoadDataAsync();
        }

        public async void LoadDataAsync()
        {
            MyOrders = new ObservableCollection<Order>();
            MyOrders.Clear();
            var data = await _orderDataService.GetPassengerOrders();
            foreach (var item in data)
            {
                MyOrders.Add(item);
            }
        }
    }
}
