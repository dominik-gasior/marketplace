using Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Entities;

public class PriceProductConfiguration: IEntityTypeConfiguration<PriceProduct>
{
    public void Configure(EntityTypeBuilder<PriceProduct> builder)
    {
        builder.ToTable("PriceProducts");

        builder.HasKey(pp => pp.Id);
        builder.Property(pp => pp.Id)
            .ValueGeneratedNever();

        builder.Property(pp => pp.ProductId).IsRequired();
        builder.Property(pp => pp.Category).IsRequired();
        builder.Property(pp => pp.CreatedTime).IsRequired();
        builder.Property(pp => pp.UpdatedTime).IsRequired();

        builder.OwnsOne(pp => pp.MedianPrice, n =>
        {
            n.Property(x => x.Value).
                HasColumnName(nameof(PriceProduct.MedianPrice)).
                IsRequired();
        });

        builder.OwnsOne(pp => pp.LowestPrice, n =>
        {
            n.Property(x => x.Value).
                HasColumnName(nameof(PriceProduct.LowestPrice)).
                IsRequired();
        });

        builder.OwnsOne(pp => pp.HighestPrice, n =>
        {
            n.Property(x => x.Value).
                HasColumnName(nameof(PriceProduct.HighestPrice)).
                IsRequired();
        });

        builder.OwnsOne(pp => pp.ChangePrice, n =>
        {
            n.Property(x => x.Value).
                HasColumnName(nameof(PriceProduct.ChangePrice)).
                IsRequired();
        });
    }
}