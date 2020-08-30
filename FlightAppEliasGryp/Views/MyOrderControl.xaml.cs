using FlightAppEliasGryp.Models;
using FlightAppEliasGryp.ViewModels;
using Microsoft.Toolkit.Uwp.Helpers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The User Control item template is documented at https://go.microsoft.com/fwlink/?LinkId=234236

namespace FlightAppEliasGryp.Views
{
    public sealed partial class MyOrderControl : UserControl
    {
        private MyOrdersViewModel ViewModel
        {
            get { return ViewModelLocator.Current.MyOrdersViewModel; }
        }
        private PrintHelper _printHelper;
        private FrameworkElement panelToPrint;

        public MyOrderControl()
        {
            this.InitializeComponent();
        }

        private async void PrintButton_Click(object sender, RoutedEventArgs e)
        {
            _printHelper = new PrintHelper(Container);
            panelToPrint = RootPanel;
            Container.Children.Remove(panelToPrint);

            _printHelper.AddFrameworkElementToPrint(panelToPrint);

            var printHelperOptions = new PrintHelperOptions(false);
            printHelperOptions.Orientation = Windows.Graphics.Printing.PrintOrientation.Portrait;

            _printHelper.OnPrintCanceled += PrintHelper_OnPrintCanceled;
            _printHelper.OnPrintFailed += PrintHelper_OnPrintFailed;
            _printHelper.OnPrintSucceeded += PrintHelper_OnPrintSucceeded;

            await _printHelper.ShowPrintUIAsync("Print order", printHelperOptions);
        }

        private async void PrintHelper_OnPrintSucceeded()
        {
            ReleasePrintHelper();
            var dialog = new MessageDialog("Printing done.");
            await dialog.ShowAsync();
        }

        private async void PrintHelper_OnPrintFailed()
        {
            ReleasePrintHelper();
            var dialog = new MessageDialog("Printing failed.");
            await dialog.ShowAsync();
        }

        private void PrintHelper_OnPrintCanceled()
        {
            ReleasePrintHelper();
        }

        private void ReleasePrintHelper()
        {
            _printHelper.Dispose();

            if (!Container.Children.Contains(panelToPrint))
            {
                Container.Children.Add(panelToPrint);
            }
        }
    }
}
