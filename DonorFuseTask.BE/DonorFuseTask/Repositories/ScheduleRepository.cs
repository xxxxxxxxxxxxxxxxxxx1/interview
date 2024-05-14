using DonorFuseTask.Context;
using DonorFuseTask.Repositories.Interfaces;

namespace DonorFuseTask.Repositories;

public class ScheduleRepository : IScheduleRepository
{
    private readonly ApplicationDbContext _dbContext;

    public ScheduleRepository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }
}