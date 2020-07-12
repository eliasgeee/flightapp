using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightAppEliasGryp.Models
{
    public class ShoppingCart
    {
        public List<ShoppingCartEntry> ShoppingCartEntries { get; private set; }
        public int AmountOfItems { get; set; }
        public decimal TotalCost { get; set; }

        public ShoppingCart()
        {
            ShoppingCartEntries = new List<ShoppingCartEntry>();
        }

        public string GetFormattedAmountOfItems()
        {
            return AmountOfItems + " Items";
        }
    }
}
