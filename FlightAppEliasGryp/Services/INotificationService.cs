
using FlightAppEliasGryp.Models;
using Microsoft.AspNetCore.SignalR.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightAppEliasGryp.Services
{
    public interface INotificationService
    {
        HubConnection Connection();
        Task InitConnection();
        Task SendPassengerNotification(IList<Passenger> receivers, string text);
        Task CheckoutOrder(PaymentType paymentType);
    }
}
