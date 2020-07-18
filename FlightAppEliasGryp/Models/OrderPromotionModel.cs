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
        public string ProductName { get; set; }
        public string DiscountType { get; set; }
        public int PromotionId { get; set; }
    }
}
