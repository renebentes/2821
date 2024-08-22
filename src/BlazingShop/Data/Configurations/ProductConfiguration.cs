using BlazingShop.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BlazingShop.Data.Configurations;

public class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.ToTable(nameof(Product));

        builder.HasKey(p => p.Id);

        builder.Property(p => p.Title)
               .IsRequired();

        builder.Property(p => p.Price)
               .IsRequired();

        builder.HasOne(p => p.Category)
               .WithMany();
    }
}
