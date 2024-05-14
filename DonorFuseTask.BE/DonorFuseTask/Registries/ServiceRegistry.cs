using DonorFuseTask.Repositories;
using DonorFuseTask.Repositories.Interfaces;

namespace DonorFuseTask.Registries;

public static class ServiceRegistry
{
    public static void AddServices(this IServiceCollection services)
    {
        services.AddScoped<IDonorRepository, DonorRepository>();
    }
}