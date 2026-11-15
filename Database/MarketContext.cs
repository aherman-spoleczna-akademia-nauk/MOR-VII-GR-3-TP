using Mappery_Relacyjno_Obiektowe.Database.Entities;
using Microsoft.EntityFrameworkCore;

namespace Mappery_Relacyjno_Obiektowe.Database;

public class MarketContext : DbContext
{
    public MarketContext(DbContextOptions<MarketContext> options) : base(options) { }

    public required virtual DbSet<Category> Categories { get; set; }
    public required virtual DbSet<Brand> Brands { get; set; }
    public required virtual DbSet<Product> Products { get; set; }
    public required virtual DbSet<Photo> Photos { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Product>().Property(p => p.StandardPrice).HasPrecision(18, 2);
        modelBuilder.Entity<Product>().Property(p => p.PromotionPrice).HasPrecision(18, 2);
        modelBuilder.Entity<Product>().HasOne(p => p.Category);
        modelBuilder.Entity<Product>().HasOne(p => p.Brand);
        modelBuilder.Entity<Product>().HasMany(p => p.Photos).WithOne(p => p.Product).HasForeignKey(p => p.ProductId);  
    }
}
