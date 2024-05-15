using System.Runtime.InteropServices.JavaScript;
using DonorFuseTask.Models;
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

    public async Task<IEnumerable<Schedule>> GetAllSchedulesAsync()
    {
        return await _scheduleRepository.GetAllSchedulesAsync();
    }

    public async Task<Schedule?> GetScheduleByIdAsync(int id)
    {
        return await _scheduleRepository.GetScheduleByIdAsync(id);
    }

    public async Task AddScheduleAsync(DateTime startDate, DateTime endDate, decimal amount, int donorId)
    {
        if (startDate > endDate)
        {
            throw new Exception("Start date cannot be greater than end date");
        }

        if (amount <= 0)
        {
            throw new Exception("Amount must be greater than 0");
        }

        var schedule = new Schedule
        {
            StartDate = startDate,
            EndDate = endDate,
            Amount = amount,
            DonorId = donorId
        };

        await _scheduleRepository.AddScheduleAsync(schedule);
    }

    public async Task UpdateScheduleAsync(int id, DateTime startDate, DateTime endDate, decimal amount)
    {
        if (startDate > endDate)
        {
            throw new Exception("Start date cannot be greater than end date");
        }

        if (amount <= 0)
        {
            throw new Exception("Amount must be greater than 0");
        }

        await _scheduleRepository.UpdateScheduleAsync(id, startDate, endDate, amount);
    }

    public async Task DeleteScheduleAsync(int id)
    {
        await _scheduleRepository.DeleteScheduleAsync(id);
    }

    public async Task<IEnumerable<Schedule>> GetSchedulesByDonorIdAsync(int donorId)
    {
        return await _scheduleRepository.GetSchedulesByDonorIdAsync(donorId);
    }

    public async Task<decimal> CalculateScheduleDonationsAmountAsync(int donorId)
    {
        var dateTimeNow = DateTime.Now;
        var donationDay = new DateTime(dateTimeNow.Year, dateTimeNow.Month, 1);

        return await _scheduleRepository.CalculateScheduleDonationsAmountAsync(donorId, donationDay);
    }

    public async Task<decimal> CalculateSingleScheduleDonationsAmountAsync(int donorId, int scheduleId)
    {
        var dateTimeNow = DateTime.Now;
        var donationDay = new DateTime(dateTimeNow.Year, dateTimeNow.Month, 1);
        
        return await _scheduleRepository.CalculateSingleScheduleDonationsAmountAsync(donorId, scheduleId, donationDay);
    }
}