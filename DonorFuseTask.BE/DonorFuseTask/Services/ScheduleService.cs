using DonorFuseTask.Repositories.Interfaces;
using DonorFuseTask.Services.Interfaces;

namespace DonorFuseTask.Services;

public class ScheduleService : IScheduleService
{
    private readonly IScheduleRepository _scheduleRepository;

    public ScheduleService(IScheduleRepository scheduleRepository)
    {
        _scheduleRepository = scheduleRepository;
    }
}