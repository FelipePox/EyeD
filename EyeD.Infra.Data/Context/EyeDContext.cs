using EyeD.Domain.Entities;
using EyeD.Infra.Data.Extensions;
using Flunt.Notifications;
using Microsoft.EntityFrameworkCore;

namespace EyeD.Infra.Data.Context;

public sealed class EyeDContext : DbContext
{
    public EyeDContext(DbContextOptions<EyeDContext> options) : base(options)
    {
        ChangeTracker.AutoDetectChangesEnabled = true;
    }

    public DbSet<User> Users => Set<User>();
    public DbSet<HMDs> HMDs => Set<HMDs>();
    public DbSet<People> Peoples => Set<People>();
    public DbSet<Vehicles> Vehicles => Set<Vehicles>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Ignore<List<Notification>>();
        modelBuilder.ConfigureMappings();

        base.OnModelCreating(modelBuilder);
    }
}
