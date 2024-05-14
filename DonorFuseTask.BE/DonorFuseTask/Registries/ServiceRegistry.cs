using DonorFuseTask.Services;
using DonorFuseTask.Services.Interfaces;

namespace DonorFuseTask.Registries;

public static class ServiceRegistry
{
    public static void AddServices(this IServiceCollection services)
    {
        services.AddScoped<IDonorService, DonorService>();
        services.AddScoped<IDonationService, DonationService>();
        services.AddScoped<IScheduleService, ScheduleService>();
    }
}