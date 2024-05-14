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

    public async Task<IEnumerable<Donor>> GetAllDonorsAsync()
    {
        return await _donorRepository.GetAllDonorsAsync();
    }

    public async Task<Donor?> GetDonorByIdAsync(int id)
    {
        return await _donorRepository.GetDonorByIdAsync(id);
    }

    public async Task AddDonorAsync(Donor donor)
    {
        await _donorRepository.AddDonorAsync(donor);
    }

    public async Task UpdateDonorAsync(int id, string firstName, string lastName, string emailAddress)
    {
        if (string.IsNullOrWhiteSpace(firstName))
            throw new Exception("First Name Cannot Be Empty");
        
        if (string.IsNullOrWhiteSpace(lastName))
            throw new Exception("Last Name Cannot Be Empty");
        
        if (string.IsNullOrWhiteSpace(emailAddress))
            throw new Exception("Email Address Cannot Be Empty");
        
        await _donorRepository.UpdateDonorAsync(id, firstName, lastName, emailAddress);
    }

    public async Task DeleteDonorAsync(int id)
    {
        await _donorRepository.DeleteDonorAsync(id);
    }
}