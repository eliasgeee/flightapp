using FlightAppEliasGryp.Core.Models.enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FlightAppEliasGryp.Core.Models
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
        public int Stock { get; set; }

        public Product()
        {
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

            for (int i = 0; i < Promotions.Count; i++)
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
    }
}
