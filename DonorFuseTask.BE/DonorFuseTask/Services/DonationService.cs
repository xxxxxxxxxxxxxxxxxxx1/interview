using DonorFuseTask.Models;
using DonorFuseTask.Repositories.Interfaces;
using DonorFuseTask.Services.Interfaces;

namespace DonorFuseTask.Services;

public class DonationService : IDonationService
{
    private readonly IDonationRepository _donationRepository;
    private readonly IDonorService _donorService;

    public DonationService(IDonationRepository donationRepository, IDonorService donorService)
    {
        _donationRepository = donationRepository;
        _donorService = donorService;
    }

    public async Task<IEnumerable<Donation>> GetAllDonationsAsync()
    {
        return await _donationRepository.GetAllDonationsAsync();
    }

    public async Task<Donation?> GetDonationByIdAsync(int id)
    {
        return await _donationRepository.GetDonationByIdAsync(id);
    }

    public async Task AddDonationAsync(int donorId, decimal amount)
    {
        var donor = await _donorService.GetByIdAsync(donorId);
        
        if (donor == null)
        {
            throw new Exception("Donor not found");
        }
        
        if (amount <= 0)
        {
            throw new Exception("Donation amount must be greater than 0");
        }
        
        var donation = new Donation
        {
            DonorId = donorId,
            Amount = amount,
            Date = DateTime.Now
        };
        
        await _donationRepository.AddDonationAsync(donation);
    }

    public async Task UpdateDonationAsync(int id, decimal ammount)
    {
        var donor = await _donationRepository.GetDonationByIdAsync(id);
        if (donor == null)
        {
            throw new Exception("Donation not found");
        }
        
        if (ammount <= 0)
        {
            throw new Exception("Donation amount must be greater than 0");
        }
        
        await _donationRepository.UpdateDonationAsync(id, ammount);
    }

    public async Task DeleteDonationAsync(int id)
    {
        var donation = await _donationRepository.GetDonationByIdAsync(id);
        if (donation == null)
        {
            throw new Exception("Donation not found");
        }
        
        await _donationRepository.DeleteDonationAsync(id);
    }

    public Task<decimal> CalculateTotalDonationsByDonorIdAsync(int donorId)
    {
        return _donationRepository.CalculateTotalDonationsByDonorIdAsync(donorId);
    }
}