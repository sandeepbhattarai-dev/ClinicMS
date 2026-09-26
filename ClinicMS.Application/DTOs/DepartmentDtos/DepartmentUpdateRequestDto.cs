using System.ComponentModel.DataAnnotations;

namespace ClinicMS.Application.DTOs.DepartmentDtos
{
  public class DepartmentUpdateRequestDto
  {
    [Required]
    public string Id { get; set; } = string.Empty;

    [Required]
    [StringLength(100)]
    public string Name { get; set; } = string.Empty;

    [StringLength(500)]
    public string? Description { get; set; }
  }
}
