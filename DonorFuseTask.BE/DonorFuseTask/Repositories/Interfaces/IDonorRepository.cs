using DonorFuseTask.Models;

namespace DonorFuseTask.Repositories.Interfaces;

public interface IDonorRepository
{
    Task<IEnumerable<Donor>> GetAllAsync();
    Task<Donor?> GetByIdAsync(int id);
    Task CreateAsync(Donor donor);
    Task UpdateAsync(int id, string firstName, string lastName, string emailAddress);
    Task DeleteAsync(int id);
}