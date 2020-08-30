using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace FlightAppEliasGryp.Models
{
    public class Product : IValidatableObject
    {
        public int Id { get; set; }

        [Required (ErrorMessage = "Name is required")]
        [MinLength(2, ErrorMessage ="Name must be minimum 2 characters")]
        public string Name { get; set; }
        public int Stock { get; set; }
        public decimal Price { get; set; }
        public ProductType ProductType { get; set; }

        public string Image { get; set; }

        public ProductType Type { get; set; }
        public List<Promotion> Promotions { get; set; }
        public bool IsSoldOut { get; set; }

        public Product() {
            Promotions = new List<Promotion>();
        }

        public Product(string name, string img, decimal price, ProductType productType) : base()
        {
            Name = name;
            Image = img;
            Price = price;
            Type = productType;
        }

        public string GetReducedPrice()
        {
            decimal total = 0;

            for(int i=0; i < Promotions.Count; i++)
            {
                var prom = Promotions.ElementAt(i);
                total += prom.ReducedAmount;
            }

            return total.ToString();
        }

        public string GetFormattedPrice()
        {
            return $"{Price} $";
        }

        public string GetAmountOfPromotions()
        {
            return $"{Promotions.Count} active";
        }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var results = new List<ValidationResult>();
            System.ComponentModel.DataAnnotations.Validator.TryValidateProperty(this.Name,
                    new ValidationContext(this, null, null) { MemberName = "Name" },
                    results);
            return results;
        }
    }

    public enum ProductType
    {
        BEVERAGE, SNACK
    }
}
