using DonorFuseTask.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DonorFuseTask.Controllers;

[Route("api/donation")]
[ApiController]
public class DonationController: ControllerBase
{
    private readonly IDonationService _donationService;
    
    public DonationController(IDonationService donationService)
    {
        _donationService = donationService;
    }
    
    [HttpGet]
    public async Task<IActionResult> GetDonations()
    {
        return Ok("donations");
    }
}