using FlightAppEliasGryp.Models;
using FlightAppEliasGryp.Services;
using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightAppEliasGryp.ViewModels
{
    public class AddPromotionViewModel : ViewModelBase
    {
        private ICatalogDataService _catalogDataService { get; set; }

        public Product Product { get; set; }

        public AddPromotionViewModel(
         ICatalogDataService catalogDataService
            )
        {
            _catalogDataService = catalogDataService;
        }

        public void AddPromotionToProduct(PromotionType type, decimal amount, int quantity, DateTime start, DateTime end)
        {
            _catalogDataService.AddPromotionToProduct(Product, new Promotion()
            {
                PromotionType = type,
                Amount = amount,
                RequiredAmount = quantity,
                Start = start,
                End = end
            });
        }
    }
}
