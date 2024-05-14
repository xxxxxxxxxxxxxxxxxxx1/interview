using System.ComponentModel.DataAnnotations;

namespace DonorFuseTask.Models;

public class Donor : BaseEntity
{
    [Required]
    public string FirstName { get; set; }
    
    [Required]
    public string LastName { get; set; }
    
    [EmailAddress]
    public string EmailAddress { get; set; }
    
    // Navigation properties
    public List<Donation> Donations { get; set; }
    public List<Schedule> Schedules { get; set; }
}