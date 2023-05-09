using EyeD.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EyeD.Infra.Data.Mappings;


public sealed class PeopleMap : IEntityTypeConfiguration<People>
{
    public void Configure(EntityTypeBuilder<People> builder)
    {
        builder.HasKey(c => c.Id);

        builder.OwnsOne(c => c.Name, nome =>
        {                             
            nome.Property(n => n.PrimeiroNome)
            .HasColumnName("FirstName")
            .HasColumnType("varchar(20)");

            nome.Ignore(n => n.Notifications);
        });

        builder.OwnsOne(c => c.Name, nome =>
        {
            nome.Property(n => n.SegundoNome)
            .HasColumnName("SecondName")
            .HasColumnType("varchar(60)");

            nome.Ignore(n => n.Notifications);
        });

        builder.OwnsOne(c => c.Name, nome =>
        {
            nome.Property(n => n.TerceiroNome)
            .HasColumnName("ThirdName")
            .HasColumnType("varchar(20)");

            nome.Ignore(n => n.Notifications);
        });

        builder.OwnsOne(c => c.FaceId, nome =>
        {
            nome.Property(n => n.Texto)
            .HasColumnName("FaceId")
            .HasColumnType("varchar(35)");

            nome.Ignore(n => n.Notifications);
        });

        builder.OwnsOne(c => c.ImageId, nome =>
        {
            nome.Property(n => n.Texto)
            .HasColumnName("ImageId")
            .HasColumnType("varchar(35)");

            nome.Ignore(n => n.Notifications);
        });
        builder.OwnsOne(c => c.ExternalImageId, nome =>
        {
            nome.Property(n => n.Texto)
            .HasColumnName("ExternalImageId")
            .HasColumnType("varchar(100)");

            nome.Ignore(n => n.Notifications);
        });

        builder.OwnsOne(c => c.ReferenceDocument, nome =>
        {
            nome.Property(n => n.Texto)
            .HasColumnName("ReferenceDocument")
            .HasColumnType("varchar(16)");

            nome.Ignore(n => n.Notifications);
        });

        builder.OwnsOne(c => c.Imagem, image =>
        {
            image.Property(n => n.Texto)
            .HasColumnName("Imagem")
            .HasColumnType("varchar(200)");

            image.Ignore(n => n.Notifications);
        });

        builder.Ignore(n => n.Notifications);
    }
}