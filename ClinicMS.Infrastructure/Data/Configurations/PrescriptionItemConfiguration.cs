using ClinicMS.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace ClinicMS.Infrastructure.Data.Configurations
{
  internal class PrescriptionItemConfiguration : IEntityTypeConfiguration<PrescriptionItem>
  {
    public void Configure(EntityTypeBuilder<PrescriptionItem> builder)
    {
      builder.HasKey(x => x.Id);

      builder.Property(x => x.Id)
             .IsRequired();

      builder.Property(x => x.PrescriptionId)
             .IsRequired();

      builder.Property(x => x.MedicationName)
             .IsRequired()
             .HasMaxLength(200);

      builder.Property(x => x.Dosage)
             .IsRequired()
             .HasMaxLength(100);

      builder.Property(x => x.Frequency)
             .IsRequired()
             .HasMaxLength(100);

      builder.Property(x => x.DurationDays)
             .IsRequired();

      builder.Property(x => x.Instructions)
             .IsRequired()
             .HasMaxLength(1000);

      builder.HasOne(x => x.Prescription)
             .WithMany(x => x.Items)
             .HasForeignKey(x => x.PrescriptionId)
             .OnDelete(DeleteBehavior.Cascade);
    }
  }
}
