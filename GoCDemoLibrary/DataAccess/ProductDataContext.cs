using GoCDemoLibrary.Models;
using Microsoft.EntityFrameworkCore;

namespace GoCDemoLibrary.DataAccess
{
    public class ProductDataContext : DbContext
    {
        public ProductDataContext(DbContextOptions<ProductDataContext> options) : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<ProductType> ProductTypes { get; set; }
    }
}
