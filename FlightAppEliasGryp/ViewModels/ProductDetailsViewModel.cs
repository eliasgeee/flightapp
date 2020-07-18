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
        public List<PromotionModel> Promotions { get; set; }

        public ProductDetailsViewModel(
        ICatalogDataService catalogDataService
           )
        {
            _catalogDataService = catalogDataService;
            Promotions = new List<PromotionModel>();
        }

        public async void DeleteProduct()
        {
            await _catalogDataService.DeleteProductAsync(Product);
        }

        public async void UpdateProduct(string name, decimal price, int stock)
        {
            Product.Name = name;
            Product.Price = price;
            Product.Stock = stock;
            Product.Promotions.Clear();
            Promotions.ForEach(promotion =>
            Product.Promotions.Add(promotion.Promotion)
                );
            Product = await _catalogDataService.UpdateProductAsync(Product);
        }

        internal void ClearPromotions()
        {
            Promotions.Clear();
        }

        public void AddPromotionToPromotionModel(Promotion promotion)
        {
            Promotions.Add(new PromotionModel(promotion));
        }
    }
}
