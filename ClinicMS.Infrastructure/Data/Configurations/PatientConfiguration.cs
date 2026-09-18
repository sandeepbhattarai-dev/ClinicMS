using ClinicMS.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ClinicMS.Infrastructure.Data.Configurations
{
  public class PatientConfiguration : IEntityTypeConfiguration<Patient>
  {
    public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Patient> builder)
    {
      {
        // Primary Key
        builder.HasKey(x => x.Id);

        // Id
        builder.Property(x => x.Id)
               .IsRequired();

        // Patient Number
        builder.Property(x => x.PatientNumber)
               .IsRequired()
               .HasMaxLength(20);

        // PatientNumber must be unique
        builder.HasIndex(x => x.PatientNumber)
               .IsUnique();

        // First Name
        builder.Property(x => x.FirstName)
               .IsRequired()
               .HasMaxLength(100);

        // Last Name
        builder.Property(x => x.LastName)
               .IsRequired()
               .HasMaxLength(100);

        // Date of Birth
        builder.Property(x => x.DateOfBirth)
               .IsRequired();

        // Gender
        builder.Property(x => x.Gender)
               .IsRequired();

        // Blood Group
        builder.Property(x => x.BloodGroup)
               .IsRequired();

        // Phone
        builder.Property(x => x.Phone)
               .IsRequired()
               .HasMaxLength(20);

        // Email
        builder.Property(x => x.Email)
               .HasMaxLength(255);

        // Address
        builder.Property(x => x.Address)
               .IsRequired()
               .HasMaxLength(500);

        // Active flag
        builder.Property(x => x.IsActive)
               .IsRequired()
               .HasDefaultValue(true);

        // Audit fields
        builder.Property(x => x.CreatedOn)
               .IsRequired();

        builder.Property(x => x.CreatedById)
               .IsRequired()
               .HasMaxLength(100);

        // Relationships are configured in the
        // corresponding child entity configurations.
      }
    }
  }
}
