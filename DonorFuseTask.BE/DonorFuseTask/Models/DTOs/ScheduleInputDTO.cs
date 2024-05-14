namespace DonorFuseTask.Models.DTOs;

public class ScheduleInputDTO
{
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public decimal Amount { get; set; }
    public int DonorId { get; set; }
}