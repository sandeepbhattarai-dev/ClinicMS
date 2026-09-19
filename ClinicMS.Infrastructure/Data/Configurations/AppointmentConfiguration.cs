using ClinicMS.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ClinicMS.Infrastructure.Data.Configurations
{
  public class AppointmentConfiguration : IEntityTypeConfiguration<Appointment>
  {
    public void Configure(EntityTypeBuilder<Appointment> builder)
    {
      builder.HasKey(x => x.Id);

      builder.Property(x => x.AppointmentNumber).IsRequired().HasMaxLength(12);
      builder.HasIndex(x => x.AppointmentNumber).IsUnique();

      builder.HasOne(x => x.Patient)
              .WithMany(x => x.Appointments)
              .HasForeignKey(x => x.PatientId)
              .OnDelete(DeleteBehavior.Restrict);

      builder.HasOne(x => x.Doctor)
              .WithMany(x => x.Appointments)
              .HasForeignKey(x => x.DoctorId)
              .OnDelete(DeleteBehavior.Restrict);

      builder.HasOne(x => x.Department)
              .WithMany(x => x.Appointments)
              .HasForeignKey(x => x.DepartmentId)
              .OnDelete(DeleteBehavior.Restrict);

      builder.Property(x => x.AppointmentDate).IsRequired();

      builder.Property(x => x.StartTime).IsRequired();
      builder.Property(x => x.EndTime).IsRequired();


      builder.Property(x => x.ChiefComplaint).IsRequired()
              .HasMaxLength(500);

      builder.Property(x => x.CancelReason)
                   .HasMaxLength(500);

      builder.Property(x => x.CreatedOn)
             .IsRequired();

      builder.Property(x => x.CreatedById)
             .IsRequired();
    }
  }
}
