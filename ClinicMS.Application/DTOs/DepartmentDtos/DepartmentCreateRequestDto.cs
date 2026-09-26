using System.ComponentModel.DataAnnotations;

namespace ClinicMS.Application.DTOs.DepartmentDtos
{
  public class DepartmentCreateRequestDto
  {
    [Required]
    [StringLength(100)]
    public string Name { get; set; } = string.Empty;

    [StringLength(500)]
    public string? Description { get; set; }
  }
}
