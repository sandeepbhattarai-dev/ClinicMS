using ClinicMS.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace ClinicMS.Domain.Entities
{
    public class Appointment
    {
        [Required]
        public string? Id { get; set; }

        [Required]
        [Display(Name = "Appointment Number")]
        [StringLength(20, MinimumLength = 3, ErrorMessage = "{0} must be between {1} and {2} characters.")]
        public string AppointmentNumber { get; set; } = string.Empty;

        [Required]
        [Display(Name = "Doctor")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "{0} must be between {1} and {2} characters.")]
        public string DoctorId { get; set; } = string.Empty;

        [Required]
        [Display(Name = "Patient")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "{0} must be between {1} and {2} characters.")]
        public string PatientId { get; set; } = string.Empty;

        [Required]
        [Display(Name = "Department")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "{0} must be between {1} and {2} characters.")]
        public string DepartmentId { get; set; } = string.Empty;

        [Required]
        [Display(Name = "Appointment Date")]
        public DateTime AppointmentDate { get; set; }


        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }


        public AppointmentStatus Status { get; set; }

        [Display(Name = "Chief Complaint")]
        [StringLength(500, MinimumLength = 3, ErrorMessage = "{0} must be between {1} and {2} characters.")]
        public string ChiefComplaint { get; set; } = string.Empty;

        [Display(Name = "Cancel Reason")]
        [StringLength(500, MinimumLength = 3, ErrorMessage = "{0} must be between {1} and {2} characters.")]
        public string CancelReason { get; set; } = string.Empty;

        [Required]
        [Display(Name = "Created On")]
        public DateTime CreatedOn { get; set; }
        [Required]
        [Display(Name = "Created By")]
        public string? CreatedById { get; set; }

    }
}
