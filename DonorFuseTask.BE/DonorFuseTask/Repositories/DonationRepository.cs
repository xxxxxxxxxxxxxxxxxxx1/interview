using DonorFuseTask.Context;
using DonorFuseTask.Models;
using DonorFuseTask.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DonorFuseTask.Repositories;

public class DonationRepository : IDonationRepository
{
    private readonly ApplicationDbContext _dbContext;

    public DonationRepository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<IEnumerable<Donation>> GetAllDonationsAsync()
    {
        return await _dbContext.Donations.ToListAsync();
    }

    public async Task<Donation?> GetDonationByIdAsync(int id)
    {
        return await _dbContext.Donations.FirstOrDefaultAsync(d => d.Id == id);
    }

    public async Task AddDonationAsync(Donation donation)
    {
        await _dbContext.Donations.AddAsync(donation);
        await _dbContext.SaveChangesAsync();
    }

    public async Task UpdateDonationAsync(int id, decimal ammount)
    {
        var donation = _dbContext.Donations.FirstOrDefault(d => d.Id == id);
        if (donation == null)
        {
            throw new Exception("Donation not found");
        }

        donation.Amount = ammount;
        await _dbContext.SaveChangesAsync();
    }

    public async Task DeleteDonationAsync(int id)
    {
        var donation = await GetDonationByIdAsync(id);
        if (donation == null)
        {
            throw new Exception("Donation not found");
        }

        _dbContext.Donations.Remove(donation);
        await _dbContext.SaveChangesAsync();
    }

    public async Task<decimal> CalculateTotalDonationsByDonorIdAsync(int donorId)
    {
        return await _dbContext.Donations.Where(d => d.DonorId == donorId).SumAsync(d => d.Amount);
    }

    public async Task<IEnumerable<Donation>> GetDonationsByDonorIdAsync(int donorId)
    {
        return await _dbContext.Donations.Where(d => d.DonorId == donorId).ToListAsync();
    }
}