using FlightAppEliasGryp.Helpers;
using FlightAppEliasGryp.Helpers.Converters;
using FlightAppEliasGryp.Models;
using FlightAppEliasGryp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
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
            ViewModel.ClearPromotions();
            createPromotions(product.Promotions);
        }

        private void createPromotions(List<Promotion> promotions)
        {
            promotions.ForEach(
               promotion => ViewModel.AddPromotionToPromotionModel((Promotion)promotion.Clone())
               );
        }

        private void ToggleSwitch_Toggled(object sender, RoutedEventArgs e)
        {
            ToggleSwitch toggleSwitch = sender as ToggleSwitch;
            var promotion = toggleSwitch.Tag as Promotion;
        }

        private async void ButtonDelete_Click(object sender, RoutedEventArgs e)
        {
            ContentDialog dialog = new ContentDialog()
            {
                Title = "Delete product",
                Content = new TextBlock()
                {
                    Text = "Do you want to delete this product?"
                },
                CloseButtonText = "Cancel",
                PrimaryButtonText = "Yes"
            };
            ContentDialogResult result = await dialog.ShowAsync();

            if (result == ContentDialogResult.Primary)
                ViewModel.DeleteProduct();
        }

        private void ButtonCancel_Click(object sender, RoutedEventArgs e)
        {
            PromotionItems.Items.Clear();

            foreach(var prom in ViewModel.Promotions)
            {
                PromotionItems.Items.Add(prom);
            }

            ProductName.Text = ViewModel.Product.Name;
            ProductCat.SelectedItem = ProdTypeConverter.ConvertFromType(ViewModel.Product.Type);
            ProductPrice.Text = ViewModel.Product.Price.ToString();
            ProductStock.Text = ViewModel.Product.Stock.ToString();
        }

        private void ButtonSave_Click(object sender, RoutedEventArgs e)
        {
            ViewModel.UpdateProduct(
                ProductName.Text,
                Convert.ToDecimal(ProductPrice.Text),
                int.Parse(ProductStock.Text)
                );
        }

        private void RequiredAmount_TextChanged(object sender, TextChangedEventArgs e)
        {
            var txtBox = (TextBox)sender;
            var entry = (Promotion)txtBox.Tag;
            if(entry != null)
            entry.RequiredAmount = int.Parse(txtBox.Text);
        }

        private void DiscountAmount_TextChanged(object sender, TextChangedEventArgs e)
        {
            var txtBox = (TextBox)sender;
            var entry = (Promotion)txtBox.Tag;
            if(entry != null)
            entry.Amount = Convert.ToDecimal(txtBox.Text);
        }

        private void StartDate_DateChanged(CalendarDatePicker sender, CalendarDatePickerDateChangedEventArgs args)
        {
            var entry = (Promotion)sender.Tag;
            if(entry != null)
            entry.Start = sender.Date.Value.Date;
        }

        private void StartHours_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var comboBox = (ComboBox)sender;
            var entry = (Promotion)comboBox.Tag;
            if (entry != null)
                entry.Start = new DateTime(entry.Start.Year, entry.Start.Month, entry.Start.Day) + new TimeSpan(int.Parse(comboBox.SelectedItem.ToString()), entry.Start.TimeOfDay.Minutes, 0);
        }

        private void StartMinutes_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var comboBox = (ComboBox)sender;
            var entry = (Promotion)comboBox.Tag;
            if (entry != null)
                entry.Start = new DateTime(entry.Start.Year, entry.Start.Month, entry.Start.Day) + new TimeSpan(0, int.Parse(comboBox.SelectedItem.ToString()), 0);
        }

        private void EndDate_DateChanged(CalendarDatePicker sender, CalendarDatePickerDateChangedEventArgs args)
        {
            var entry = (Promotion)sender.Tag;
            if(entry != null)
            entry.End = sender.Date.Value.Date;
        }

        private void EndHours_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var comboBox = (ComboBox)sender;
            var entry = (Promotion)comboBox.Tag;
            if (entry != null)
                entry.End = new DateTime(entry.End.Year, entry.End.Month, entry.End.Day) + new TimeSpan(int.Parse(comboBox.SelectedItem.ToString()), entry.End.TimeOfDay.Minutes, 0);
        }

        private void EndMinutes_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var comboBox = (ComboBox)sender;
            var entry = (Promotion)comboBox.Tag;
            if (entry != null)
                entry.End = new DateTime(entry.End.Year, entry.End.Month, entry.End.Day) + new TimeSpan(0, int.Parse(comboBox.SelectedItem.ToString()), 0);
        }

        private void RemovePromotion_Click(object sender, RoutedEventArgs e)
        {
            var button = (HyperlinkButton)sender;
            var entry = (Promotion)button.Tag;
            if(entry != null)
            entry.IsDeleted = true;
        }

        private async void AddNewPromotion_Click(object sender, RoutedEventArgs e)
        {
            AddPromotionDialog addPromotionDialog = new AddPromotionDialog(ViewModel.Product);
            ContentDialogResult result = await addPromotionDialog.ShowAsync();
        }

        private void ProductStock_BeforeTextChanging(TextBox sender, TextBoxBeforeTextChangingEventArgs args)
        {
            args.Cancel = args.NewText.Any(c => !char.IsDigit(c));
        }

        private void ProductPrice_BeforeTextChanging(TextBox sender, TextBoxBeforeTextChangingEventArgs args)
        {
            args.Cancel = args.NewText.Any(c => !(c.Equals('.') || c.Equals(',') || char.IsDigit(c)));
        }

        private void ProductName_TextChanged(object sender, TextChangedEventArgs e)
        {
            var textbox = sender as TextBox;
            ViewModel.NewName = textbox.Text;
        }

        private void ProductStock_TextChanged(object sender, TextChangedEventArgs e)
        {
            var textbox = sender as TextBox;
            ViewModel.NewStock = int.Parse(textbox.Text);
        }

        private void ProductPrice_TextChanged(object sender, TextChangedEventArgs e)
        {
            var textbox = sender as TextBox;
            ViewModel.NewPrice = textbox.Text;
        }

        protected override void OnNavigatingFrom(NavigatingCancelEventArgs e)
        {
            base.OnNavigatingFrom(e);
            ViewModel.PriceErrorMsg = "";
        }
    }
}
