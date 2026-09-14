using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ClinicMS.Domain.Entities
{
    public class PrescriptionItem
    {
        [Required]
        public string? Id { get; set; }
        public string? PrescriptionId { get; set; }
    public Prescription Prescription { get; set; } = null!;

        public string MedicationName { get; set; } = string.Empty;
        public string Dosage { get; set; } = string.Empty;

        public string Frequency { get; set; } = string.Empty;

        public int DurationDays { get; set; }
        public string Instructions { get; set; } = string.Empty;
    }
}
