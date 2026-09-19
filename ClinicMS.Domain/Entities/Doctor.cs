using System.ComponentModel.DataAnnotations;

namespace ClinicMS.Domain.Entities
{
  public class Doctor
  {
    [Required]
    public string Id { get; set; } = string.Empty;

    [Required]
    // Foreign key to the ApplicationUser entity
    public string ApplicationUserId { get; set; } = string.Empty;
    public ApplicationUser ApplicationUser { get; set; } = null!;

    [Required]
    public string FullName { get; set; } = string.Empty;

    [Required]
    // foreign key to the Department entity
    public string DepartmentId { get; set; } = string.Empty;
    public Department Department { get; set; } = null!;

    [Required]
    public string Specialization { get; set; } = string.Empty;

    [Required]
    public string LicenseNumber { get; set; } = string.Empty;

    [Required]
    public decimal ConsultationFee { get; set; } = 0.00m;

    public bool IsActive { get; set; } = true;


    public List<DoctorSchedule> DoctorSchedules { get; set; } = [];
    public List<Appointment> Appointments { get; set; } = [];
    public List<Prescription> Prescriptions { get; set; } = [];

  }
}
// incomplete - v1.0.0