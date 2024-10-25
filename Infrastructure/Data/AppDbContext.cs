using Domain.Common;
using Domain.Entities;
using Infrastructure.Data.Configurations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
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
        public DbSet<Category> Categories { get; set; }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            
        }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Áp dụng cấu hình dùng chung cho các bảng kế thừa
            modelBuilder.ApplyConfiguration(new AuditableEntityConfiguration<Product>());
            modelBuilder.ApplyConfiguration(new AuditableEntityConfiguration<Category>());

            // Table Products            
            modelBuilder.ApplyConfiguration(new ProductEntityConfiguration());

            // Table Categories
            modelBuilder.ApplyConfiguration(new CategoryEntityConfiguration());


            base.OnModelCreating(modelBuilder);
        }
    }
}
