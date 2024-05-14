using DonorFuseTask.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DonorFuseTask.Controllers;

[Route("api/donation")]
[ApiController]
public class DonationController : ControllerBase
{
    private readonly IDonationService _donationService;

    public DonationController(IDonationService donationService)
    {
        _donationService = donationService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllDonationsAsync()
    {
        var donations = await _donationService.GetAllDonationsAsync();
        return Ok(donations);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetDonationByIdAsync(int id)
    {
        var donation = await _donationService.GetDonationByIdAsync(id);
        if (donation == null)
        {
            return NotFound();
        }

        return Ok(donation);
    }

    [HttpPost("{donorId}/{amount}")]
    public async Task<IActionResult> AddDonationAsync(int donorId, decimal amount)
    {
        try
        {
            await _donationService.AddDonationAsync(donorId, amount);
            return Ok();
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
    
    [HttpPut("{id}/{amount}")]
    public async Task<IActionResult> UpdateDonationAsync(int id, decimal amount)
    {
        try
        {
            await _donationService.UpdateDonationAsync(id, amount);
            return Ok();
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteDonationAsync(int id)
    {
        try
        {
            await _donationService.DeleteDonationAsync(id);
            return Ok();
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpGet("total/{donorId}")]
    public async Task<IActionResult> CalculateTotalDonationsByDonorIdAsync(int donorId)
    {
        var total = await _donationService.CalculateTotalDonationsByDonorIdAsync(donorId);
        return Ok(total);
    }
}