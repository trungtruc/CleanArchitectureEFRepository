using Domain.Common;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data.Configurations
{
    public class AuditableEntityConfiguration<TEntity> : IEntityTypeConfiguration<TEntity> where TEntity : AuditableEntity
    {
        public void Configure(EntityTypeBuilder<TEntity> builder)
        {
            // Cấu hình các thuộc tính dùng chung
            builder.Property(e => e.CreatedDate)
                   .HasColumnType("datetime")
                   .HasDefaultValueSql("GETDATE()");

            builder.Property(e => e.LastModifiedDate)
                   .HasColumnType("datetime")
                   .IsRequired(false);

            builder.Property(e => e.DeletedDate)
                   .HasColumnType("datetime")
                   .IsRequired(false);
            builder.Property(e => e.LastModifiedBy)
                .HasDefaultValue("");
            builder.Property(e => e.DeletedBy)
                .HasDefaultValue("");
        }
    }
}
