using ClinicMS.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace ClinicMS.Domain.Entities
{
  public class Appointment
  {
    [Required]
    public string? Id { get; set; }

    [Required]
    public string AppointmentNumber { get; set; } = string.Empty;

    [Required]
    [StringLength(100, MinimumLength = 3, ErrorMessage = "{0} must be between {1} and {2} characters.")]
    public string DoctorId { get; set; } = string.Empty;

    [Required]
    [StringLength(100, MinimumLength = 3, ErrorMessage = "{0} must be between {1} and {2} characters.")]
    public string PatientId { get; set; } = string.Empty;

    [Required]
    [StringLength(100, MinimumLength = 3, ErrorMessage = "{0} must be between {1} and {2} characters.")]
    public string DepartmentId { get; set; } = string.Empty;

    [Required]
    public DateTime AppointmentDate { get; set; }


    public TimeSpan StartTime { get; set; }
    public TimeSpan EndTime { get; set; }


    public AppointmentStatus Status { get; set; }

    [StringLength(500, MinimumLength = 3, ErrorMessage = "{0} must be between {1} and {2} characters.")]
    public string ChiefComplaint { get; set; } = string.Empty;

    [StringLength(500, MinimumLength = 3, ErrorMessage = "{0} must be between {1} and {2} characters.")]
    public string CancelReason { get; set; } = string.Empty;

    [Required]
    public DateTime CreatedOn { get; set; }

    [Required]
    public string? CreatedById { get; set; }

  }
}
