using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductLog> ProductLogs { get; set; }
        public DbSet<Category> Categories { get; set; }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProductLog>()
                .HasOne(p => p.Product) // Liên kết ProductLog với Product
                .WithMany(p => p.ProductLogs) // Một Product có nhiều Log
                .HasForeignKey(p => p.ProductId) // Khóa ngoại
                .OnDelete(DeleteBehavior.Cascade); // Hành vi xóa (Cascade để xóa các log nếu Product bị xóa)

            modelBuilder.Entity<Product>()
                .HasOne(p => p.Category)
                .WithMany()
                .HasForeignKey(p => p.CategoryId)
                .OnDelete(DeleteBehavior.Cascade);

            base.OnModelCreating(modelBuilder);


        }
    }
}
