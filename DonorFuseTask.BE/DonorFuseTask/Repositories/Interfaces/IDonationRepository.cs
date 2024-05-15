using DonorFuseTask.Models;

namespace DonorFuseTask.Repositories.Interfaces;

public interface IDonationRepository
{
    Task<IEnumerable<Donation>> GetAllDonationsAsync();
    Task<Donation?> GetDonationByIdAsync(int id);
    Task AddDonationAsync(Donation donation);
    Task UpdateDonationAsync(int id, decimal ammount);
    Task DeleteDonationAsync(int id);
    Task<decimal> CalculateTotalDonationsByDonorIdAsync(int donorId);
    Task<IEnumerable<Donation>> GetDonationsByDonorIdAsync(int donorId);
}