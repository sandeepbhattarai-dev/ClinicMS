namespace ClinicMS.Domain.Entities
{
    public class Invoice
    {
        public string? Id { get; set; }
        public string InvoiceNumber { get; set; } = string.Empty;
        public string? PatientId { get; set; }
        public string? AppointmentId { get; set; }
        public DateTime IssuedOn { get; set; }
        public string Status { get; set; } = string.Empty;
        public decimal TotalAmount { get; set; }
        public DateTime PaidOn { get; set; }
        public string PaymentMethod { get; set; } = string.Empty;



    }
}
