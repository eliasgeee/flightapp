using FlightAppEliasGryp.Models;
using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightAppEliasGryp.ViewModels
{
    public class ProductViewModel : ViewModelBase
    {
        public int Id { get; set; }

        private string _name { get; set; }
        public string Name
        {
            get { return _name; }
            set
            {
                if (value.Length < 2)
                    throw new Exception("Name must be 2 characters minimum");
                _name = value;
            }
        }
        public string Image { get; set; }
        public decimal Price { get; set; }
        public ProductType Type { get; set; }
        public List<Promotion> Promotions { get; set; }
        public bool IsSoldOut { get; set; }
        private int _stock;
        public int Stock
        {
            get
            {
                return _stock;
            }
            set
            {
                if (value < 0)
                    throw new Exception("Stock must be bigger than 0");
                _stock = value;
            }
        }

        public ProductViewModel(Product product)
        {
            Promotions = new List<Promotion>();
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
