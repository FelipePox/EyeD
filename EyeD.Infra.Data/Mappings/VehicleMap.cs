using EyeD.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EyeD.Infra.Data.Mappings
{
    public sealed class VehicleMap : IEntityTypeConfiguration<Vehicles>
    {
        public void Configure(EntityTypeBuilder<Vehicles> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Ignore(v => v.Notifications);

            builder.OwnsOne(c => c.Plate, nome =>
             {
                 nome.Property(n => n.Texto)
                 .HasColumnName("Placa")
                 .HasColumnType("varchar(7)");

                 nome.Ignore(n => n.Notifications);
             });

            builder.OwnsOne(c => c.Model, nome =>
            {
                nome.Property(n => n.Texto)
                .HasColumnName("Modelo")
                .HasColumnType("varchar(60)");

                nome.Ignore(n => n.Notifications);
            });

            builder.OwnsOne(c => c.ModelYear, nome =>
            {
                nome.Property(n => n.Texto)
                .HasColumnName("ModeloAno")
                .HasColumnType("varchar(4)");

                nome.Ignore(n => n.Notifications);
            });

            builder.OwnsOne(c => c.Brand, nome =>
            {
                nome.Property(n => n.Texto)
                .HasColumnName("Marca")
                .HasColumnType("varchar(60)");

                nome.Ignore(n => n.Notifications);
            });

            builder.OwnsOne(c => c.ReferenceDocument, refe =>
            {
                refe.Property(n => n.Texto)
                .HasColumnName("ReferenceDocument")
                .HasColumnType("varchar(15)");

                refe.Ignore(n => n.Notifications);
            });
        }
    }
}
