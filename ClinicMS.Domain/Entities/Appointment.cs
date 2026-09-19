using ClinicMS.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace ClinicMS.Domain.Entities
{
  public class Appointment
  {
    [Required]
    public string Id { get; set; } = string.Empty;

    [Required]
    public string AppointmentNumber { get; set; } = string.Empty;

    [Required]
    public string DoctorId { get; set; } = string.Empty;
    public Doctor Doctor { get; set; } = null!;

    [Required]
    public string PatientId { get; set; } = string.Empty;
    public Patient Patient { get; set; } = null!;

    [Required]
    public string DepartmentId { get; set; } = string.Empty;
    public Department Department { get; set; } = null!;

    [Required]
    public DateTime AppointmentDate { get; set; }


    public TimeSpan StartTime { get; set; }
    public TimeSpan EndTime { get; set; }


    public AppointmentStatus Status { get; set; } = AppointmentStatus.Scheduled;

    public string ChiefComplaint { get; set; } = string.Empty;

    public string CancelReason { get; set; } = string.Empty;

    [Required]
    public DateTime CreatedOn { get; set; }

    [Required]
    public string CreatedById { get; set; } = string.Empty;



    // nav
    public MedicalRecord? MedicalRecord { get; set; }
    public Prescription? Prescription { get; set; }
    public Invoice? Invoice { get; set; }
  }
}
