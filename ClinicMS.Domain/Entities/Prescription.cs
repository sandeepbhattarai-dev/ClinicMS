
using System.Collections;

namespace ClinicMS.Domain.Entities
{
    public class Prescription
    {
        public string? Id { get; set; }
        public string? AppointmentId { get; set; }
        public string? DoctorId { get; set; }
        public string? PatientId { get; set; }
        public DateTime IssuedOn { get; set; }
        public string Notes { get; set; } = string.Empty;
        public ICollection<PrescriptionItem>? Items { get; set; }





    }
}
