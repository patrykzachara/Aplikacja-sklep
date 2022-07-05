using System.Collections.Generic;
using WPF.Models;

namespace WPF.Services
{
    public interface IProductService
    {
        void AddProduct(Product product);
        Product GetProductBiId(int productid, int shopId);
        IEnumerable<Product> GetProducts(int shopId);
        void UpdatePrice(int productid, int shopId, decimal newPrice);
        void UpdateQuantity(int productid, int shopId, int newQuantity);
    }
}