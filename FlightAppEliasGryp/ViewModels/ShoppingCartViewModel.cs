using FlightAppEliasGryp.Models;
using FlightAppEliasGryp.Services;
using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightAppEliasGryp.ViewModels
{
    public class ShoppingCartViewModel : ViewModelBase
    {
        public ShoppingCart ShoppingCart { get; set; }
        public NavigationServiceEx NavigationService => ViewModelLocator.Current.NavigationService;
        private ICatalogDataService _catalogDataService { get; set; }

        public ShoppingCartViewModel(
         ICatalogDataService catalogDataService
            )
        {
            _catalogDataService = catalogDataService;
            LoadDataAsync();
        }

        private async void LoadDataAsync()
        {
            var data = await _catalogDataService.GetShoppingCart();
            ShoppingCart = data;
        }

        public async void RemoveEntryFromShoppingCart(ShoppingCartEntry entry)
        {
            var data = await _catalogDataService.RemoveEntryFromShoppingCart(entry);
        }
    }
}
