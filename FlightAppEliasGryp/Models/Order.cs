using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightAppEliasGryp.Models
{
    public class Order
    {
        public int Id { get; set; }
        public List<OrderProduct> OrderItems { get; set; }
        public DateTime Time { get; set; }
        public decimal OrderTotal { get; set; }
        public OrderStatus OrderStatus { get; set; }
        public PaymentType PaymentType { get; set; }
        public Passenger Passenger { get; set; }
        public bool IsPaid { get; set; }

        public Order()
        {
            OrderItems = new List<OrderProduct>();
            Time = DateTime.Now;
            OrderStatus = OrderStatus.NEW;
        }
    }

    public enum OrderStatus
    {
        NEW, PENDING, COMPLETED
    }
}
