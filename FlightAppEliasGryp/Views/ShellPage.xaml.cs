﻿using System;

using FlightAppEliasGryp.ViewModels;

using Windows.UI.Xaml.Controls;

namespace FlightAppEliasGryp.Views
{
    // TODO WTS: Change the icons and titles for all NavigationViewItems in ShellPage.xaml.
    public sealed partial class ShellPage : Page
    {
        private ShellViewModel ViewModel
        {
            get { return ViewModelLocator.Current.ShellViewModel; }
        }

        public ShellPage()
        {
            InitializeComponent();
            DataContext = ViewModel;
            ViewModel.Initialize(shellFrame, navigationView, KeyboardAccelerators);
            InitAsync();
        }

        private async void InitAsync()
        {
            ViewModel.GetNewOrdersCount();
          //  OrderManagement.Content = OrderManagement.Content + " (" + ViewModel.NewOrders +")";
        }
    }
}
