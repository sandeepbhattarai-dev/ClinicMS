using ClinicMS.Domain.Enums;
using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices;

namespace ClinicMS.Domain.Entities
{
    public class Patient
    {
        [Required]
        public string? Id { get; init; }

        public int _Sequence { get; set; }

        [Required]
        public string PatientNumber { get; set; } = string.Empty;

        [Required]
        public string FirstName { get; set; } = string.Empty;

        [Required]
        public string LastName { get; set; } = string.Empty;

        [Required]
        public DateTime DateOfBirth { get; set; }

        [Required]
        public Gender Gender { get; set; }

        [Required]
        public BloodGroup BloodGroup { get; set; }

        [Required]
        public string Phone { get; set; } = string.Empty;

 
        [EmailAddress]
        public string Email { get; set; } = string.Empty;

        [Required]
        public string Address { get; set; } = string.Empty;

        public bool IsActive { get; set; } = true;

        public DateTime CreatedOn { get; set; }

        public DateTime UpdatedOn { get; set; }

        public string CreatedById { get; set; } = string.Empty;


    }
}
