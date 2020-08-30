using FlightAppEliasGryp.Models;
using FlightAppEliasGryp.Services;
using FlightAppEliasGryp.ViewModels.Base;
using FlightAppEliasGryp.Views;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Microsoft.Toolkit.Uwp.UI.Animations;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net;
using System.Net.Http;
using System.Security.Authentication;
using System.Security.Cryptography.X509Certificates;
using System.Windows.Input;

namespace FlightAppEliasGryp.ViewModels
{
    public class CatalogViewModel : CustomBaseViewModel
    {

        internal ICollection<Product> Products { get => products; set => products = value; }

        private int _itemsInShoppingCart;
        public int ItemsInShoppingCart { get { return _itemsInShoppingCart; } set {
                _itemsInShoppingCart = value;
                RaisePropertyChanged();
            } }

        private ICollection<Product> products;
        private ICollection<Product> Bestellingen { get; set; }
        private ICatalogDataService _catalogDataService { get; set; }

        private ICommand _addToShoppingCart;

        public ICommand AddToShoppingCartCommand =>
            _addToShoppingCart ?? (_addToShoppingCart = new RelayCommand<Product>(AddProductToShoppingCart));

        public CatalogViewModel(
         ICatalogDataService catalogDataService
            )
        {
            Bestellingen = new ObservableCollection<Product>();
           _catalogDataService = catalogDataService;
           products = new ObservableCollection<Product>();
            LoadDataAsync();
        }

        internal void OnShoppingCartIconTapped()
        {
            NavigationService.Navigate("FlightAppEliasGryp.ViewModels.ShoppingCartViewModel");
        }

        public async void LoadDataAsync()
        {
                  Products.Clear();
                  var data = await _catalogDataService.GetProductsAsync();
                    foreach (var item in data)
                    {
                        Products.Add(item);
                    }
            GetAmountOfItemsInShoppingCart();
        }

        public async void GetAmountOfItemsInShoppingCart()
        {
            ItemsInShoppingCart = await _catalogDataService.GetAmountOfItemsInShoppingCartAsync();
        }

        public async void AddProductToShoppingCart(Product clickedItem)
        {
            if (clickedItem != null)
            {
                NavigationService.Frame.SetListDataItemForNextConnectedAnimation(clickedItem);
                await _catalogDataService.AddProductToShoppingCart(clickedItem);
            }
            GetAmountOfItemsInShoppingCart();
        }
    }
}
