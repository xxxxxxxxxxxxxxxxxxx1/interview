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
    public async Task<IActionResult> GetAllDonorsAsync()
    {
        var donors = await _donorService.GetAllDonorsAsync();
        return Ok(donors);
    }
    
    [HttpGet("{id}")]
    public async Task<IActionResult> GetDonorByIdAsync(int id)
    {
        var donor = await _donorService.GetDonorByIdAsync(id);
        if (donor == null)
            return NotFound();
        
        return Ok(donor);
    }
    
    [HttpPost]
    public async Task<IActionResult> AddDonorAsync([FromBody] DonorInputDTO donorInput)
    {
        var donor = new Donor
        {
            FirstName = donorInput.FirstName,
            LastName = donorInput.LastName,
            EmailAddress = donorInput.EmailAddress
        };
        
        await _donorService.AddDonorAsync(donor);
        return Ok();
    }
    
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateDonorAsync(int id, [FromBody] DonorInputDTO donorInout)
    {
        try
        {
            await _donorService.UpdateDonorAsync(id, donorInout.FirstName, donorInout.LastName, donorInout.EmailAddress);
            return Ok();
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
    
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteDonorAsync(int id)
    {
        try
        {
            await _donorService.DeleteDonorAsync(id);
            return Ok();
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
}