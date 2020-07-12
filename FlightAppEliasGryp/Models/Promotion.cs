using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightAppEliasGryp.Models
{
    public class Promotion
    {
        public decimal Percentage { get; set; }
        public DateTime Start { get; set; }
        public PromotionType Type { get; set; }
        public decimal ReducedAmount { get; set; }

        public Promotion() { }

        public Promotion(decimal percentage) : base()
        {
            Percentage = percentage;
            Start = DateTime.Now;
        }
    }

    public enum PromotionType
    {
        FIXED_PRICE, PERCENTAGE, QUANTITY
    }
}
