using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightAppEliasGryp.Models
{
    public interface ICatalogDataService
    {
        Task<IList<Product>> GetProductsAsync();
        Task<Product> GetProductAsync(int id);
        Task<IList<Product>> AddProductToShoppingCart(Product product);
    }
}
