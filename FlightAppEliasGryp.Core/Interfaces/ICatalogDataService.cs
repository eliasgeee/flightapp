﻿using FlightAppEliasGryp.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FlightAppEliasGryp.Core.Interfaces
{
    public interface ICatalogDataService
    {
        Task<IList<Product>> GetProductsAsync();
        Task<Product> GetProductAsync(int id);
        Task<IList<Product>> AddProductToShoppingCart(Product product);
        Task<int> GetAmountOfItemsInShoppingCartAsync();
        Task<ShoppingCart> GetShoppingCart();
        Task<ShoppingCart> RemoveEntryFromShoppingCart(ShoppingCartEntry entry);
        Task<int> ChangeEntryAmount(ShoppingCartEntry entry, int amount);
        Task<Product> UpdateProductAsync(Product product);
        Task<Product> DeleteProductAsync(Product product);
        Task<Product> AddPromotionToProduct(Product product, Promotion promotion);
    }
}
