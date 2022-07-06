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
        public IEnumerable<Product> GetProducts(int shopId)
        {
            var products = _appContext.Products.Where(x => x.ShopId == shopId);
            return products;
        }
        public Product GetProductBiId(int productid, int shopId)
        {
            return _appContext.Products.Where(x => x.ShopId == shopId).Single(x => x.Id == productid);
        }
        public void AddProduct(Product product)
        {
            product.LastUpdateTime = DateTime.UtcNow;
            _appContext.Products.Add(product);
            _appContext.SaveChanges();
        }
        public void UpdateQuantity(int productid, int shopId, int newQuantity)
        {
            var product = GetProductBiId(productid, shopId);
            product.Quantity = newQuantity;
            product.LastUpdateTime = DateTime.UtcNow;
            _appContext.Products.Update(product);
            _appContext.SaveChanges();
        }
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
