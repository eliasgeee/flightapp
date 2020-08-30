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

// The User Control item template is documented at https://go.microsoft.com/fwlink/?LinkId=234236

namespace FlightAppEliasGryp.Views.Map
{
    public sealed partial class FlightMarker : UserControl
    {
        public FlightDetailViewModel ViewModel { get { return ViewModelLocator.Current.FlightDetailViewModel; } }

        public FlightMarker()
        {
            this.InitializeComponent();
            ViewModel.LoadDataAsync();
        }

        private void Grid_Tapped(object sender, TappedRoutedEventArgs e)
        {
            var grid = sender as UIElement;
            var flyout = (FlyoutBase)grid.GetValue(FlyoutBase.AttachedFlyoutProperty);
            flyout.ShowAt(grid as FrameworkElement);
        }
    }
}
