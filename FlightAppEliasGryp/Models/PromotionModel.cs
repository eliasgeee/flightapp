using FlightAppEliasGryp.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightAppEliasGryp.Models
{
    public class PromotionModel
    {
        public Promotion Promotion { get; set; }

        public IEnumerable<PromotionType> PromotionTypes
        {
            get { return EnumHelper.GetValues<PromotionType>(); }
        }

        public IEnumerable<string> Hours
        {
            get { return TimeHelper.GetHours(); }
        }

        public IEnumerable<string> Minutes
        {
            get { return TimeHelper.GetMinutes(); }
        }

        public PromotionModel(Promotion promotion)
        {
            Promotion = promotion;
        }
    }
}
