using FlightAppEliasGryp.Helpers;
using FlightAppEliasGryp.Helpers.Converters;
using FlightAppEliasGryp.Models;
using FlightAppEliasGryp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using Windows.UI.Xaml.Controls;

// The Content Dialog item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace FlightAppEliasGryp.Views
{
    public sealed partial class AddPromotionDialog : ContentDialog
    {
        private AddPromotionViewModel ViewModel
        {
            get { return ViewModelLocator.Current.AddPromotionViewModel; }
        }

        private IEnumerable<PromotionType> PromotionTypes
        {
            get { return EnumHelper.GetValues<PromotionType>(); }
        }

        private DateTime Today
        {
            get { return DateTime.Now; }
        }

        public IEnumerable<string> Hours
        {
            get { return TimeHelper.GetHours(); }
        }

        public IEnumerable<string> Minutes
        {
            get { return TimeHelper.GetMinutes(); }
        }

        public AddPromotionDialog(Product product)
        {
            ViewModel.Product = product;
            this.InitializeComponent();
        }

        private void ContentDialog_PrimaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
            //DateTime Start = new DateTime(DateStart.Date.Value.Year, DateStart.Date.Value.Month, DateStart.Date.Value.Day)
            //    + new TimeSpan(int.Parse(HoursStart.SelectedItem.ToString()), int.Parse(MinutesStart.SelectedItem.ToString()), 0);

            //DateTime End = new DateTime(DateEnd.Date.Value.Year, DateEnd.Date.Value.Month, DateEnd.Date.Value.Day)
            //    + new TimeSpan(int.Parse(HoursEnd.SelectedItem.ToString()), int.Parse(MinutesEnd.SelectedItem.ToString()), 0);

            //PromotionType)PromTypeConverter.ConvertFromType(Type.SelectedItem),
            //    Convert.ToDecimal(Amount.Text),
            //    int.Parse(Quantity.Text),
            //    Start,
            //    End
            //ViewModel.Start = Start;
            //ViewModel.End = End;
            ViewModel.AddPromotionToProduct();
        }

        private void ContentDialog_SecondaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
            sender.Hide();
        }

        private void Quantity_BeforeTextChanging(TextBox sender, TextBoxBeforeTextChangingEventArgs args)
        {
            args.Cancel = args.NewText.Any(c => !char.IsDigit(c));
        }

        private void Amount_BeforeTextChanging(TextBox sender, TextBoxBeforeTextChangingEventArgs args)
        {
            args.Cancel = args.NewText.Any(c => !(c.Equals('.') || c.Equals(',') || char.IsDigit(c)));
        }
    }
}
