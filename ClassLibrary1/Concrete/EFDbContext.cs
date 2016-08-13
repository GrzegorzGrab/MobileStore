using MobileStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileStore.Domain.Concrete
{
    public class EFDbContext : DbContext
    {
        public DbSet<Producer> Producers { get; set; }
        public DbSet<ProductType> ProductTypes { get; set; }
        public DbSet<ProductModel> ProductModels { get; set; }
        public DbSet<Seller> Sellers { get; set; }
        public DbSet<SimLocker> SimLockers { get; set; }
        public DbSet<Commodity> Commodities { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<Sale> Sales { get; set; }
    }
}
