using ClinicMs.Shared.Models;
using ClinicMS.Application.DTOs.DepartmentDtos;

namespace ClinicMS.Application.Interfaces
{
  public interface IDepartmentService
  {
    //create
    public Task<Result<DepartmentResponseDto>> CreateDepartment(DepartmentCreateRequestDto newUserDepData);

    //read
    public Task<Result<List<DepartmentListItemDto>>> GetDepartment(DepartmentFilterDto filter);

    public Task<Result<DepartmentResponseDto>> GetById(string id);

    //update
    public Task<Result<DepartmentResponseDto>> UpdateDepartment(DepartmentUpdateRequestDto updatedData);

    //Delete
    public Task<Result> Deactivate(string id);
  }
}