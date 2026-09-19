using ClinicMS.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ClinicMS.Infrastructure.Data.Configurations
{
  public class DoctorScheduleConfiguration : IEntityTypeConfiguration<DoctorSchedule>
  {
    public void Configure(EntityTypeBuilder<DoctorSchedule> builder)
    {
      // Primary Key
      builder.HasKey(x => x.Id);

      // Id
      builder.Property(x => x.Id)
             .IsRequired();

      // DoctorId
      builder.Property(x => x.DoctorId)
             .IsRequired();

      // Relationship:
      // Doctor 1 ---- * DoctorSchedule
      builder.HasOne(x => x.Doctor)
             .WithMany(x => x.DoctorSchedules)
             .HasForeignKey(x => x.DoctorId)
             .OnDelete(DeleteBehavior.Cascade);

      // Schedule properties
      builder.Property(x => x.DayOfWeek)
             .IsRequired();

      builder.Property(x => x.StartTime)
             .IsRequired();

      builder.Property(x => x.EndTime)
             .IsRequired();

      builder.Property(x => x.SlotDurationMinutes)
             .IsRequired()
             .HasDefaultValue(10);

      builder.Property(x => x.IsActive)
             .IsRequired()
             .HasDefaultValue(true);
    }
  }
}
