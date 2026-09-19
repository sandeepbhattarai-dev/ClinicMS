
using System.ComponentModel.DataAnnotations;

namespace ClinicMS.Domain.Entities
{
  public class InvoiceItem
  {
    [Required]
    public string Id { get; set; } = string.Empty;
    public string InvoiceId { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public int Quantity { get; set; }
    public decimal UnitPrice { get; set; }
    public decimal LineTotal { get; set; }

    public Invoice? Invoice { get; set; }
  }
}
