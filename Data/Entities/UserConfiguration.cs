using Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Entities;

public class UserConfiguration: IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("Users");

        builder.HasKey(u => u.Id);
        builder.Property(u => u.Id)
            .ValueGeneratedNever();

        builder.OwnsOne(u => u.FirstName, n =>
        {
            n.Property(x => x.Value).
                HasColumnName(nameof(User.FirstName)).
                IsRequired();
        });

        builder.OwnsOne(u => u.LastName, n =>
        {
            n.Property(x => x.Value).
                HasColumnName(nameof(User.LastName)).
                IsRequired();
        });

        builder.OwnsOne(u => u.Email, n =>
        {
            n.Property(x => x.Value).
                HasColumnName(nameof(User.Email)).
                IsRequired();
        });

        builder.OwnsOne(u => u.Phone, n =>
        {
            n.Property(x => x.Value).
                HasColumnName(nameof(User.Phone)).
                IsRequired();
        });

        builder.OwnsOne(u => u.Address, n =>
        {
            n.Property(x => x.Street);
            n.Property(x => x.City);
            n.Property(x => x.State);
            n.Property(x => x.ZipCode);
        });

        builder.OwnsOne(u => u.Password, n =>
        {
            n.Property(x => x.Hash).
                HasColumnName(nameof(User.Password)).
                IsRequired();
        });

        builder.Property(u => u.CreatedAt).IsRequired();
        builder.Property(u => u.UpdatedAt).IsRequired();
        builder.Property(u => u.IsActive).IsRequired();
        builder.Property(u => u.IsDeleted).IsRequired();
        builder.Property(u => u.IsSeller).IsRequired();
    }
}