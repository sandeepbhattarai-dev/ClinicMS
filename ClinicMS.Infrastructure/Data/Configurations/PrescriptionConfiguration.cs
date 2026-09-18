using ClinicMS.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ClinicMS.Infrastructure.Data.Configurations
{
  internal class PrescriptionConfiguration : IEntityTypeConfiguration<Prescription>
  {
    public void Configure(EntityTypeBuilder<Prescription> builder)
    {
      builder.HasKey(x => x.Id);


      builder.Property(x => x.Id)
             .IsRequired();

      builder.Property(x => x.AppointmentId)
             .IsRequired();

      builder.Property(x => x.DoctorId)
             .IsRequired();

      builder.Property(x => x.PatientId)
             .IsRequired();

      builder.Property(x => x.IssuedOn)
             .IsRequired();

      builder.Property(x => x.Notes)
             .IsRequired();

      builder.HasOne(x => x.Appointment)
             .WithOne(x => x.Prescription)
             .HasForeignKey<Prescription>(x => x.AppointmentId)
             .OnDelete(DeleteBehavior.Restrict);


      builder.HasOne(x => x.Doctor)
             .WithMany(x => x.Prescriptions)
             .HasForeignKey(x => x.DoctorId)
             .OnDelete(DeleteBehavior.Restrict);



      builder.HasOne(x => x.Patient)
             .WithMany(x => x.Prescriptions)
             .HasForeignKey(x => x.PatientId)
             .OnDelete(DeleteBehavior.Restrict);


      builder.HasMany(x => x.Items)
             .WithOne(x => x.Prescription)
             .HasForeignKey(x => x.PrescriptionId)
             .OnDelete(DeleteBehavior.Cascade);
    }
  }
}
