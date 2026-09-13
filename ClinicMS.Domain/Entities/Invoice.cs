namespace ClinicMS.Domain.Entities
{
    public class Invoice
    {
        public Guid Id { get; set; }
        public string InvoiceNumber { get; set; } = string.Empty;
        public Guid PatientId { get; set; }
        public Guid AppointmentId { get; set; }
        public DateTime IssuedOn { get; set; }
        public string Status { get; set; } = string.Empty;
        public decimal TotalAmount { get; set; }
        public DateTime PaidOn { get; set; }
        public string PaymentMethod { get; set; } = string.Empty;



    }
}
