
namespace ClinicMS.Domain.Entities
{
    public class InvoiceItem
    {
        // create a new class called InvoiceItem with the following properties: Id, InvoiceId, Description, Quantity, UnitPrice, LineTotal
        public string? Id { get; set; }
        public string? InvoiceId { get; set; }
        public string Description { get; set; } = string.Empty;
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal LineTotal { get; set; }
    }
}
