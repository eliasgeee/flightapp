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
    public class ProductDetailsViewModel : ViewModelBase
    {
        public Product Product { get; set; }
        public NavigationServiceEx NavigationService => ViewModelLocator.Current.NavigationService;
        private ICatalogDataService _catalogDataService { get; set; }

        public ProductDetailsViewModel(
        ICatalogDataService catalogDataService
           )
        {
            _catalogDataService = catalogDataService;
        }

        public async void DeleteProduct()
        {
            await _catalogDataService.DeleteProductAsync(Product);
        }

        public async void UpdateProduct(string name, ProductType type, decimal price, int stock)
        {
            Product.Name = name;
            Product.Type = type;
            Product.Price = price;
            Product.Stock = stock;
            Product = await _catalogDataService.UpdateProductAsync(Product);
        }
    }
}
