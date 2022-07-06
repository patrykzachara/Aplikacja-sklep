using System;
using System.Collections.Generic;
using System.Linq;
using WPF.Models;

namespace WPF.Services
{
    public class ProductService : IProductService
    {
        private readonly DatabaseContext.AppContext _appContext;

        public ProductService(DatabaseContext.AppContext appContext)
        {
            _appContext = appContext;
        }
        /// <summary>
        /// Getting products from database
        /// </summary>
        /// <param name="shopId">Shop id</param>
        /// <returns>Products from shop</returns>
        public IEnumerable<Product> GetProducts(int shopId)
        {
            var products = _appContext.Products.Where(x => x.ShopId == shopId);
            return products;
        }
        /// <summary>
        /// Getting product from database
        /// </summary>
        /// <param name="productid">product id</param>
        /// <param name="shopId">shop id</param>
        /// <returns>Product</returns>
        public Product GetProductBiId(int productid, int shopId)
        {
            return _appContext.Products.Where(x => x.ShopId == shopId).Single(x => x.Id == productid);
        }
        /// <summary>
        /// Adding product to database
        /// </summary>
        /// <param name="product">Product model to add</param>
        public void AddProduct(Product product)
        {
            product.LastUpdateTime = DateTime.UtcNow;
            _appContext.Products.Add(product);
            _appContext.SaveChanges();
        }
        /// <summary>
        /// Updating products quantity
        /// </summary>
        /// <param name="productid">product id</param>
        /// <param name="shopId">shop id</param>
        /// <param name="newQuantity">new quantity</param>
        public void UpdateQuantity(int productid, int shopId, int newQuantity)
        {
            var product = GetProductBiId(productid, shopId);
            product.Quantity = newQuantity;
            product.LastUpdateTime = DateTime.UtcNow;
            _appContext.Products.Update(product);
            _appContext.SaveChanges();
        }
        /// <summary>
        /// Updating product price
        /// </summary>
        /// <param name="productid">product id</param>
        /// <param name="shopId">shop id</param>
        /// <param name="newQuantity">new quantity</param>
        public void UpdatePrice(int productid, int shopId, decimal newPrice)
        {
            var product = GetProductBiId(productid, shopId);
            product.Price = newPrice;
            product.LastUpdateTime = DateTime.UtcNow;
            _appContext.Products.Update(product);
            _appContext.SaveChanges();
        }
    }
}
