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
        public double Price { get; set; }
   //     public ProductType Type { get; set; }
   //     public Promotion Promotion { get; set; }

        public Product() { }

        public Product(string name, string img, double price, ProductType productType)
        {
            Name = name;
            Image = img;
            Price = price;
     //       Type = productType;
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
