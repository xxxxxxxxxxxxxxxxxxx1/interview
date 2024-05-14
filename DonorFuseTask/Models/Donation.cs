using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DonorFuseTask.Models;

public class Donation: BaseEntity
{
    [Required]
    public decimal Amount { get; set; }
    
    [Required]
    public DateTime Date { get; set; }
    
    // Foreign key properties
    public int DonorId { get; set; }
    
    [ForeignKey("DonorId")]
    public Donor Donor { get; set; }
    
    public int? ScheduleId { get; set; }
    
    [ForeignKey("ScheduleId")]
    public Schedule Schedule { get; set; }

}