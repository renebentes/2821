using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BlazingShop.Data.Configurations;

public class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.ToTable(nameof(Product));

        builder.HasKey(p => p.Id);

        builder.Property(p => p.Title)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(p => p.Description)
            .IsRequired(false);

        builder.Property(p => p.Price)
            .IsRequired()
            .HasColumnType("MONEY");

        builder.Property(p => p.Image)
            .IsRequired(false);

        builder.HasOne(p => p.Category)
            .WithMany();
    }
}
