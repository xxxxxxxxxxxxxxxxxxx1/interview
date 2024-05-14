using DonorFuseTask.Context;
using DonorFuseTask.Models;
using DonorFuseTask.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DonorFuseTask.Repositories;

public class ScheduleRepository : IScheduleRepository
{
    private readonly ApplicationDbContext _dbContext;

    public ScheduleRepository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<IEnumerable<Schedule>> GetAllSchedulesAsync()
    {
        return await _dbContext.Schedules.ToListAsync();
    }

    public async Task<Schedule?> GetScheduleByIdAsync(int id)
    {
        return await _dbContext.Schedules.FirstOrDefaultAsync(s => s.Id == id);
    }

    public async Task AddScheduleAsync(Schedule schedule)
    {
        await _dbContext.Schedules.AddAsync(schedule);
        await _dbContext.SaveChangesAsync();
    }

    public Task UpdateScheduleAsync(int id, DateTime startDate, DateTime endDate, decimal amount)
    {
        var schedule = _dbContext.Schedules.FirstOrDefault(s => s.Id == id);
        if (schedule == null)
        {
            throw new Exception("Schedule not found");
        }
        
        schedule.StartDate = startDate;
        schedule.EndDate = endDate;
        schedule.Amount = amount;
        return _dbContext.SaveChangesAsync();
    }

    public Task DeleteScheduleAsync(int id)
    {
        var schedule = _dbContext.Schedules.FirstOrDefault(s => s.Id == id);
        if (schedule == null)
        {
            throw new Exception("Schedule not found");
        }
        
        _dbContext.Schedules.Remove(schedule);
        return _dbContext.SaveChangesAsync();
    }

    public Task<IEnumerable<Schedule>> GetSchedulesByDonorIdAsync(int donorId)
    {
        throw new NotImplementedException();
    }

    public Task<decimal> CalculateScheduleDonationsAmountAsync(int scheduleId)
    {
        throw new NotImplementedException();
    }
}