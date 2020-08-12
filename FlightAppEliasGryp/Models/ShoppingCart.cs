using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightAppEliasGryp.Models
{
    public class ShoppingCart : ObservableObject
    {
        public List<ShoppingCartEntry> ShoppingCartEntries { get; private set; }
        public int AmountOfItems { get; set; }

        private decimal _totalCost;
        public decimal TotalCost { get { return _totalCost; } set {
                _totalCost = value;
                Set("TotalCost", ref _totalCost, value);
            } }

        public ShoppingCart()
        {
            ShoppingCartEntries = new List<ShoppingCartEntry>();
        }

        public string GetFormattedAmountOfItems()
        {
            return $"{AmountOfItems} items";
        }
    }
}
