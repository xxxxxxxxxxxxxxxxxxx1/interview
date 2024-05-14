using DonorFuseTask.Context;
using DonorFuseTask.Repositories.Interfaces;

namespace DonorFuseTask.Repositories;

public class DonationRepository : IDonationRepository
{
    private readonly ApplicationDbContext _dbContext;
    
    public DonationRepository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }
}