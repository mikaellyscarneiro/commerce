using Commerce.Products.Domain.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Commerce.Products.Infrastructure.Database.Configurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("product");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnName("id").HasColumnType("UUID").IsRequired().ValueGeneratedOnAdd();
            builder.Property(x => x.Name).HasColumnName("name").HasColumnType("VARCHAR(75)").IsRequired();
            builder.Property(x => x.Description).HasColumnName("description").HasColumnType("VARCHAR(255)").IsRequired();
            builder.Property(x => x.Sku).HasColumnName("sku").HasColumnType("VARCHAR(36)").IsRequired();
            builder.Property(x => x.Quantity).HasColumnName("quantity").HasColumnType("BIGINT").IsRequired();
            builder.Property(x => x.BrandId).HasColumnName("brand_id").HasColumnType("UUID").IsRequired();
            builder.Property(x => x.CategoryId).HasColumnName("category_id").HasColumnType("UUID").IsRequired();
            builder.Property(x => x.CreatedAt).HasColumnName("created_at").HasColumnType("TIMESTAMP WITH TIME ZONE").ValueGeneratedOnAdd().IsRequired();
            builder.Property(x => x.UpdatedAt).HasColumnName("updated_at").HasColumnType("TIMESTAMP WITH TIME ZONE").ValueGeneratedOnUpdate();

            builder.HasOne(x => x.Category).WithMany(x => x.Products).HasForeignKey(x => x.CategoryId);
            builder.HasOne(x =>x.Brand).WithMany(x => x.Products).HasForeignKey(x => x.BrandId);
        }
    }
}
