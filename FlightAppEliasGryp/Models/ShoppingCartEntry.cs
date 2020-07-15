using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightAppEliasGryp.Models
{
    public class ShoppingCartEntry
    {
        public int Id { get; set; }
        public Product Product { get; set; }
        public int Quantity { get; set; }
        public List<Promotion> Promotions { get; set; }
        public decimal ReducedAmount { get; set; }
        public decimal PriceBeforePromotions { get; set; }

        public ShoppingCartEntry()
        {
            Promotions = new List<Promotion>();
        }

        public string GetPriceAfterPromotions()
        {
            if (ReducedAmount != 0)
                return "-" + ReducedAmount;
            else
                return "";
        }

        public string GetTotalCost()
        {
            if (ReducedAmount == 0)
                return PriceBeforePromotions.ToString();
            else
                return "";
        }
    }
}
