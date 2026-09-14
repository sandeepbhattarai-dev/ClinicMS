using System.ComponentModel.DataAnnotations;

namespace ClinicMS.Domain.Entities
{
  public class Prescription
  {
    [Required]
    public string Id { get; set; } = string.Empty;
    public string AppointmentId { get; set; } = string.Empty;
    public string DoctorId { get; set; } = string.Empty;
    public string PatientId { get; set; } = string.Empty;
    public DateTime IssuedOn { get; set; }
    public string Notes { get; set; } = string.Empty;
    public ICollection<PrescriptionItem> Items { get; set; } = [];


    //nav 
    public Appointment? Appointment { get; set; }
    public Doctor? Doctor { get; set; }
    public Patient? Patient { get; set; }

  }
}
