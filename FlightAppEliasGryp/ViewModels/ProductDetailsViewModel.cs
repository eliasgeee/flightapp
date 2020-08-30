using FlightAppEliasGryp.Helpers;
using FlightAppEliasGryp.Models;
using FlightAppEliasGryp.Services;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace FlightAppEliasGryp.ViewModels
{
    public class ProductDetailsViewModel : ViewModelBase
    {
        private Product _product;
        public Product Product { get { return _product; } set {
                UpdatedProduct = value;
                Set("Product", ref _product, value); } }

        public Product _updatedProduct;
        public Product UpdatedProduct { get {
                return _updatedProduct; } set {
                Set("UpdatedProduct", ref _updatedProduct, value); } }

        public NavigationServiceEx NavigationService => ViewModelLocator.Current.NavigationService;
        private ICatalogDataService _catalogDataService { get; set; }

        public ObservableCollection<PromotionModel> Promotions { get; set; }

        public ICommand SaveChangesCommand => new RelayCommand(SaveUpdatedProduct);
        public ICommand RevertChangesCommand => new RelayCommand(RevertChanges);

        private int _NewStock;
        private string _NewPrice;
        private string _NewName;

        public int NewStock { get { return _NewStock; } set { Set("NewStock", ref _NewStock, value); } }
        public string NewPrice { get { return _NewPrice; } set {
                Set("NewPrice", ref _NewPrice, value); } }
        public string NewName { get { return _NewName; } set { Set("NewName", ref _NewName, value); } }

        private string _productNameErrorMsg;
        public string ProductNameErrorMsg { get { return _productNameErrorMsg; }
            set { Set("ProductNameErrorMsg", ref _productNameErrorMsg, value); } }

        private string _stockErrorMsg;
        public string StockErrorMsg
        {
            get { return _stockErrorMsg; }
            set { Set("StockErrorMsg", ref _stockErrorMsg, value); }
        }

        private string _priceErrorMsg;
        public string PriceErrorMsg
        {
            get { return _priceErrorMsg; }
            set { Set("PriceErrorMsg", ref _priceErrorMsg, value); }
        }

        public ProductDetailsViewModel(
        ICatalogDataService catalogDataService
           )
        {
            _catalogDataService = catalogDataService;
            Promotions = new ObservableCollection<PromotionModel>();
        }

        public async void DeleteProduct()
        {
            var result = await _catalogDataService.DeleteProductAsync(Product);
            if (result != null) NavigationService.Navigate(typeof(AdminCatalogViewModel).FullName);
        }

        public async void UpdateProduct(string name, decimal price, int stock)
        {
            await Task.Run(() =>
            {
                Product.Name = name;
                Product.Price = price;
                Product.Stock = stock;
                Product.Promotions.Clear();
                foreach(var promotion in Promotions)
                {
                    Product.Promotions.Add(promotion.Promotion);
                };
            });
         //   Product = await _catalogDataService.UpdateProductAsync(Product);
        }

        public void RevertChanges()
        {
            PriceErrorMsg = "";
            UpdatedProduct.Name = Product.Name;
            UpdatedProduct.Price = Product.Price;
            UpdatedProduct.Stock = Product.Stock;
            UpdatedProduct.Type = Product.Type;
            UpdatedProduct.Promotions.Clear();
        }

        public async void SaveUpdatedProduct()
        {
            PriceErrorMsg = "";
            if (NewPrice != null) {
                var result = decimal.TryParse(NewPrice, out decimal dec);
                if (result) UpdatedProduct.Price = dec;
            }
            if (NewStock != 0) UpdatedProduct.Stock = NewStock;
            if(NewName != null) UpdatedProduct.Name = NewName;

            var results = new List<ValidationResult>();
            bool isValid = Validator.TryValidateObject(
            UpdatedProduct,
            new ValidationContext(UpdatedProduct, null, null),
            results,
            false);
            if (isValid) { 
                var product = await _catalogDataService.UpdateProductAsync(UpdatedProduct);
                Product = product;
            }
            else
            {
                PriceErrorMsg = results[0].ErrorMessage; 
            }
        }

        private void ShowErrors()
        {
            //StockErrorMsg = "";
            //ProductNameErrorMsg = "";
            //PriceErrorMsg = "";
            //if (UpdatedProduct.Properties[nameof(UpdatedProduct.Name)].Errors.Count > 0)
            //    ProductNameErrorMsg = UpdatedProduct.Properties[nameof(UpdatedProduct.Name)].Errors[0];
            //if(UpdatedProduct.Properties[nameof(UpdatedProduct.Stock)].Errors.Count > 0)
            //StockErrorMsg = UpdatedProduct.Properties[nameof(UpdatedProduct.Stock)].Errors[0];
            //if (UpdatedProduct.Properties[nameof(UpdatedProduct.Price)].Errors.Count > 0)
            //    PriceErrorMsg = UpdatedProduct.Properties[nameof(UpdatedProduct.Price)].Errors[0];
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
