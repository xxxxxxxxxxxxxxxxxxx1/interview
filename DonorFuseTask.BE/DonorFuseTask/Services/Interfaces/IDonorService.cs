using DonorFuseTask.Models;

namespace DonorFuseTask.Services.Interfaces;

public interface IDonorService
{
    Task<IEnumerable<Donor>> GetAllDonorsAsync();
    Task<Donor?> GetDonorByIdAsync(int id);
    Task AddDonorAsync(Donor donor);
    Task UpdateDonorAsync(int id, string firstName, string lastName, string emailAddress);
    Task DeleteDonorAsync(int id);
}