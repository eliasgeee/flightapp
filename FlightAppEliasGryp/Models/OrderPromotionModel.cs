using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightAppEliasGryp.Models
{
    public class OrderPromotionModel
    {
        public int Id { get; set; }
        public decimal ReducedAmount { get; set; }
        public decimal Amount { get; set; }
        public string ProductName { get; set; }
        public string DiscountType { get; set; }
        public int PromotionId { get; set; }

        public override string ToString()
        {
            if (DiscountType == "PERCENTAGE")
                return "Discount of " + Amount + "%";
            if (DiscountType == "QUANTITY")
                return "Discount of " + Amount + "items";
            if (DiscountType == "FIXEDPRICE")
                return "Discount of " + Amount + "$";
            return "";
        }

        public string GetFormattedReducedAmount()
        {
            return "-" + ReducedAmount;
        }
    }
}
