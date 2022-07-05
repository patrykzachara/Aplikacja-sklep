using System.Collections.Generic;
using WPF.Models;

namespace WPF.Services
{
    public interface IShopService
    {
        void AddShop(Shop shop);
        Shop GetShopById(int id);
        IEnumerable<Shop> GetShops();
    }
}