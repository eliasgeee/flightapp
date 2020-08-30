using FlightAppEliasGryp.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace FlightAppEliasGryp.Services
{
    public class CatalogDataService : ICatalogDataService
    {
        private readonly string baseUri = "Catalog/";
        private HttpClientService _clientService;
        private DataService<Product> _productDataService;
        private DataService<Promotion> _promotionDataService;
        private DataService<ShoppingCart> _shoppingCartDataService;
        private DataService<int> _countDataService;

        public CatalogDataService(HttpClientService clientService)
        {
            _clientService = clientService;
            _productDataService = new DataService<Product>(_clientService);
            _shoppingCartDataService = new DataService<ShoppingCart>(_clientService);
            _countDataService = new DataService<int>(_clientService);
            _promotionDataService = new DataService<Promotion>(_clientService);
        }

        public async Task<IList<Product>> AddProductToShoppingCart(Product product)
        {
            var request = await _productDataService.MakeRequest(new ApiRequest(ApiRequestType.POST)
            {
                Uri = baseUri + "ShoppingCart/" + product.Id,
            });
            return null;
        }

        public async Task<Promotion> AddPromotionToProduct(Product product, Promotion promotion)
        {
            var request = await _promotionDataService.MakeRequest(new ApiRequest(ApiRequestType.POST)
            {
                Uri = baseUri + "Promotion/Add/" + product.Id,
                Body = promotion
            });
            return request.AsSingle();
        }

        public async Task<ShoppingCart> ChangeEntryAmount(ShoppingCartEntry entry, int amount)
        {
            var request = await _shoppingCartDataService.MakeRequest(new ApiRequest(ApiRequestType.PUT)
            {
                Uri = baseUri + "ShoppingCart/Entry/" + entry.Id + "/Amount/" + amount
            });
            return request.AsSingle();
        }

        public async Task<Product> DeleteProductAsync(Product product)
        {
            var request = await _productDataService.MakeRequest(new ApiRequest(ApiRequestType.DELETE)
            {
                Uri = baseUri + "Product/Remove/" + product.Id
            });
            return request.AsSingle();
        }

        public async Task<int> GetAmountOfItemsInShoppingCartAsync()
        {
            var request = await _countDataService.MakeRequest(new ApiRequest(ApiRequestType.GET)
            {
                Uri = baseUri + "ShoppingCartItems"
            });
            return request.AsSingle();
        }

        public async Task<Product> GetProductAsync(int id)
        {
            var request = await _productDataService.MakeRequest(new ApiRequest(ApiRequestType.GET)
            {
                Uri = baseUri + "Product/" + id + "/"
            });
            return request.AsSingle();
        }

        public async Task<IList<Product>> GetProductsAsync()
        {
            var request = await _productDataService.MakeRequest(new ApiRequest(ApiRequestType.GET)
            {
                Uri = baseUri + "Products/"
            });
            return request.AsList().ToList();
        }

        public async Task<ShoppingCart> GetShoppingCart()
        {
            var request = await _shoppingCartDataService.MakeRequest(new ApiRequest(ApiRequestType.GET)
            {
                Uri = baseUri + "ShoppingCart/"
            });
            return request.AsSingle();
        }

        public async Task<ShoppingCart> RemoveEntryFromShoppingCart(ShoppingCartEntry entry)
        {
            var request = await _shoppingCartDataService.MakeRequest(new ApiRequest(ApiRequestType.PUT)
            {
                Uri = baseUri + "ShoppingCart/Remove/" + entry.Product.Id
            });
            return request.AsSingle();
        }

        public async Task<Product> UpdateProductAsync(Product product)
        {
            var request = await _productDataService.MakeRequest(new ApiRequest(ApiRequestType.PUT)
            {
                Uri = baseUri + "Product/Update/" + product.Id,
                Body = product
            });
            return request.AsSingle();
        }
    }
}
