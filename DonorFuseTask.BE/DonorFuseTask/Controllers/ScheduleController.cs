using DonorFuseTask.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DonorFuseTask.Controllers;

[Route("api/schedules")]
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
        return Ok("schedules");
    }
}