using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using FlightAppEliasGryp.Models;
using Newtonsoft.Json;

namespace FlightAppEliasGryp.Services
{
    public class OrderDataService : IOrderDataService
    {
        private readonly string baseUri = "Order/";
        private HttpClientService _clientService;
        private DataService<Order> _dataService;
        private DataService<int> _countDataService;

        public OrderDataService(HttpClientService clientService)
        {
            _clientService = clientService;
            _dataService = new DataService<Order>(_clientService);
            _countDataService = new DataService<int>(_clientService);
        }

        public async Task<Order> ChangeOrderStatus(Order order, OrderStatus newStatus)
        {
            var request = await _dataService.MakeRequest(new ApiRequest(ApiRequestType.PUT)
            {
                Uri = baseUri + order.Id + "/" + newStatus,
                Body = newStatus
            });
            return request.AsSingle();
        }

        public async Task<Order> Checkout(PaymentType paymentType)
        {
            var request = await _dataService.MakeRequest(new ApiRequest(ApiRequestType.POST)
            {
                Uri = baseUri + "Checkout/" + paymentType
            });
            return request.AsSingle();
        }

        public async Task<IList<Order>> GetPassengerOrders()
        {
            var request = await _dataService.MakeRequest(new ApiRequest(ApiRequestType.GET)
            {
                Uri = baseUri + "Passenger/"
            });
            return request.AsList().ToList();
        }

        public async Task<IList<Order>> GetUncompletedOrders()
        {
            var request = await _dataService.MakeRequest(new ApiRequest(ApiRequestType.GET)
            {
                Uri =  baseUri + "UncompletedOrders/"
            });
            return request.AsList().ToList();
        }

        public async Task<int> GetUncompletedOrdersCount()
        {
            var request = await _countDataService.MakeRequest(new ApiRequest(ApiRequestType.GET)
            {
                Uri = baseUri + "UncompletedOrdersCount/"
            });
            return request.AsSingle();
        }
    }
}
