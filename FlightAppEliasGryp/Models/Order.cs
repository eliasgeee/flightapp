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
        public bool Completed { get; set; }
        public DateTime Time { get; set; }
        public decimal OrderTotal { get; set; }

        public Order()
        {
            OrderItems = new List<OrderProduct>();
            Time = DateTime.Now;
            Completed = false;
        }
    }
}
