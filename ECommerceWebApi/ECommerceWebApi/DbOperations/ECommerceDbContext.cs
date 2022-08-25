using System;
using ECommerceWebApi.Model;
using Microsoft.EntityFrameworkCore;

namespace ECommerceWebApi.DbOperations
{
	public class ECommerceDbContext : DbContext
	{
        public ECommerceDbContext(DbContextOptions<ECommerceDbContext> options) : base(options)
        { }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Basket> Basket { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>()
            .HasOne(p => p.Category)
            .WithMany(c => c.Products);

            
        }
    }
}