using DonorFuseTask.Models;
using DonorFuseTask.Models.DTOs;
using DonorFuseTask.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DonorFuseTask.Controllers;

[Route("api/donor")]
[ApiController]
public class DonorController : ControllerBase
{
    private readonly IDonorService _donorService;
    
    public DonorController(IDonorService donorService)
    {
        _donorService = donorService;
    }
    
    [HttpGet]
    public async Task<IActionResult> GetAllAsync()
    {
        var donors = await _donorService.GetAllAsync();
        return Ok(donors);
    }
    
    [HttpGet("{id}")]
    public async Task<IActionResult> GetByIdAsync(int id)
    {
        var donor = await _donorService.GetByIdAsync(id);
        if (donor == null)
            return NotFound();
        
        return Ok(donor);
    }
    
    [HttpPost]
    public async Task<IActionResult> CreateAsync([FromBody] DonorInputDTO donorInput)
    {
        var donor = new Donor()
        {
            FirstName = donorInput.FirstName,
            LastName = donorInput.LastName,
            EmailAddress = donorInput.EmailAddress
        };
        
        await _donorService.CreateAsync(donor);
        return Ok();
    }
    
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateAsync(int id, [FromBody] DonorInputDTO donorInout)
    {
        try
        {
            await _donorService.UpdateAsync(id, donorInout.FirstName, donorInout.LastName, donorInout.EmailAddress);
            return Ok();
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
}