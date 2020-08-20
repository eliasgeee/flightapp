using FlightAppEliasGryp.Models.Entertainment;
using FlightAppEliasGryp.ViewModels.Base;
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

namespace FlightAppEliasGryp.Views.Entertainment
{
    public sealed partial class MultimediaOverviewViewItem : UserControl
    {
        public MultimediaViewModel ViewModel
        {
            get { return (MultimediaViewModel)GetValue(LocationProperty); }
            set
            {
                SetValue(LocationProperty, value);
            }
        }

        public List<MultimediaViewModel> MultimediaViewModels { get; set; }

        public static readonly DependencyProperty LocationProperty =
       DependencyProperty.Register("MultimediaViewModel", typeof(MultimediaViewModel),
           typeof(MultimediaOverviewViewItem), new PropertyMetadata(null));

        public MultimediaOverviewViewItem()
        {
            this.InitializeComponent();
        }

        private void CategoryGrid_ItemClick(object sender, ItemClickEventArgs e)
        {
            var selectedItem = e.ClickedItem as MultimediaViewModel;
            selectedItem.ViewDetails();
        }
    }
}
