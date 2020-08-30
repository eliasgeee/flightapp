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
    public sealed partial class ShoppingCartPage : Page
    {
        public ShoppingCartViewModel ViewModel
        {
            get { return ViewModelLocator.Current.ShoppingCartViewModel; }
        }

        public ShoppingCartPage()
        {
            InitializeComponent();
            ViewModel.LoadDataAsync();
        }

        private async void OnRemoveEntryClicked(object sender, RoutedEventArgs e)
        {
            var button = (HyperlinkButton)sender;
            var entry = (ShoppingCartEntry)button.Tag;

            ContentDialog dialog = new ContentDialog()
            {
                Title = "Added to shopping cart",
                Content = new TextBlock()
                {
                    Text = "Do you want to remove this item from your shopping cart?"
                },
                CloseButtonText = "Cancel",
                PrimaryButtonText = "Yes"
            };
            ContentDialogResult result =  await dialog.ShowAsync();

            if(result == ContentDialogResult.Primary)
            ViewModel.RemoveEntryFromShoppingCart(entry);
        }

        private void Checkout(object sender, RoutedEventArgs e)
        {
            ViewModel.Checkout();
        }

        //TODO CHANGE THESE METHODS
        private void RaiseProductAmountByOne(object sender, RoutedEventArgs e)
        {
            var button = (HyperlinkButton)sender;
            var entry = (ShoppingCartEntry)button.Tag;

            ViewModel.ChangeEntryAmount(entry, 1);
        }

        private void LowerProductAmountByOne(object sender, RoutedEventArgs e)
        {
            var button = (HyperlinkButton)sender;
            var entry = (ShoppingCartEntry)button.Tag;

            ViewModel.ChangeEntryAmount(entry, -1);
        }

        private void ChangeProductQuantity(object sender, TextChangedEventArgs e)
        {
            var textBox = sender as TextBox;
            int newAmount = -1;
            var entry = (ShoppingCartEntry)textBox.Tag;
            if(textBox.Text != "")
            newAmount = int.Parse(textBox.Text);

            if (newAmount != entry.Quantity && newAmount != -1)
                ViewModel.ChangeEntryAmount(entry, newAmount);
        }
    }
}
