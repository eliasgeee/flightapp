using FlightAppEliasGryp.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FlightAppEliasGryp.Services
{
    public interface IOrderDataService
    {
        Task<IList<Order>> GetPassengerOrders();
        Task<IList<Order>> GetUncompletedOrders();
        Task<Order> Checkout(PaymentType paymentType);
        Task<int> GetUncompletedOrdersCount();
    }
}
