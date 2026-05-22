using Microsoft.EntityFrameworkCore;
using EShop.DataLayer.EfClasses;

namespace EShop.DataLayer.EfCode
{
    public class EfDbContext : DbContext
    {
        public EfDbContext(DbContextOptions<EfDbContext> options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Order>().Ignore(p => p.OrderNumber);
            modelBuilder.Entity<Product>().ToTable("Products");
            modelBuilder.Entity<Product>().HasQueryFilter(p => !p.SoftDeleted);
            modelBuilder.Entity<Tag>().HasKey(p => p.TagId);
            modelBuilder.Entity<Tag>().Property(p => p.TagId).IsRequired();
            modelBuilder.Entity<Tag>().Property(p => p.TagId).HasMaxLength(40);
        }
        public DbSet<Product> Products { get; set; }
        public DbSet<PriceOffer> PriceOffers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Tag> Tag { get; set; }
    }
}
