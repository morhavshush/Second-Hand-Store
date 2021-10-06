using Entities;
using LibraryData;
using Microsoft.EntityFrameworkCore;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Services.ServicesFolder
{
    public class ProductService : IProductService
    {
        private readonly LibraryContext _context;

        public ProductService(LibraryContext context)
        {
            _context = context;
        }
        public void AddNewProduct(ProductModel productModel, string userName)
        {
            if (productModel == null)
                return;

            UserModel owner = _context.Users.FirstOrDefault(ow => ow.UserName == userName);
            if (owner == default)
                return;

            _context.Products.Add(productModel);

            productModel.Owner = owner;
            _context.SaveChanges();
        }
        public ProductModel GetProductById(int id)
        {
            return _context.Products.Include("Owner").Include("User").FirstOrDefault(p => p.Id == id);
        }

        #region Get Products
        public IEnumerable<ProductModel> GetAllProducts()
        {
            return _context.Products.Include("Owner").Include("User").Where(p => p.StateProduct == State.Available);
        }
        public IEnumerable<ProductModel> GetProductsOrderByDate()
        {
            return GetAllProducts().OrderBy(p => p.DateUpload);
        }
        public IEnumerable<ProductModel> GetProductsOrderByTitle()
        {
            return GetAllProducts().OrderBy(p => p.Title);
        }
        #endregion
       
        #region Shopping Cart
        public IEnumerable<ProductModel> GetProductsInShoppingCartOfUser(string userName)
        {
            var user = _context.Users.FirstOrDefault(ow => ow.UserName == userName);
            return _context.Products.Include("Owner").Include("User").Where(p => p.User == user && p.StateProduct == State.InShoppingCart);
        }
        public void AddToCart(int productId, string userName)
        {
            var productModel = _context.Products.Include("Owner").Include("User").FirstOrDefault(p => p.Id == productId);

            if (productModel == null)
                return;

            UserModel user = _context.Users.FirstOrDefault(ow => ow.UserName == userName);

            productModel.User = user;
            productModel.TimeInCart = DateTime.Now;
            productModel.StateProduct = State.InShoppingCart;
            _context.Products.Update(productModel);

            _context.SaveChanges();
        }
        public void RemoveFromCart(int productId)
        {
            var productModel = _context.Products.Include("Owner").Include("User").FirstOrDefault(p => p.Id == productId);

            if (productModel == null)
                return;

            productModel.User = null;
            productModel.StateProduct = State.Available;
            productModel.TimeInCart = null;
            _context.Products.Update(productModel);

            _context.SaveChanges();
        }
        public void BuyAllCart(List<ProductModel> productsList)
        {
            foreach (var item in productsList)
            {
                item.StateProduct = State.Buy;              
            }
            _context.Products.UpdateRange(productsList);
            _context.SaveChanges();
        }
        #endregion

        public void CheckExpirationDate()
        {
            List<ProductModel> productsToRemoveList = new List<ProductModel>();
            foreach (var item in _context.Products.Where(p => p.StateProduct == State.InShoppingCart))
            {
                if (item.TimeInCart != default && item.TimeInCart + TimeSpan.FromSeconds(20) < DateTime.Now)
                    productsToRemoveList.Add(item);
            }
            if (productsToRemoveList != null)
            {
                foreach (var item in productsToRemoveList)
                {
                    item.StateProduct = State.Available;
                    item.User = null;
                    item.TimeInCart = null;
                }
                _context.Products.UpdateRange(productsToRemoveList);
                _context.SaveChanges();
            }
        }
    }
}
