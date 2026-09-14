using System.ComponentModel.DataAnnotations;

namespace ClinicMS.Domain.Entities
{
  public class MedicalRecord
  {
    [Required]
    public string? Id { get; set; }
    public string? AppointmentId { get; set; }

    public string? BloodPressure { get; set; }
    public decimal Temperature { get; set; }
    public decimal Pulse { get; set; }
    public decimal Weight { get; set; }
    public decimal Height { get; set; }
    [Required]
    public string Diagnosis { get; set; } = string.Empty;


    public string? Notes { get; set; }

    [Required]
    public DateTime CreatedOn { get; set; }

    public string? CreatedById { get; set; }
  }
}
