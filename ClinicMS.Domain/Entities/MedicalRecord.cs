using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace ClinicMS.Domain.Entities
{
    public class MedicalRecord
    {
        public Guid Id { get; set; }
        public Guid AppointmentId { get; set; }

        public decimal BloodPressure { get; set; }
        public decimal Temperature { get; set; }
        public decimal Pulse { get; set; }
        public decimal Weight { get; set; }
        public decimal Height { get; set; }
        [Required]
        public string Diagnosis { get; set; } = string.Empty;

        [Required]
        public string Notes { get; set; }

        [Required, NotNull]
        public DateTime CreatedOn { get; set; }

        public Guid CreatedById { get; set; }
    }
}
