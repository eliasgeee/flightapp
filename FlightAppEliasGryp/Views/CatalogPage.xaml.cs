using System;
using FlightAppEliasGryp.Models;
using FlightAppEliasGryp.ViewModels;

using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace FlightAppEliasGryp.Views
{
    public sealed partial class CatalogPage : Page
    {
        private CatalogViewModel ViewModel
        {
            get { return ViewModelLocator.Current.CatalogViewModel; }
        }

        public CatalogPage()
        {
            InitializeComponent();
        }

        protected override async void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

//            await ViewModel.LoadDataAsync();
        }

        private async void AddToShoppingCart(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            Product clickedProduct = ((Button)sender).DataContext as Product;
            ViewModel.AddProductToShoppingCart(clickedProduct);
           // ViewModel.addBestelling(clickedProduct);
            ContentDialog dialog = new ContentDialog()
            {
                Title = "Added to shopping cart",
                Content = new TextBlock()
                {
                    Text = "You've added " + clickedProduct.Name + " successfully to your shopping cart"
                },
                CloseButtonText = "OK"
            };
            await dialog.ShowAsync();
        }
    }
}
