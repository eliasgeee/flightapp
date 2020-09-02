using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Globalization.DateTimeFormatting;

namespace FlightAppEliasGryp.Models
{
    public class Order : ObservableObject
    {
        private int _id;
        public int Id { get { return _id; } set { Set("Id", ref _id, value); } }

        public ObservableCollection<OrderProduct> OrderItems { get; set; }

        private DateTime _time;
        public DateTime Time { get { return _time; } set { Set("Time", ref _time, value); } }

        private decimal _orderTotal;
        public decimal OrderTotal { get { return _orderTotal; } set { Set("OrderTotal", ref _orderTotal, value); } }

        private OrderStatus _orderStatus;
        public OrderStatus OrderStatus { get { return _orderStatus; } set { Set("OrderStatus", ref _orderStatus, value); } }

        private PaymentType _paymentType;
        public PaymentType PaymentType { get { return _paymentType; } set { Set("PaymentType", ref _paymentType, value); } }

        private Passenger _passenger;
        public Passenger Passenger { get { return _passenger; } set { Set("Passenger", ref _passenger, value); } }

        private bool _isPaid;
        public bool IsPaid { get { return _isPaid; } set { Set("IsPaid", ref _isPaid, value); } }

        public Order()
        {
            OrderItems = new ObservableCollection<OrderProduct>();
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
            return $"Order #{Id}";
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
