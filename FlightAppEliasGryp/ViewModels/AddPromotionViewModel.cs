using FlightAppEliasGryp.Models;
using FlightAppEliasGryp.Models.DTO_s;
using FlightAppEliasGryp.Services;
using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightAppEliasGryp.ViewModels
{
    public class AddPromotionViewModel : ViewModelBase
    {
        private ICatalogDataService _catalogDataService { get; set; }
        private readonly INotificationService _notificationService;

        private Promotion _promotion;
        public Promotion Promotion { get { return _promotion; } set { Set("Promotion", ref _promotion, value); } }

        public ProductDetailsViewModel ProductDetailsViewModel { get { return ViewModelLocator.Current.ProductDetailsViewModel; } }

        private PromotionType _PromotionType;
        private int _RequiredAmount;
        private string _DiscountAmount;
        private int _End;
        private DateTime _Start;

        public PromotionType PromotionType { get { return _PromotionType; } set { Set("PromotionType", ref _PromotionType, value); } }
        public int RequiredAmount { get { return _RequiredAmount; } set { Set("RequiredAmount", ref _RequiredAmount, value); } }
        public string DiscountAmount { get { return _DiscountAmount; } set {
                decimal decres;
                if(decimal.TryParse(value, out decres))
                Set("DiscountAmount", ref _DiscountAmount, value); } }
        public int End { get { return _End; } set { Set("End", ref _End, value); } }
        //    public DateTime End { get { return _End; } set { Set("End", ref _End, value); } }
        public DateTime Start { get { return _Start; } set { Set("Start", ref _Start, value); } }

        private string _ErrorMsg;
        public string ErrorMsg { get { return _ErrorMsg; } set { Set("ErrorMsg", ref _ErrorMsg, value); } }

        public Product Product { get; set; }

        public AddPromotionViewModel(
         ICatalogDataService catalogDataService,
         INotificationService notificationService
            )
        {
            _catalogDataService = catalogDataService;
            _notificationService = notificationService;
        }

        public async void AddPromotionToProduct()
        {
            AddPromotionDTO addPromotionDTO = new AddPromotionDTO();
            addPromotionDTO.Amount = decimal.Parse(DiscountAmount);
            var results = new List<ValidationResult>();
            bool isValid = Validator.TryValidateObject(
            addPromotionDTO,
            new ValidationContext(addPromotionDTO, null, null),
            results,
            false);
            if (isValid)
            {
                var en = double.Parse(End.ToString());
                var dateend = DateTime.Now.AddMinutes(en);
                Promotion = new Promotion
                {
                    End = dateend,
                    Start = DateTime.Now,
                    Amount = decimal.Parse(DiscountAmount),
                    RequiredAmount = RequiredAmount,
                    PromotionType = PromotionType
                };
                var promotion = await _catalogDataService.AddPromotionToProduct(Product, Promotion);
                if(promotion != null)
                {
                    ProductDetailsViewModel.Promotions.Add(new PromotionModel(promotion));
                    try
                    {
                        await _notificationService.SendPromotionNotification(Product, promotion);
                    }
                    catch(Exception e) { }
                }
            }
        }
    }
}
