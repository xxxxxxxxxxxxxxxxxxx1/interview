using DonorFuseTask.Models;

namespace DonorFuseTask.Services.Interfaces;

public interface IDonorService
{
    Task<IEnumerable<Donor>> GetAllAsync();
    Task<Donor?> GetByIdAsync(int id);
    Task CreateAsync(Donor donor);
    Task UpdateAsync(int id, string firstName, string lastName, string emailAddress);
    Task DeleteAsync(int id);
}