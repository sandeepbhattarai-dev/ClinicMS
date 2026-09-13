
using System.Collections;

namespace ClinicMS.Domain.Entities
{
    public class Prescription
    {
        public Guid Id { get; set; }
        public Guid AppointmentId { get; set; }
        public Guid DoctorId { get; set; }
        public Guid PatientId { get; set; }
        public DateTime IssuedOn { get; set; }
        public string Notes { get; set; } = string.Empty;
        public ICollection<PrescriptionItem> Items { get; set; }





    }
}
