using System.ComponentModel.DataAnnotations;

namespace ClinicMS.Domain.Entities
{
  public class DoctorSchedule
  {
    [Key]
    [Required]
    public string? Id { get; set; }
    [Required]
    public string? DoctorId { get; set; }
    public DayOfWeek DayOfWeek { get; set; }
    public TimeSpan StartTime { get; set; }
    public TimeSpan EndTime { get; set; }
    public int SlotDurationMinutes { get; set; } = 10;
    public bool IsActive { get; set; }
  }
}
