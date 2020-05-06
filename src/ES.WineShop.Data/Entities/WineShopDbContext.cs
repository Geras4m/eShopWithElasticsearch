using Microsoft.EntityFrameworkCore;
using System;

namespace ES.WineShop.Data.Entities
{
    public class WineShopDbContext : DbContext
    {
        public WineShopDbContext(DbContextOptions<WineShopDbContext> options)
            : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>()
                .HasKey(b => b.Id)
                .HasName("PrimaryKey_ProductId");

            modelBuilder.Entity<Product>()
               .Property<DateTime>("UpdatedOn")
               .HasDefaultValueSql("now()");

            modelBuilder.Entity<Product>()
                .Property(b => b.IsFreeShipping)
                .HasDefaultValue(false);
        }
    }
}
