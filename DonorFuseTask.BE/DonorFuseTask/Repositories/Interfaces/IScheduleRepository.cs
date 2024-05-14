using DonorFuseTask.Models;

namespace DonorFuseTask.Repositories.Interfaces;

public interface IScheduleRepository
{
    Task<IEnumerable<Schedule>> GetAllSchedulesAsync();
    Task<Schedule?> GetScheduleByIdAsync(int id);
    Task AddScheduleAsync(Schedule schedule);
    Task UpdateScheduleAsync(int id, DateTime startDate, DateTime endDate, decimal amount);
    Task DeleteScheduleAsync(int id);
    Task<IEnumerable<Schedule>> GetSchedulesByDonorIdAsync(int donorId);
    Task<decimal> CalculateScheduleDonationsAmountAsync(int donorId, DateTime donationDay);
}