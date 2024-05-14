using DonorFuseTask.Repositories;
using DonorFuseTask.Repositories.Interfaces;

namespace DonorFuseTask.Registries;

public static class RepositoryRegistry
{
    public static void AddRepositories(this IServiceCollection services)
    {
        services.AddScoped<IDonorRepository, DonorRepository>();
    }
}