using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF.Models;

namespace WPF.DatabaseContext
{
    public class AppContext : DbContext
    {
        public DbSet<Adress> Adresses { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductSale> ProductSales { get; set; }
        public DbSet<Shop> Shops { get; set; }
        public DbSet<SummaryOfCustomerPurchases> SummaryOfCustomerPurchases { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Connection string");
        }
    }
}
