using Microsoft.Extensions.DependencyInjection;
using VehicleFleet.Application.Aplication.Services;
using VehicleFleet.Domain.Services;

namespace VehicleFleet.Ioc;

public static class DependencyResolver
{
    public static IServiceCollection AddApplicationServices(IServiceCollection services)
    {
        services.AddScoped<IVehicleFactory, VehicleFactory>();
        services.AddScoped<IVehicleService, VehicleService>();

        return services;
    }
}
