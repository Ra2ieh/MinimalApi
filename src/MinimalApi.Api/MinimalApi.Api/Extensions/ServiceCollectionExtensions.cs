using MediatR;
using MinimalApi.Api.Contracts;

namespace MinimalApi.Api.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services,
            WebApplicationBuilder builder)
        {
            // ...

            builder.Services.AddAllModules(typeof(Program));
            builder.Services.AddMediatR(typeof(Program));
            builder.Services.AddAutoMapper(typeof(Program));
            return services;
        }

        private static void AddAllModules(this IServiceCollection services, params Type[] types)
        {
            // Using the `Scrutor` to add all of the application's modules at once.
            services.Scan(scan =>
                scan.FromAssembliesOf(types)
                    .AddClasses(classes => classes.AssignableTo<IModule>())
                    .AsImplementedInterfaces()
                    .WithSingletonLifetime());
        }
    }
}
