using DonorFuseTask.Models;
using DonorFuseTask.Models.DTOs;
using DonorFuseTask.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DonorFuseTask.Controllers;

[Route("api/schedule")]
[ApiController]
public class ScheduleController : ControllerBase
{
    private readonly IScheduleService _scheduleService;

    public ScheduleController(IScheduleService scheduleService)
    {
        _scheduleService = scheduleService;
    }

    [HttpGet]
    public async Task<IActionResult> GetSchedules()
    {
        var schedules = await _scheduleService.GetAllSchedulesAsync();
        return Ok(schedules);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetSchedule(int id)
    {
        var schedule = await _scheduleService.GetScheduleByIdAsync(id);
        if (schedule == null)
        {
            return NotFound();
        }

        return Ok(schedule);
    }

    [HttpPost]
    public async Task<IActionResult> CreateSchedule([FromBody] ScheduleInputDTO scheduleInputDTO)
    {
        await _scheduleService.AddScheduleAsync(scheduleInputDTO.StartDate, scheduleInputDTO.EndDate,
            scheduleInputDTO.Amount, scheduleInputDTO.DonorId);
        return Created();
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateSchedule(int id, [FromBody] ScheduleInputDTO schedule)
    {
        try
        {
            await _scheduleService.UpdateScheduleAsync(id, schedule.StartDate, schedule.EndDate, schedule.Amount);
            return Ok();
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteSchedule(int id)
    {
        try
        {
            await _scheduleService.DeleteScheduleAsync(id);
            return Ok();
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpGet("donor/{donorId}")]
    public async Task<IActionResult> GetDonorSchedules(int donorId)
    {
        var schedules = await _scheduleService.GetSchedulesByDonorIdAsync(donorId);
        return Ok(schedules);
    }
    
    [HttpGet("donor/{donorId}/amount")]
    public async Task<IActionResult> GetDonorScheduledBalance(int donorId)
    {
        var amount = await _scheduleService.CalculateScheduleDonationsAmountAsync(donorId);
        return Ok(amount);
    }
    
    [HttpGet("{scheduleId}/donor/{donorId}/amount")]
    public async Task<IActionResult> GetSingleScheduleDonorBalance(int donorId, int scheduleId)
    {
        var amount = await _scheduleService.CalculateSingleScheduleDonationsAmountAsync(donorId, scheduleId);
        return Ok(amount);
    }
}