using ClinicMS.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace ClinicMS.Infrastructure.Data.Configurations
{
  public class InvoiceConfiguration : IEntityTypeConfiguration<Invoice>
  {
    public void Configure(EntityTypeBuilder<Invoice> builder)
    {
      builder.HasKey(x => x.Id);

      builder.Property(x => x.Id)
             .IsRequired();

      builder.Property(x => x.InvoiceNumber)
             .IsRequired()
             .HasMaxLength(20);

      builder.Property(x => x.PatientId)
             .IsRequired();

      builder.Property(x => x.AppointmentId)
             .IsRequired();

      builder.Property(x => x.IssuedOn)
             .IsRequired();

      builder.Property(x => x.Status)
             .IsRequired();

      builder.Property(x => x.TotalAmount)
             .IsRequired()
             .HasPrecision(18, 2);

      builder.Property(x => x.PaidOn)
             .IsRequired(false);

      builder.Property(x => x.PaymentMethod)
             .IsRequired(false);


      // -----------------------------
      // InvoiceNumber UNIQUE
      // -----------------------------

      builder.HasIndex(x => x.InvoiceNumber)
             .IsUnique();


      // -----------------------------
      // Appointment 1 : 0..1 Invoice
      // -----------------------------

      builder.HasOne(x => x.Appointment)
             .WithOne(x => x.Invoice)
             .HasForeignKey<Invoice>(x => x.AppointmentId)
             .OnDelete(DeleteBehavior.Restrict);


      // -----------------------------
      // Patient 1 : Many Invoices
      // -----------------------------

      builder.HasOne(x => x.Patient)
             .WithMany(x => x.Invoices)
             .HasForeignKey(x => x.PatientId)
             .OnDelete(DeleteBehavior.Restrict);


      // -----------------------------
      // Invoice 1 : Many InvoiceItems
      // -----------------------------

      builder.HasMany(x => x.Items)
             .WithOne(x => x.Invoice)
             .HasForeignKey(x => x.InvoiceId)
             .OnDelete(DeleteBehavior.Cascade);
    }
  }
}
