using DonorFuseTask.Models;

namespace DonorFuseTask.Services.Interfaces;

public interface IScheduleService
{
    Task<IEnumerable<Schedule>> GetAllSchedulesAsync();
    Task<Schedule?> GetScheduleByIdAsync(int id);
    Task AddScheduleAsync(DateTime startDate, DateTime endDate, decimal amount, int donorId);
    Task UpdateScheduleAsync(int id, DateTime startDate, DateTime endDate, decimal amount);
    Task DeleteScheduleAsync(int id);
    Task<IEnumerable<Schedule>> GetSchedulesByDonorIdAsync(int donorId);
    Task<decimal> CalculateScheduleDonationsAmountAsync(int donorId);
}