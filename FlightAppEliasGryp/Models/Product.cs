using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace FlightAppEliasGryp.Models
{
    public class Product
    {
        public int Id { get; set; }

        private string _name { get; set; }
        public string Name { get { return _name; } set {
                if (value.Length < 2)
                    throw new Exception("Name must be 2 characters minimum");
                _name = value;
            } }
        public string Image { get; set; }
        public decimal Price { get; set; }
        public ProductType Type { get; set; }
        public List<Promotion> Promotions { get; set; }
        public bool IsSoldOut { get; set; }
        private int _stock;
        public int Stock { get {
                return _stock;
            } set {
                if (value < 0)
                    throw new Exception("Stock must be bigger than 0");
                _stock = value;
            }
        }

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
    }

    public enum ProductType
    {
        BEVERAGE, SNACK
    }
}
