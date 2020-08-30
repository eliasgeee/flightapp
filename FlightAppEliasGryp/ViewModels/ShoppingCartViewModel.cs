using FlightAppEliasGryp.Models;
using FlightAppEliasGryp.Services;
using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightAppEliasGryp.ViewModels
{
    public class ShoppingCartViewModel : ViewModelBase
    {
        private ShoppingCart _shoppingCart;
        public ShoppingCart ShoppingCart { get { return _shoppingCart;  } set {
                _shoppingCart = value;
                RaisePropertyChanged();
            } }
        public NavigationServiceEx NavigationService => ViewModelLocator.Current.NavigationService;
        private ICatalogDataService _catalogDataService { get; set; }
        private IOrderDataService _orderDataService { get; set; }

        public ShoppingCartViewModel(
         ICatalogDataService catalogDataService,
         IOrderDataService orderDataService
            )
        {
            _catalogDataService = catalogDataService;
            _orderDataService = orderDataService;
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
            if (data != null)
                ShoppingCart = data;
        }

        public async void Checkout()
        {
            ShoppingCart = new ShoppingCart();
            await _orderDataService.Checkout(PaymentType.CASH);
        }

        public async void ChangeEntryAmount(ShoppingCartEntry entry, int amount)
        {
            await _catalogDataService.ChangeEntryAmount(entry, amount);
        }
    }
}
