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

namespace FlightAppEliasGryp.Views.Entertainment.Video
{
    public sealed partial class VideoCategoryControl : UserControl
    {
        public MultimediaViewModel ViewModel
        {
            get { return (MultimediaViewModel)GetValue(LocationProperty); }
            set
            {
                SetValue(LocationProperty, value);
            }
        }

        public static readonly DependencyProperty LocationProperty =
       DependencyProperty.Register("MultimediaViewModel", typeof(MultimediaViewModel),
           typeof(VideoCategoryControl), new PropertyMetadata(null));

        public List<MultimediaViewModel> MultimediaViewModels { get; set; }

        public VideoCategoryControl()
        {
            this.InitializeComponent();
        }
    }
}
