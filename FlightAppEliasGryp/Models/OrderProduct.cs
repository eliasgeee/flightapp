using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightAppEliasGryp.Models
{
    public class OrderProduct : Product
    {
        public int Amount { get; set; }
        public List<Promotion> AppliedPromotions { get; set; }

        public OrderProduct() : base()
        {
        }

        public OrderProduct(int amount, List<Promotion> appliedPromotions, string name, string img, decimal price, ProductType type) : base(name, img, price, type)
        {
            Amount = amount;
            AppliedPromotions = appliedPromotions;
        }

        public decimal GetReducedPriceAfterDiscounts()
        {
            decimal total = 0M;

            return total;
        }
    }
}
