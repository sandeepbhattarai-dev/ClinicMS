using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ClinicMS.Domain.Entities
{
    public class DoctorUser
    {
        [Required]
        public string? Id { get; init; }

        [Required]
        // Foreign key to the ApplicationUser entity
        public string? ApplicatioUserId { get; set; }

        [Required]
        [Display(Name = "Full Name")]
        [Length(3, 100, ErrorMessage = "{0} must be between {2} and {1} characters.")]
        public string FullName { get; set; } = string.Empty;

        [Required]
        // foreign key to the Department entity
        public string? DepartmentId { get; set; }
        
        [Required]
        [Display(Name = "Specialization")]
        [Length(3, 100, ErrorMessage = "{0} must be between {2} and {1} characters.")]
        public string Specialization { get; set; } = string.Empty;

        [Required]
        [Display(Name = "License Number")]
        [Length(3, 100, ErrorMessage = "{0} must be between {2} and {1} characters.")]
        public string LicenseNumber { get; set; } = string.Empty;

        [Required]
        [Display(Name = "Consultation Fee")]
        [Range(0, double.MaxValue, ErrorMessage = "{0} must be a non-negative value.")]
        public decimal ConsultationFee { get; set; } = 0.00m;

        public bool IsActive { get; set; } = false;

    }
}
// incomplete - v1.0.0