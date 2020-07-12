using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightAppEliasGryp.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public decimal Price { get; set; }
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

        public String GetFormattedPrice()
        {
            return Price.ToString() + " $";
        }
    }

    public enum ProductType
    {
        BEVERAGE, SNACK
    }
}
