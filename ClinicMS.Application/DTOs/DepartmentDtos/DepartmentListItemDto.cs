namespace ClinicMS.Application.DTOs.DepartmentDtos
{
  public class DepartmentListItemDto
  {
    public string Id { get; set; } = string.Empty;

    public string Name { get; set; } = string.Empty;

    public string? Description { get; set; }

    public bool IsActive { get; set; } = true;
  }
}
