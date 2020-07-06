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
                    var reqUri = baseUri + "ShoppingCart/";
                    var productJson = JsonConvert.SerializeObject(product);
                    var json = await client.PostAsync(new Uri(reqUri), new StringContent(productJson, System.Text.Encoding.UTF8, "application/json"));
                    return null;
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
    }
}
