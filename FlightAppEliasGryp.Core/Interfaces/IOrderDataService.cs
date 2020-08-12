using FlightAppEliasGryp.Core.Models;
using FlightAppEliasGryp.Core.Models.enums;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FlightAppEliasGryp.Core.Interfaces
{
    public interface IOrderDataService
    {
        Task<IList<Order>> GetPassengerOrders();
        Task<IList<Order>> GetUncompletedOrders();
        Task<Order> Checkout(PaymentType paymentType);
        Task<int> GetUncompletedOrdersCount();
        Task<Order> ChangeOrderStatus(Order order, OrderStatus newStatus);
    }
}
