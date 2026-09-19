using ClinicMS.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace ClinicMS.Domain.Entities
{
  public class Invoice
  {
    [Required]
    public string Id { get; set; } = string.Empty;
    public string InvoiceNumber { get; set; } = string.Empty;
    public string PatientId { get; set; } = string.Empty;
    public string AppointmentId { get; set; } = string.Empty;
    public DateTime IssuedOn { get; set; }
    public InvoiceStatus Status { get; set; } = InvoiceStatus.Pending;
    public decimal TotalAmount { get; set; }
    public DateTime? PaidOn { get; set; }
    public PaymentMethod? PaymentMethod { get; set; }

    // nav
    public ICollection<InvoiceItem> Items { get; set; } = [];
    public Appointment? Appointment { get; set; }
    public Patient? Patient { get; set; }

  }
}
