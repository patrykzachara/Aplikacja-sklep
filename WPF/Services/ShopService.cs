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
        /// <summary>
        /// Gettong shops from database
        /// </summary>
        /// <returns>shops</returns>
        public IEnumerable<Shop> GetShops()
        {
            return _context.Shops.Include(x => x.Adress);
        }
        /// <summary>
        /// Adding shop to database
        /// </summary>
        /// <param name="shop">Shop model to add</param>
        public void AddShop(Shop shop)
        {
            _context.Shops.Add(shop);
            _context.SaveChanges();
        }
        /// <summary>
        /// Getting shop model from database
        /// </summary>
        /// <param name="id">Shop id</param>
        /// <returns>Shop model</returns>
        public Shop GetShopById(int id)
        {
            return _context.Shops.Include(x => x.Adress).Where(x => x.Id == id).Single();
        }
    }
}
