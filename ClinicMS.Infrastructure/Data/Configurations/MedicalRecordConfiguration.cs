using ClinicMS.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ClinicMS.Infrastructure.Data.Configurations
{
  public class MedicalRecordConfiguration : IEntityTypeConfiguration<MedicalRecord>
  {
    public void Configure(EntityTypeBuilder<MedicalRecord> builder)
    {
      builder.HasKey(x => x.Id);

      builder.HasOne(x => x.Appointment)
              .WithOne(x => x.MedicalRecord)
              .HasForeignKey<MedicalRecord>(x => x.AppointmentId)
              .OnDelete(DeleteBehavior.Restrict);

      builder.HasIndex(x => x.AppointmentId).IsUnique();

      builder.Property(x => x.BloodPressure)
                 .HasMaxLength(20);

      builder.Property(x => x.Temperature)
             .HasPrecision(5, 2);

      builder.Property(x => x.Pulse)
             .HasPrecision(5, 2);

      builder.Property(x => x.Weight)
             .HasPrecision(6, 2);

      builder.Property(x => x.Height)
             .HasPrecision(6, 2);

      builder.Property(x => x.Diagnosis)
             .IsRequired()
             .HasMaxLength(1000);

      builder.Property(x => x.Notes)
             .HasMaxLength(2000);

      builder.Property(x => x.CreatedOn)
             .IsRequired();

      builder.Property(x => x.CreatedById)
             .HasMaxLength(50);
    }
  }
}
