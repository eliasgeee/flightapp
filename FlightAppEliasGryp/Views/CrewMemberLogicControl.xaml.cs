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

namespace FlightAppEliasGryp.Views
{
    public sealed partial class CrewMemberLogicControl : UserControl
    {
        private CrewMemberLoginViewModel ViewModel
        {
            get { return ViewModelLocator.Current.CrewMemberLoginViewModel; }
        }

        public CrewMemberLogicControl()
        {
            this.InitializeComponent();
        }

        private void Username_TextChanged(object sender, TextChangedEventArgs e)
        {
            ViewModel.ValidateLogin(Username.Text, Password.Text);
        }

        private void Password_TextChanged(object sender, TextChangedEventArgs e)
        {
            ViewModel.ValidateLogin(Username.Text, Password.Text);
        }
    }
}
