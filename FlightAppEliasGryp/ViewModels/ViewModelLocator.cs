﻿using System;
using FlightAppEliasGryp.Models;
using FlightAppEliasGryp.Services;
using FlightAppEliasGryp.Views;

using GalaSoft.MvvmLight.Ioc;

namespace FlightAppEliasGryp.ViewModels
{
    [Windows.UI.Xaml.Data.Bindable]
    public class ViewModelLocator
    {
        private static ViewModelLocator _current;

        public static ViewModelLocator Current => _current ?? (_current = new ViewModelLocator());

        private ViewModelLocator()
        {
            SimpleIoc.Default.Register<ICatalogDataService, CatalogDataService>();
            SimpleIoc.Default.Register(() => new NavigationServiceEx());
            SimpleIoc.Default.Register<ShellViewModel>();
            Register<DetailsViewModel, DetailsPage>();
            Register<CatalogViewModel, CatalogPage>();
        }

        public CatalogViewModel CatalogViewModel => SimpleIoc.Default.GetInstance<CatalogViewModel>();

        public DetailsViewModel DetailsViewModel => SimpleIoc.Default.GetInstance<DetailsViewModel>();

        public ShellViewModel ShellViewModel => SimpleIoc.Default.GetInstance<ShellViewModel>();

        public NavigationServiceEx NavigationService => SimpleIoc.Default.GetInstance<NavigationServiceEx>();

        public void Register<VM, V>()
            where VM : class
        {
            SimpleIoc.Default.Register<VM>();

            NavigationService.Configure(typeof(VM).FullName, typeof(V));
        }
    }
}