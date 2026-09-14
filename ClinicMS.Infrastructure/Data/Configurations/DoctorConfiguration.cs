using ClinicMS.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ClinicMS.Infrastructure.Data.Configurations
{
  public class DoctorConfiguration : IEntityTypeConfiguration<Doctor>
  {
    public void Configure(EntityTypeBuilder<Doctor> builder)
    {
      builder.HasKey(x => x.Id);
      builder.HasOne(x => x.ApplicationUser) // Doctor 1 -- 
              .WithOne()                    // 1 ApplicationUser
              .HasForeignKey<Doctor>(x => x.ApplicationUserId);

      builder.HasOne(x => x.Department)
             .WithMany()
             .HasForeignKey(x => x.DepartmentId)
             .OnDelete(DeleteBehavior.Restrict);

      builder.Property(x => x.FullName)
              .IsRequired()
              .HasMaxLength(100);

      builder.Property(x => x.Specialization)
              .IsRequired()
              .HasMaxLength(100);

      builder.Property(x => x.LicenseNumber)
             .IsRequired()
             .HasMaxLength(100);

      builder.HasIndex(x => x.LicenseNumber)
            .IsUnique();

      builder.HasIndex(x => x.ApplicationUserId)
                .IsUnique();

      builder.Property(x => x.ConsultationFee)
              .HasPrecision(18, 2);

      builder.Property(x => x.IsActive)
             .HasDefaultValue(true);
    }
  }
}
