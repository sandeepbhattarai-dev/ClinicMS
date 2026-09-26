namespace ClinicMS.Application.DTOs.DepartmentDtos
{
  public class DepartmentFilterDto
  {
    public string? Search { get; set; }

    public int Page { get; set; } = 1;

    public int PageSize { get; set; } = 10;
  }
}
