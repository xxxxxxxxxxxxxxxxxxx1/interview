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

    public Task AddScheduleAsync(DateTime startDate, DateTime endDate, decimal amount, int donorId)
    {
        if (startDate > endDate)
        {
            throw new Exception("Start date cannot be greater than end date");
        }
        
        if(startDate < DateTime.Now)
        {
            throw new Exception("Start date cannot be in the past");
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

        return _scheduleRepository.AddScheduleAsync(schedule);
    }
    
    public Task UpdateScheduleAsync(int id, DateTime startDate, DateTime endDate, decimal amount)
    {
        if (startDate > endDate)
        {
            throw new Exception("Start date cannot be greater than end date");
        }
        
        if(startDate < DateTime.Now)
        {
            throw new Exception("Start date cannot be in the past");
        }
        
        if (amount <= 0)
        {
            throw new Exception("Amount must be greater than 0");
        }
        
        return _scheduleRepository.UpdateScheduleAsync(id, startDate, endDate, amount);
    }

    public Task DeleteScheduleAsync(int id)
    {
        return _scheduleRepository.DeleteScheduleAsync(id);
    }

    public Task<IEnumerable<Schedule>> GetSchedulesByDonorIdAsync(int donorId)
    {
        return _scheduleRepository.GetSchedulesByDonorIdAsync(donorId);
    }

    public Task<decimal> CalculateScheduleDonationsAmountAsync(int scheduleId)
    {
        return _scheduleRepository.CalculateScheduleDonationsAmountAsync(scheduleId);
    }
}