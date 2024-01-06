using Commerce.Products.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Commerce.Products.Infrastructure.Database.Configurations
{
    public class BrandConfiguration : IEntityTypeConfiguration<Brand>
    {
        public void Configure(EntityTypeBuilder<Brand> builder)
        {
            builder.ToTable("brand");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnName("id").HasColumnType("UUID").IsRequired().ValueGeneratedOnAdd();
            builder.Property(x => x.Name).HasColumnName("name").HasColumnType("VARCHAR(75)").IsRequired();
            builder.Property(x => x.CreatedAt).HasColumnName("created_at").HasColumnType("TIMESTAMP WITH TIME ZONE").ValueGeneratedOnAdd().IsRequired();
            builder.Property(x => x.UpdatedAt).HasColumnName("updated_at").HasColumnType("TIMESTAMP WITH TIME ZONE").ValueGeneratedOnUpdate();
        }
    }
}
