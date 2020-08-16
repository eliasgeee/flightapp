using System;
using FlightAppEliasGryp.Models;
using FlightAppEliasGryp.Services;
using FlightAppEliasGryp.Views;
using FlightAppEliasGryp.Views.Flight;
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
            SimpleIoc.Default.Register<IOrderDataService, OrderDataService>();
            SimpleIoc.Default.Register<IFlightService, FlightService>();
            SimpleIoc.Default.Register<ILocationService, LocationService>();
            SimpleIoc.Default.Register<IConversationService, ConversationService>();
            SimpleIoc.Default.Register<IAccountService, AccountService>();
            SimpleIoc.Default.Register(() => new NavigationServiceEx());
            SimpleIoc.Default.Register<ShellViewModel>();
            SimpleIoc.Default.Register<IAuthenticationService, AuthenticationService>();
            SimpleIoc.Default.Register<IWeatherDataService, WeatherDataService>();
            SimpleIoc.Default.Register<HttpClientService>();

            Register<DetailsViewModel, DetailsPage>();
            Register<CatalogViewModel, CatalogPage>();
            Register<ShoppingCartViewModel, ShoppingCartPage>();
            Register<AdminCatalogViewModel, AdminCatalogPage>();
            Register<ProductDetailsViewModel, ProductDetailsPage>();
            Register<AddPromotionViewModel, AddPromotionDialog>();
            Register<MyOrdersViewModel, MyOrdersPage>();
            Register<OrderManagementViewModel, OrdersManagementPage>();
            Register<OrderDetailsViewModel, OrderDetailPage>();
            Register<SeatManagementViewModel, SeatManagementPage>();
            Register<FlightViewModel, FlightPage>();
            Register<ConversationsViewModel, ConversationsPage>();
            Register<ConversationDetailViewModel, ConversationDetailPage>();
            Register<ConversationsOverviewViewModel, ConversationsOverviewPage>();
            Register<MainPageViewModel, MainPage>();

            SimpleIoc.Default.Register<SeatViewModel>();
            SimpleIoc.Default.Register<PassengerLoginViewModel>();
            SimpleIoc.Default.Register<CrewMemberLoginViewModel>();
            SimpleIoc.Default.Register<WeatherForecastViewModel>();
        }

        public CatalogViewModel CatalogViewModel => SimpleIoc.Default.GetInstance<CatalogViewModel>();
        public DetailsViewModel DetailsViewModel => SimpleIoc.Default.GetInstance<DetailsViewModel>();
        public ShellViewModel ShellViewModel => SimpleIoc.Default.GetInstance<ShellViewModel>();
        public ShoppingCartViewModel ShoppingCartViewModel => SimpleIoc.Default.GetInstance<ShoppingCartViewModel>();
        public AdminCatalogViewModel AdminCatalogViewModel => SimpleIoc.Default.GetInstance<AdminCatalogViewModel>();
        public ProductDetailsViewModel ProductDetailsViewModel => SimpleIoc.Default.GetInstance<ProductDetailsViewModel>();
        public AddPromotionViewModel AddPromotionViewModel => SimpleIoc.Default.GetInstance<AddPromotionViewModel>();
        public OrderManagementViewModel OrderManagementViewModel => SimpleIoc.Default.GetInstance<OrderManagementViewModel>();
        public MyOrdersViewModel MyOrdersViewModel => SimpleIoc.Default.GetInstance<MyOrdersViewModel>();
        public OrderDetailsViewModel OrderDetailsViewModel => SimpleIoc.Default.GetInstance<OrderDetailsViewModel>();
        public SeatManagementViewModel SeatManagementViewModel => SimpleIoc.Default.GetInstance<SeatManagementViewModel>();
        public FlightViewModel FlightViewModel => SimpleIoc.Default.GetInstance<FlightViewModel>();
        public ConversationsViewModel ConversationsViewModel => SimpleIoc.Default.GetInstance<ConversationsViewModel>();
        public ConversationDetailViewModel ConversationDetailViewModel => SimpleIoc.Default.GetInstance<ConversationDetailViewModel>();
        public ConversationViewModelItem ConversationViewModelItem => SimpleIoc.Default.GetInstance<ConversationViewModelItem>();
        public PassengerLoginViewModel PassengerLogInViewModel => SimpleIoc.Default.GetInstance<PassengerLoginViewModel>();
        public MainPageViewModel MainPageViewModel => SimpleIoc.Default.GetInstance<MainPageViewModel>();
        public SeatViewModel SeatViewModel => SimpleIoc.Default.GetInstance<SeatViewModel>();
        public CrewMemberLoginViewModel CrewMemberLoginViewModel => SimpleIoc.Default.GetInstance<CrewMemberLoginViewModel>();
        public WeatherForecastViewModel WeatherForecastViewModel => SimpleIoc.Default.GetInstance<WeatherForecastViewModel>();

        public IWeatherDataService WeatherDataService => SimpleIoc.Default.GetInstance<IWeatherDataService>();

        public NavigationServiceEx NavigationService => SimpleIoc.Default.GetInstance<NavigationServiceEx>();

        public void Register<VM, V>()
            where VM : class
        {
            SimpleIoc.Default.Register<VM>();

            NavigationService.Configure(typeof(VM).FullName, typeof(V));
        }
    }
}
