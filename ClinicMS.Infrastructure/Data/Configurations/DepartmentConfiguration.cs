using ClinicMS.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ClinicMS.Infrastructure.Data.Configurations
{
  public class DepartmentConfiguration : IEntityTypeConfiguration<Department>
  {
    public void Configure(EntityTypeBuilder<Department> builder)
    {
      builder.HasKey(a => a.Id);
      builder.Property(a => a.Name).IsRequired(true).HasMaxLength(100);
      builder.Property(a => a.Description).HasMaxLength(500);

      builder.HasIndex(x => x.Name).IsUnique();

      builder.Property(x => x.IsActive)
          .HasDefaultValue(true);
    }
  }
}
