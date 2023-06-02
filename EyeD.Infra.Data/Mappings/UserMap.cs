using EyeD.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EyeD.Infra.Data.Mappings;

public sealed class UserMap : IEntityTypeConfiguration<User>
{

    public void Configure(EntityTypeBuilder<User> builder) 
    { 
       builder.HasKey(c => c.Id);

       builder.OwnsOne(c => c.Nome, nome =>
        {
            nome.Property(n => n.Texto)
            .HasColumnName("Nome")
            .HasColumnType("varchar(60)");

            nome.Ignore(n => n.Notifications);
        });

        builder.OwnsOne(c => c.Email, email =>
        {
            email.Property(e => e.Endereco)
            .HasColumnName("Email")
            .HasColumnType("varchar(100)");

            email.Ignore(e => e.Notifications);
        });

        builder.OwnsOne(c => c.Password, senha =>
        {
            senha.Property(s => s.Texto)
            .HasColumnName("Senha")
            .HasColumnType("varchar(20)");

            senha.Ignore(s => s.Notifications);
        });

        builder.Ignore(c => c.Notifications);
    }
}
