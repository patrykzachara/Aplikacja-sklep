using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF.Models;

namespace WPF.Services
{
    public class ShopService : IShopService
    {
        private readonly DatabaseContext.AppContext _context;

        public ShopService(DatabaseContext.AppContext context)
        {
            _context = context;
        }
        public IEnumerable<Shop> GetShops()
        {
            return _context.Shops.Include(x => x.Adress);
        }
        public void AddShop(Shop shop)
        {
            _context.Shops.Add(shop);
            _context.SaveChanges();
        }
        public Shop GetShopById(int id)
        {
            return _context.Shops.Include(x => x.Adress).Where(x => x.Id == id).Single();
        }
    }
}
