using FlightAppEliasGryp.Models;
using FlightAppEliasGryp.Services;
using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightAppEliasGryp.ViewModels
{
   public class AdminCatalogViewModel : ViewModelBase
    {

        public NavigationServiceEx NavigationService => ViewModelLocator.Current.NavigationService;
        internal ICollection<Product> Products { get => products; set => products = value; }
        private ICollection<Product> products;
        private ICatalogDataService _catalogDataService { get; set; }

        public AdminCatalogViewModel(
         ICatalogDataService catalogDataService
            )
        {
            _catalogDataService = catalogDataService;
            products = new ObservableCollection<Product>();
        }

        public async void LoadDataAsync()
        {
            Products.Clear();
            var data = await _catalogDataService.GetProductsAsync();
            foreach (var item in data)
            {
                Products.Add(item);
            }
        }

        public void ViewProductDetails(Product clickedItem)
        {
            NavigationService.Navigate("FlightAppEliasGryp.ViewModels.ProductDetailsViewModel", clickedItem);
        }
    }
}
