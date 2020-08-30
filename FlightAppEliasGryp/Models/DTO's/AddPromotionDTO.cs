using FlightAppEliasGryp.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightAppEliasGryp.Models.DTO_s
{
    public class AddPromotionDTO : IValidatableObject
    {
        public int Id { get; set; }
        public int RequiredAmount { get; set; }
        [Required(ErrorMessage = "Discount amount is required.")]
        public decimal Amount { get; set; }
        [DateGreaterThanValidator]
        public DateTime Start { get; set; }
        [LaterThanProperty("Start", ErrorMessage = "EndDate has to be later than StartDate")]
        public DateTime End { get; set; }
        public PromotionType PromotionType { get; set; }
        public decimal ReducedAmount { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
        public bool IsNew { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var results = new List<ValidationResult>();
            System.ComponentModel.DataAnnotations.Validator.TryValidateProperty(this.Amount,
                    new ValidationContext(this, null, null) { MemberName = "Amount" },
                    results);
            return results;
        }
    }
}
