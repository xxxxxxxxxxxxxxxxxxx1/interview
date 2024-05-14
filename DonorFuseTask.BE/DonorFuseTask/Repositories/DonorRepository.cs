using DonorFuseTask.Context;
using DonorFuseTask.Models;
using DonorFuseTask.Repositories.Interfaces;
using DonorFuseTask.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DonorFuseTask.Repositories;

public class DonorRepository : IDonorRepository
{
    private readonly ApplicationDbContext _dbContext;

    public DonorRepository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<IEnumerable<Donor>> GetAllDonorsAsync()
    {
        return await _dbContext.Donors.ToListAsync();
    }

    public async Task<Donor?> GetDonorByIdAsync(int id)
    {
        return await _dbContext.Donors.FirstOrDefaultAsync(donor => donor.Id == id);
    }

    public async Task AddDonorAsync(Donor donor)
    {
        await _dbContext.Donors.AddAsync(donor);
        await _dbContext.SaveChangesAsync();
    }

    public async Task UpdateDonorAsync(int id, string firstName, string lastName, string emailAddress)
    {
        var donor = await GetDonorByIdAsync(id);
        if (donor == null)
            throw new Exception("No Donor Found With Given Id");

        donor.FirstName = firstName;
        donor.LastName = lastName;
        donor.EmailAddress = emailAddress;

        await _dbContext.SaveChangesAsync();
    }

    public async Task DeleteDonorAsync(int id)
    {
        var donor = await GetDonorByIdAsync(id);
        if (donor == null)
            throw new Exception("No Donor Found With Given Id");

        _dbContext.Donors.Remove(donor);
        await _dbContext.SaveChangesAsync();
    }
}