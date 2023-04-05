using EyeD.Application.Interfaces;
using EyeD.Application.Services;
using EyeD.Domain.Interfaces;
using EyeD.Infra.Data.Context;
using EyeD.Infra.Data.Interfaces;
using EyeD.Infra.Data.Repositories;
using EyeD.Infra.Data.Transactions;
using Microsoft.Extensions.DependencyInjection;

namespace EyeD.Infra.CrossCutting.IoC
{
    public static class NativeInjector
    {
       public static void RegisterServices(this IServiceCollection services)
        {
            services.RegisterInfraDependencyInjection();
            services.RegisterApplicationDependencyInjection();

        }

        public static void RegisterApplicationDependencyInjection(this IServiceCollection services)
        {
            services.AddScoped<IUserServices, UserServices>();
            services.AddScoped<IPeopleServices, PeopleServices>();
            services.AddScoped<IVehicleServices, VehicleServices>();
            services.AddScoped<IHMDServices, HMDServices>();

        }

        public static void RegisterInfraDependencyInjection(this IServiceCollection services) 
        {
            services.AddScoped<EyeDContext>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IPeopleRepository, PeopleRepository>();
            services.AddScoped<IVehicleRepository, VehicleRepository>();
            services.AddScoped<IHMDRepository, HMDRepository>();
        }
    }
}
