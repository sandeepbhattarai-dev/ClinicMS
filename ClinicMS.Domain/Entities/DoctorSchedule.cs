using System.ComponentModel.DataAnnotations;

namespace ClinicMS.Domain.Entities
{
  public class DoctorSchedule
  {
    [Key]
    [Required]
    public string Id { get; set; } = string.Empty;
    [Required]
    public string DoctorId { get; set; } = string.Empty;
    public DayOfWeek DayOfWeek { get; set; }
    public TimeSpan StartTime { get; set; }
    public TimeSpan EndTime { get; set; }
    public int SlotDurationMinutes { get; set; } = 10;
    public bool IsActive { get; set; } = true;


    public Doctor Doctor { get; set; } = null!;
  }
}
