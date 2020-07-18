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
        private readonly string baseUri = "https://localhost:44332/api/Order/";

        public async Task<Order> Checkout(PaymentType paymentType)
        {
            using (var httpClientHandler = new HttpClientHandler())
            {
                httpClientHandler.ServerCertificateCustomValidationCallback = (message, cert, chain, errors) => { return true; };
                using (var client = new HttpClient(httpClientHandler))
                {
                    var reqUri = baseUri + "Checkout/" + paymentType;
                    var json = await client.PostAsync(new Uri(reqUri), new StringContent("", System.Text.Encoding.UTF8, "application/json"));
                    return null;
                }
            }
        }

        public async Task<IList<Order>> GetPassengerOrders()
        {
            using (var httpClientHandler = new HttpClientHandler())
            {
                httpClientHandler.ServerCertificateCustomValidationCallback = (message, cert, chain, errors) => { return true; };
                using (var client = new HttpClient(httpClientHandler))
                {
                    var reqUri = baseUri + "Passenger/";
                    var json = await client.GetStringAsync(new Uri(reqUri));
                    return JsonConvert.DeserializeObject<List<Order>>(json); ;
                }
            }
        }

        public async Task<IList<Order>> GetUncompletedOrders()
        {
            using (var httpClientHandler = new HttpClientHandler())
            {
                httpClientHandler.ServerCertificateCustomValidationCallback = (message, cert, chain, errors) => { return true; };
                using (var client = new HttpClient(httpClientHandler))
                {
                    var reqUri = baseUri + "UncompletedOrders/";
                    var json = await client.GetStringAsync(new Uri(reqUri));
                    return JsonConvert.DeserializeObject<List<Order>>(json); ;
                }
            }
        }

        public async Task<int> GetUncompletedOrdersCount()
        {
            using (var httpClientHandler = new HttpClientHandler())
            {
                httpClientHandler.ServerCertificateCustomValidationCallback = (message, cert, chain, errors) => { return true; };
                using (var client = new HttpClient(httpClientHandler))
                {
                    var reqUri = baseUri + "UncompletedOrdersCount/";
                    var json = await client.GetStringAsync(new Uri(reqUri));
                    return JsonConvert.DeserializeObject<int>(json); ;
                }
            }
        }
    }
}
