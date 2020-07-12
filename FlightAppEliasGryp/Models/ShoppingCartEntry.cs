using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightAppEliasGryp.Models
{
    public class ShoppingCartEntry
    {
        public Product Product { get; set; }
        public int Quantity { get; set; }
        public List<Promotion> Promotions { get; set; }
        public decimal TotalCost { get; set; }
        public decimal PriceBeforePromotions { get; set; }

        public ShoppingCartEntry()
        {
            Promotions = new List<Promotion>();
        }
    }
}
