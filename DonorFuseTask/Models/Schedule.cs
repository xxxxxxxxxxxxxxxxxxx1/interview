using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DonorFuseTask.Models;

public class Schedule : BaseEntity
{
    [Required]
    public DateTime StartDate { get; set; }
    
    [Required]
    public DateTime EndDate { get; set; }
    
    [Required]
    public decimal Amount { get; set; }
    
    // Foreign key property
    public int DonorId { get; set; }
    
    [ForeignKey("DonorId")]
    public Donor Donor { get; set; }
}