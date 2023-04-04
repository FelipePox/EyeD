using EyeD.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace EyeD.WebApi.Configurations
{
    public static class DataBaseConfig
    {
        public static void AddDatabaseConfiguration(this IServiceCollection services , IConfiguration configuration) {

            if (services is null) throw new ArgumentNullException(nameof(services));
            string connection = configuration.GetConnectionString("EyeDConnection")!;

            services.AddDbContext<EyeDContext>(options =>
            {
                options.UseMySql(connection, ServerVersion.AutoDetect(connection),
                    options => options.EnableRetryOnFailure())
                .EnableSensitiveDataLogging();
            });

        }
    }
}
