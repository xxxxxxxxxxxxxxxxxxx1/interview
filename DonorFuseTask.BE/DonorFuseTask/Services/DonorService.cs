using DonorFuseTask.Models;
using DonorFuseTask.Repositories.Interfaces;
using DonorFuseTask.Services.Interfaces;

namespace DonorFuseTask.Services;

public class DonorService : IDonorService
{
    private readonly IDonorRepository _donorRepository;

    public DonorService(IDonorRepository donorRepository)
    {
        _donorRepository = donorRepository;
    }

    public async Task<IEnumerable<Donor>> GetAllAsync()
    {
        return await _donorRepository.GetAllAsync();
    }

    public async Task<Donor?> GetByIdAsync(int id)
    {
        return await _donorRepository.GetByIdAsync(id);
    }

    public async Task CreateAsync(Donor donor)
    {
        await _donorRepository.CreateAsync(donor);
    }

    public async Task UpdateAsync(int id, string firstName, string lastName, string emailAddress)
    {
        if (string.IsNullOrWhiteSpace(firstName))
            throw new Exception("First Name Cannot Be Empty");
        
        if (string.IsNullOrWhiteSpace(lastName))
            throw new Exception("Last Name Cannot Be Empty");
        
        if (string.IsNullOrWhiteSpace(emailAddress))
            throw new Exception("Email Address Cannot Be Empty");
        
        await _donorRepository.UpdateAsync(id, firstName, lastName, emailAddress);
    }

    public async Task DeleteAsync(int id)
    {
        await _donorRepository.DeleteAsync(id);
    }
}