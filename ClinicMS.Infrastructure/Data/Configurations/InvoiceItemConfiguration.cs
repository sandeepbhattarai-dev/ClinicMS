using ClinicMS.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ClinicMS.Infrastructure.Data.Configurations
{
  public class InvoiceItemConfiguration : IEntityTypeConfiguration<InvoiceItem>
  {
    public void Configure(EntityTypeBuilder<InvoiceItem> builder)
    {
      builder.HasKey(x => x.Id);

      builder.Property(x => x.Id)
             .IsRequired();

      builder.Property(x => x.InvoiceId)
             .IsRequired();

      builder.Property(x => x.Description)
             .IsRequired()
             .HasMaxLength(500);

      builder.Property(x => x.Quantity)
             .IsRequired();

      builder.Property(x => x.UnitPrice)
             .IsRequired()
             .HasPrecision(18, 2);

      builder.Property(x => x.LineTotal)
             .IsRequired()
             .HasPrecision(18, 2);


      // -----------------------------
      // Invoice 1 : Many InvoiceItems
      // -----------------------------

      builder.HasOne(x => x.Invoice)
             .WithMany(x => x.Items)
             .HasForeignKey(x => x.InvoiceId)
             .OnDelete(DeleteBehavior.Cascade);
    }
  }
}
