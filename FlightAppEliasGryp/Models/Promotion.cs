using FlightAppEliasGryp.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightAppEliasGryp.Models
{
    public class Promotion
    {
        public int RequiredAmount { get; set; }
        public decimal DiscountAmount { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public PromotionType Type { get; set; }
        public decimal ReducedAmount { get; set; }
        public bool IsActive { get; set; }

        public Promotion() { }

        //TODO NAAR MODEL BRENGEN
        public IEnumerable<PromotionType> PromotionTypes
        {
            get { return EnumHelper.GetValues<PromotionType>(); }
        }

        public IEnumerable<string> Hours
        {
            get { return TimeHelper.GetHours();  }
        }

        public IEnumerable<string> Minutes
        {
            get { return TimeHelper.GetMinutes();  }
        }

        public override string ToString()
        {
            if (Type == PromotionType.PERCENTAGE)
                return "Discount of " + DiscountAmount + "%";
            if (Type == PromotionType.QUANTITY)
                return "Discount of " + DiscountAmount + "items";
            if (Type == PromotionType.FIXED_PRICE)
                return "Discount of " + DiscountAmount + "$";
            return "";
        }

        public string GetPeriod()
        {
            return Start + " - " + End;
        }
    }

    public enum PromotionType
    {
        FIXED_PRICE, PERCENTAGE, QUANTITY
    }
}
