using DonorFuseTask.Models;
using Microsoft.EntityFrameworkCore;

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
    
}