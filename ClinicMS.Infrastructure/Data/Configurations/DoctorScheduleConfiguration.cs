using ClinicMS.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace ClinicMS.Infrastructure.Data.Configurations
{
  public class DoctorScheduleConfiguration : IEntityTypeConfiguration<DoctorSchedule>
  {
    public void Configure(EntityTypeBuilder<DoctorSchedule> builder)
    {
      builder.HasKey(x => x.Id);

      builder.HasMany<DoctorSchedule>(x => x.Doctor)
              .WithOne()
              .HasForeignKey(x => x.DoctorId);
    }
  }
}
