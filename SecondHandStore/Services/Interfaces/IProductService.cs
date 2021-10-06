using Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Interfaces
{
    public interface IProductService
    {
        void AddNewProduct(ProductModel productModel, string userName);
        ProductModel GetProductById(int id);
        IEnumerable<ProductModel> GetAllProducts();
        IEnumerable<ProductModel> GetProductsOrderByDate();
        IEnumerable<ProductModel> GetProductsOrderByTitle();   
        IEnumerable<ProductModel> GetProductsInShoppingCartOfUser(string userName);
        void AddToCart(int productId, string userName);
        void RemoveFromCart(int productId);
        void BuyAllCart(List<ProductModel> productsList);
        void CheckExpirationDate();
    }
}
