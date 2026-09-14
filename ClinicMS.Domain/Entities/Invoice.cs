using ClinicMS.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace ClinicMS.Domain.Entities
{
    public class Invoice
    {
      [Required]
      public string? Id { get; set; }
        public string InvoiceNumber { get; set; } = string.Empty;
        public string? PatientId { get; set; }
        public string? AppointmentId { get; set; }
        public DateTime IssuedOn { get; set; }
        public InvoiceStatus Status { get; set; }
        public decimal TotalAmount { get; set; }
        public DateTime PaidOn { get; set; }
        public PaymentMethod PaymentMethod { get; set; }



    }
}
