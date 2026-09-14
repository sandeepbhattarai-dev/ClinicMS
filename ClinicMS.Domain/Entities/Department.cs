using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ClinicMS.Domain.Entities
{
    public class Department
    {
        [Key]
        public string? Id { get; set; }

        [Required]
        [Length(3, 100, ErrorMessage ="{0} must be between {2} and {1} characters.")]
        public string Name { get; set; } = string.Empty;

        [MaxLength(500, ErrorMessage = "{0} cannot exceed {1} characters.")]
        public string? Description { get; set; }

        [Required]
        public bool IsActive { get; set; } = true;
    }
}
// completed - v1.0.0