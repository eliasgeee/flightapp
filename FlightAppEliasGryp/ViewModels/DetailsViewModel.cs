using System;
using FlightAppEliasGryp.Services;
using GalaSoft.MvvmLight;

namespace FlightAppEliasGryp.ViewModels
{
    public class DetailsViewModel : ViewModelBase
    {
        public NavigationServiceEx NavigationService => ViewModelLocator.Current.NavigationService;

        public DetailsViewModel()
        {
        }
    }
}
