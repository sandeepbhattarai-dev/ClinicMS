using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ClinicMS.Domain.Entities
{
    public class Department
    {
        [Key]
        public string Id { get; set; } = string.Empty;

        [Required]
        public string Name { get; set; } = string.Empty;

        public string? Description { get; set; }

        [Required]
        public bool IsActive { get; set; } = true;

        public List<Doctor> Doctors { get; set; } = [];
  }
}
// completed - v1.0.0