using DonorFuseTask.Models;

namespace DonorFuseTask.Services.Interfaces;

public interface IDonationService
{
    Task<IEnumerable<Donation>> GetAllDonationsAsync();
    Task<Donation?> GetDonationByIdAsync(int id);
    Task AddDonationAsync(int donorId, decimal ammount);
    Task UpdateDonationAsync(int id, decimal ammount);
    Task DeleteDonationAsync(int id);
    Task<decimal> CalculateTotalDonationsByDonorIdAsync(int donorId);
}