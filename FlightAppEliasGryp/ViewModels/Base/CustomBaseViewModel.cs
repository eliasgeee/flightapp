using FlightAppEliasGryp.Services;
using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightAppEliasGryp.ViewModels.Base
{
    public class CustomBaseViewModel : ViewModelBase
    {
        protected NavigationServiceEx NavigationService => ViewModelLocator.Current.NavigationService;
    }
}
