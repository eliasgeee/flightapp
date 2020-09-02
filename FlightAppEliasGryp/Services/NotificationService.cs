using FlightAppEliasGryp.Models;
using FlightAppEliasGryp.Models.DTO_s;
using Microsoft.AspNetCore.SignalR.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightAppEliasGryp.Services
{
    public class NotificationService : INotificationService
    {
        private readonly IAuthenticationService _authenticationService;
        private HubConnection _connection;
        public HubConnection Connection() { return _connection; }

        public NotificationService(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }

        public async Task InitConnection()
        {
            var user = await _authenticationService.GetTokenCurrentUser();
            if(user != null)
            _connection = new HubConnectionBuilder()
                .WithAutomaticReconnect()
            .WithUrl("https://localhost:44332/notifications", options =>
            {
                options.AccessTokenProvider = () => Task.FromResult(user.Token);
            })
            .Build();

            await _connection.StartAsync();
        }

        public async Task CheckoutOrder(PaymentType paymentType)
        {
            await _connection.InvokeAsync("CheckoutOrder", paymentType);
        }

        public async Task SendPassengerNotification(IList<Passenger> receivers, string text)
        {
            await _connection.InvokeAsync("SendPassengerNotification",
             new AddPassengerNotificationDTO() { Receivers = receivers, Text = text });
        }

        public async Task SendPromotionNotification(Product product, Promotion promotion)
        {
            await _connection.InvokeAsync("SendPromotionNotification", new AddPromotionNotificationDTO()
            {
                ProductDTO = product,
                Promotion = promotion
            });
        }
    }
}
