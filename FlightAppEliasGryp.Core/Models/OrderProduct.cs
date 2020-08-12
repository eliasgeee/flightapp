using FlightAppEliasGryp.Core.Models.enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FlightAppEliasGryp.Core.Models
{
    public class OrderProduct : Product
    {
        public int Amount { get; set; }
        public List<OrderPromotionModel> AppliedPromotions { get; set; }

        public OrderProduct() : base()
        {
        }

        public OrderProduct(int amount, List<OrderPromotionModel> appliedPromotions, string name, string img, decimal price, ProductType type) : base(name, img, price, type)
        {
            Amount = amount;
            AppliedPromotions = appliedPromotions;
        }

        public string GetReducedPriceAfterDiscounts()
        {
            decimal total = 0M;

            for (int i = 0; i < AppliedPromotions.Count; i++)
            {
                total += AppliedPromotions.ElementAt(i).ReducedAmount;
            }

            return total.ToString();
        }
    }
}
