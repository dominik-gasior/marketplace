using Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Entities;

public class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.ToTable("Products");

        builder.HasKey(p => p.Id);
        builder.Property(p => p.Id)
            .ValueGeneratedNever();

        builder.OwnsOne(p => p.Name, n =>
        {
            n.Property(x => x.Value).
                HasColumnName("Name").
                IsRequired();
        });

        builder.Property(p => p.Unit).IsRequired();
        builder.Property(p => p.Category).IsRequired();
    }
}