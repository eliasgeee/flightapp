using FlightAppEliasGryp.Models;
using FlightAppEliasGryp.ViewModels;
using GalaSoft.MvvmLight.Command;
using Microsoft.Toolkit.Uwp.UI.Controls;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Windows.Input;
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
    public sealed partial class AdminCatalogPage : Page
    {
        private AdminCatalogViewModel ViewModel
        {
            get { return ViewModelLocator.Current.AdminCatalogViewModel; }
        }

        public AdminCatalogPage()
        {
            this.InitializeComponent();
            ViewModel.LoadDataAsync();
        }

        private void AdaptiveGridView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void ShowDetail(ItemClickEventArgs arg)
        {
            var item = arg.ClickedItem as Product;
            var grid = arg.OriginalSource as AdaptiveGridView;

            SetAnimation(item, grid);
        }

        private void SetAnimation(Product product, AdaptiveGridView grid)
        {
            if (product == null || grid == null) return;

            grid.PrepareConnectedAnimation("anim", product, product.Image);
            ViewModel.ViewProductDetails(product);
        }


        private void ProductItemClicked(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            Product clickedProduct = ((Button)sender).DataContext as Product;
            ViewModel.ViewProductDetails(clickedProduct);
        }
    }
}
