using FlightAppEliasGryp.Core.Helpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace FlightAppEliasGryp.Core.Models
{
    public class ShoppingCart : NotificationBase
    {
        public List<ShoppingCartEntry> ShoppingCartEntries { get; private set; }
        public int AmountOfItems { get; set; }

        private decimal _totalCost;
        public decimal TotalCost
        {
            get { return _totalCost; }
            set
            {
                _totalCost = value;
                RaisePropertyChanged();
            }
        }

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
