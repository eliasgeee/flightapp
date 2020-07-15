using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace FlightAppEliasGryp.Models
{
    public class CatalogDataService : ICatalogDataService
    {
        private readonly string baseUri = "https://localhost:44332/api/Catalog/";

        public async Task<IList<Product>> AddProductToShoppingCart(Product product)
        {
            using (var httpClientHandler = new HttpClientHandler())
            {
                httpClientHandler.ServerCertificateCustomValidationCallback = (message, cert, chain, errors) => { return true; };
                using (var client = new HttpClient(httpClientHandler))
                {
                    var reqUri = baseUri + "ShoppingCart/" + product.Id;
                    var json = await client.PostAsync(new Uri(reqUri), new StringContent(product.Id.ToString(), System.Text.Encoding.UTF8, "application/json"));
                    return null;
                }
            }
        }

        public async Task<int> ChangeEntryAmount(ShoppingCartEntry entry, int amount)
        {
            using (var httpClientHandler = new HttpClientHandler())
            {
                httpClientHandler.ServerCertificateCustomValidationCallback = (message, cert, chain, errors) => { return true; };
                using (var client = new HttpClient(httpClientHandler))
                {
                    var reqUri = baseUri + "ShoppingCart/Entry/" + entry.Id + "/Amount/" + amount;
                    var json = await client.PutAsync(new Uri(reqUri), new StringContent(amount.ToString(), System.Text.Encoding.UTF8, "application/json"));
                    return 0;
                }
            }
        }

        public async Task<Order> Checkout()
        {
            using (var httpClientHandler = new HttpClientHandler())
            {
                httpClientHandler.ServerCertificateCustomValidationCallback = (message, cert, chain, errors) => { return true; };
                using (var client = new HttpClient(httpClientHandler))
                {
                    var reqUri = baseUri + "Checkout/";
                    var json = await client.PostAsync(new Uri(reqUri), new StringContent("", System.Text.Encoding.UTF8, "application/json"));
                    return null;
                }
            }
        }

        public async Task<Product> DeleteProductAsync(Product product)
        {
            using (var httpClientHandler = new HttpClientHandler())
            {
                httpClientHandler.ServerCertificateCustomValidationCallback = (message, cert, chain, errors) => { return true; };
                using (var client = new HttpClient(httpClientHandler))
                {
                    var reqUri = baseUri + "Product/Remove/" + product.Id;
                    var json = await client.DeleteAsync(new Uri(reqUri));
                    return null;
                }
            }
        }

        public async Task<int> GetAmountOfItemsInShoppingCartAsync()
        {
            using (var httpClientHandler = new HttpClientHandler())
            {
                httpClientHandler.ServerCertificateCustomValidationCallback = (message, cert, chain, errors) => { return true; };
                using (var client = new HttpClient(httpClientHandler))
                {
                    var reqUri = baseUri + "ShoppingCartItems";
                    var json = await client.GetStringAsync(new Uri(reqUri));
                    return JsonConvert.DeserializeObject<int>(json);
                }
            }
        }

        public async Task<Product> GetProductAsync(int id)
        {
            using (var httpClientHandler = new HttpClientHandler())
            {
                httpClientHandler.ServerCertificateCustomValidationCallback = (message, cert, chain, errors) => { return true; };
                using (var client = new HttpClient(httpClientHandler))
                {
                    var reqUri = baseUri + "Product/" + id + "/";
                    var json = await client.GetStringAsync(new Uri(reqUri));
                    return JsonConvert.DeserializeObject<Product>(json);
                }
            }
        }

        public async Task<IList<Product>> GetProductsAsync()
        {
            using (var httpClientHandler = new HttpClientHandler())
            {
                httpClientHandler.ServerCertificateCustomValidationCallback = (message, cert, chain, errors) => { return true; };
                using (var client = new HttpClient(httpClientHandler))
                {
                    var reqUri = baseUri + "Products/";
                    var json = await client.GetStringAsync(new Uri(reqUri));
                    return JsonConvert.DeserializeObject<IList<Product>>(json);
                }
            }
        }

        public async Task<ShoppingCart> GetShoppingCart()
        {
            using(var httpClientHandler = new HttpClientHandler())
            {
                httpClientHandler.ServerCertificateCustomValidationCallback = (message, cert, chain, errors) => { return true; };
                using(var client = new HttpClient(httpClientHandler))
                {
                    var reqUri = baseUri + "ShoppingCart/";
                    var json = await client.GetStringAsync(new Uri(reqUri));
                    return JsonConvert.DeserializeObject<ShoppingCart>(json);
                }
            }
        }

        public async Task<ShoppingCart> RemoveEntryFromShoppingCart(ShoppingCartEntry entry)
        {
            using(var httpClientHandler = new HttpClientHandler())
            {
                httpClientHandler.ServerCertificateCustomValidationCallback = (message, cert, chain, errors) => { return true; };
                using (var client = new HttpClient(httpClientHandler))
                {
                    var reqUri = baseUri + "ShoppingCart/Remove/" + entry.Product.Id;
                    var json = await client.PutAsync(new Uri(reqUri), new StringContent(entry.Product.Id.ToString(), System.Text.Encoding.UTF8, "application/json"));
                    return null;
                }
            }
        }

        public async Task<Product> UpdateProductAsync(Product product)
        {
            using (var httpClientHandler = new HttpClientHandler())
            {
                httpClientHandler.ServerCertificateCustomValidationCallback = (message, cert, chain, errors) => { return true; };
                using (var client = new HttpClient(httpClientHandler))
                {
                    var reqUri = baseUri + "Product/Update/" + product.Id;
                    var json = await client.PutAsync(new Uri(reqUri), new StringContent(JsonConvert.SerializeObject(product), System.Text.Encoding.UTF8, "application/json"));
                    return null;
                }
            }
        }
    }
}
