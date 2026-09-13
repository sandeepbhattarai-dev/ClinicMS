using System;
using System.Collections.Generic;
using System.Text;

namespace ClinicMS.Domain.Entities
{
    public class PrescriptionItem
    {
        public Guid Id { get; set; }
        public Guid PrescriptionId { get; set; }

        public string MedicationName { get; set; } = string.Empty;
        public string Dosage { get; set; } = string.Empty;

        public string Frequency { get; set; } = string.Empty;

        public int DurationDays { get; set; }
        public string Instructions { get; set; } = string.Empty;
    }
}
