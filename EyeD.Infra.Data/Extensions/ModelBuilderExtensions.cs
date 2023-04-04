using EyeD.Infra.Data.Mappings;
using Microsoft.EntityFrameworkCore;

namespace EyeD.Infra.Data.Extensions
{
   public static class ModelBuilderExtensions
    {
        public static void ConfigureMappings(this ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserMap());
            modelBuilder.ApplyConfiguration(new PeopleMap());
            modelBuilder.ApplyConfiguration(new HMDMap());
            modelBuilder.ApplyConfiguration(new VehicleMap());
        }
    }
}
