using FlightAppEliasGryp.Helpers;
using FlightAppEliasGryp.Helpers.Converters;
using FlightAppEliasGryp.Models;
using FlightAppEliasGryp.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace FlightAppEliasGryp.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class ProductDetailsPage : Page
    {
        private ProductDetailsViewModel ViewModel
        {
            get { return ViewModelLocator.Current.ProductDetailsViewModel; }
        }

        private IEnumerable<ProductType> ProductTypes
        {
            get { return EnumHelper.GetValues<ProductType>(); }
        }

        public ProductDetailsPage()
        {
            this.InitializeComponent();
        }

        protected override async void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            var product = e.Parameter as Product;
            ViewModel.Product = product;

            //            await ViewModel.LoadDataAsync();
        }

        private void ToggleSwitch_Toggled(object sender, RoutedEventArgs e)
        {
            ToggleSwitch toggleSwitch = sender as ToggleSwitch;
            var promotion = toggleSwitch.Tag as Promotion;
        }

        private void ButtonDelete_Click(object sender, RoutedEventArgs e)
        {
            ViewModel.DeleteProduct();
        }

        private void ButtonCancel_Click(object sender, RoutedEventArgs e)
        {
            ProductName.Text = ViewModel.Product.Name;
            ProductCat.SelectedItem = ProdTypeConverter.ConvertFromType(ViewModel.Product.Type);
            ProductPrice.Text = ViewModel.Product.Price.ToString();
            ProductStock.Text = ViewModel.Product.Stock.ToString();
        }

        private void ButtonSave_Click(object sender, RoutedEventArgs e)
        {
            ViewModel.UpdateProduct(
                ProductName.Text,
                (ProductType) ProductCat.SelectedItem,
                Convert.ToDecimal(ProductPrice.Text),
                int.Parse(ProductStock.Text)
                );
        }
    }
}
