using System.ComponentModel.DataAnnotations;

namespace ClinicMS.Domain.Entities
{
  public class Doctor
  {
    [Required]
    public string? Id { get; init; }

    [Required]
    // Foreign key to the ApplicationUser entity
    public string? ApplicationUserId { get; set; }

    [Required]
    public string FullName { get; set; } = string.Empty;

    [Required]
    // foreign key to the Department entity
    public string? DepartmentId { get; set; }

    [Required]
    public string Specialization { get; set; } = string.Empty;

    [Required]
    public string LicenseNumber { get; set; } = string.Empty;

    [Required]
    public decimal ConsultationFee { get; set; } = 0.00m;

    public bool IsActive { get; set; } = true;

  }
}
// incomplete - v1.0.0