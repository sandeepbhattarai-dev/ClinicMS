using ClinicMS.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ClinicMS.Infrastructure.Data.Configurations
{
  public class AuditLogConfiguration : IEntityTypeConfiguration<AuditLog>
  {
    public void Configure(EntityTypeBuilder<AuditLog> builder)
    {
      builder.HasKey(x => x.Id);

      builder.Property(x => x.Id)
             .IsRequired()
             .HasMaxLength(50);

      builder.Property(x => x.UserId)
             .IsRequired()
             .HasMaxLength(50);

      builder.Property(x => x.Action)
             .IsRequired()
             .HasMaxLength(100);

      builder.Property(x => x.EntityName)
             .IsRequired()
             .HasMaxLength(100);

      builder.Property(x => x.EntityId)
             .IsRequired()
             .HasMaxLength(50);

      builder.Property(x => x.OldValues)
             .HasColumnType("nvarchar(max)");

      builder.Property(x => x.NewValues)
             .HasColumnType("nvarchar(max)");

      builder.Property(x => x.CreatedOn)
             .IsRequired()
             .HasColumnType("datetime2");


      // -----------------------------
      // Indexes
      // -----------------------------

      builder.HasIndex(x => x.UserId);

      builder.HasIndex(x => new
      {
        x.EntityName,
        x.EntityId
      });

      builder.HasIndex(x => x.CreatedOn);
    }
  }
}
