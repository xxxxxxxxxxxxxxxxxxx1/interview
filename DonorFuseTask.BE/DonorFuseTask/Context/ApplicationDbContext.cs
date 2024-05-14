using System.Data;
using DonorFuseTask.Models;
using Microsoft.EntityFrameworkCore;
using MySqlConnector;

namespace DonorFuseTask.Context;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Configure relationships
        modelBuilder.Entity<Donation>()
            .HasOne(d => d.Donor)
            .WithMany(d => d.Donations)
            .HasForeignKey(d => d.DonorId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Donation>()
            .HasOne(d => d.Schedule)
            .WithMany()
            .HasForeignKey(d => d.ScheduleId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Schedule>()
            .HasOne(s => s.Donor)
            .WithMany(d => d.Schedules)
            .HasForeignKey(s => s.DonorId)
            .OnDelete(DeleteBehavior.Restrict);
    }
    
    public DbSet<Donor> Donors { get; set; }
    public DbSet<Donation> Donations { get; set; }
    public DbSet<Schedule> Schedules { get; set; }
    
    // Stored procedures
    // public async Task<decimal> GetDonorScheduledBalance(int donorId, DateTime donationDay)
    // {
    //     var result = await this.Database
    //         .ExecuteSqlRawAsync("CALL GetDonorScheduledBalance({0}, {1})", donorId, donationDay);
    //     
    //     return Convert.ToDecimal(result);
    // }
    
    public async Task<decimal> GetDonorScheduledBalance(int donorId, DateTime donationDay)
    {
        using var connection = new MySqlConnection(this.Database.GetDbConnection().ConnectionString);
        await connection.OpenAsync();

        using var command = connection.CreateCommand();
        command.CommandType = CommandType.StoredProcedure;
        command.CommandText = "GetDonorScheduledBalance";

        // Add input parameters
        command.Parameters.AddWithValue("@p_DonorId", donorId);
        command.Parameters.AddWithValue("@p_DonationDay", donationDay);

        // Add output parameter
        var outputParameter = new MySqlParameter("@p_TotalDonationAmount", MySqlDbType.Decimal)
        {
            Direction = ParameterDirection.Output
        };
        command.Parameters.Add(outputParameter);

        await command.ExecuteNonQueryAsync();

        // Retrieve the output parameter value
        var totalDonationAmount = Convert.ToDecimal(outputParameter.Value);

        return totalDonationAmount;
    }

}