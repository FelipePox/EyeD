using EyeD.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EyeD.Infra.Data.Mappings;

public sealed class HMDMap : IEntityTypeConfiguration<HMDs>
{
    public void Configure(EntityTypeBuilder<HMDs> builder)
    {
        builder.HasKey(c => c.Id);

        builder.OwnsOne(c => c.SKU, nome =>
        {
            nome.Property(n => n.Texto)
            .HasColumnName("SKU")
            .HasColumnType("varchar(200)");

            nome.Ignore(n => n.Notifications);
        });

        builder.OwnsOne(c => c.IPV4, nome =>
        {
            nome.Property(n => n.Texto)
            .HasColumnName("IPV4")
            .HasColumnType("varchar(15)");

            nome.Ignore(n => n.Notifications);
        });

        builder.OwnsOne(c => c.Description, nome =>
        {
            nome.Property(n => n.Texto)
            .HasColumnName("Description")
            .HasColumnType("varchar(120)");

            nome.Ignore(n => n.Notifications);
        });

        builder.OwnsOne(c => c.MacAddress, nome =>
        {
            nome.Property(n => n.Texto)
            .HasColumnName("MacAdress")
            .HasColumnType("varchar(17)");

            nome.Ignore(n => n.Notifications);
        });

        builder.Ignore(n => n.Notifications);
    }
}

