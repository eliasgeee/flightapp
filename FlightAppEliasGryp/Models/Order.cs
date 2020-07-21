using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Globalization.DateTimeFormatting;

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

        public string GetIsPaidFormatted()
        {
            if (IsPaid)
                return "Is paid";
            else
                return "Unpaid";
        }

        public string TotalAmountPaid()
        {
            if (IsPaid)
                return OrderTotal.ToString();
            else
                return "0";
        }

        public string GetOrderId()
        {
            return "Order #" + Id;
        }

        public string GetDateAndTimeOrderCreated()
        {
            return Time.ToShortDateString() + " " + DateCreatedHourMinute;
        }

        private string DateCreatedHourMinute
        {
            get
            {
                var formatter = new DateTimeFormatter("hour minute");
                return formatter.Format(Time);
            }
        }

        public string GetOrderQuantity()
        {
            var total = 0;
            for(int i=0; i < OrderItems.Count; i++)
            {
                total += OrderItems.ElementAt(i).Amount;
            }
            return total.ToString();
        }
    }

    public enum OrderStatus
    {
        NEW, PENDING, COMPLETED
    }
}
