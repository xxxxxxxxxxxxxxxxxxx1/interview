using DonorFuseTask.Models;

namespace DonorFuseTask.Repositories.Interfaces;

public interface IDonorRepository
{
    Task<IEnumerable<Donor>> GetAllDonorsAsync();
    Task<Donor?> GetDonorByIdAsync(int id);
    Task AddDonorAsync(Donor donor);
    Task UpdateDonorAsync(int id, string firstName, string lastName, string emailAddress);
    Task DeleteDonorAsync(int id);
}