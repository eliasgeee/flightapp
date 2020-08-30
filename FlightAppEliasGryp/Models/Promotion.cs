using FlightAppEliasGryp.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightAppEliasGryp.Models
{
    public class Promotion : ICloneable
    {
        public int Id { get; set; }
        public int RequiredAmount { get; set; }
        [Required(ErrorMessage = "Discount amount is required.")]
        public decimal Amount { get; set; }
        [DateGreaterThanValidator]
        public DateTime Start { get; set; }
        [LaterThanProperty("Start", ErrorMessage = "EndDate has to be later than StartDate")]
        public DateTime End { get; set; }
        [Required(ErrorMessage = "Promotion type is required.")]
        public PromotionType PromotionType { get; set; }
        public decimal ReducedAmount { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
        public bool IsNew { get; set; }

        public string EndFormatted { get { return End.ToShortTimeString(); } }
        public string StartFormatted { get { return Start.ToShortTimeString(); } }

        public Promotion() { }

        public string GetPeriod()
        {
            return Start + " - " + End;
        }

        public override string ToString()
        {
            if (PromotionType == PromotionType.PERCENTAGE)
                return $"Discount of {Amount}%";
            if (PromotionType == PromotionType.QUANTITY)
                return $"Discount of {Amount} items";
            if (PromotionType == PromotionType.FIXEDPRICE)
                return $"Discount of {Amount}$";
            return "";
        }

        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }

    public enum PromotionType
    {
        PERCENTAGE, FIXEDPRICE, QUANTITY
    }
}
