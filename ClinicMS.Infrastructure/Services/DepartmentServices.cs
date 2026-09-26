using ClinicMs.Shared.Models;
using ClinicMS.Application.DTOs.DepartmentDtos;
using ClinicMS.Application.Interfaces;
using ClinicMS.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace ClinicMS.Infrastructure.Services
{
  public class DepartmentServices(ApplicationDbContext dbContext) : IDepartmentService
  {
    private readonly ApplicationDbContext _dbContext = dbContext;

    // 
    public Task<Result<DepartmentResponseDto>> CreateDepartment(DepartmentCreateRequestDto newUserDepData)
    {
      throw new NotImplementedException();
    }

    public Task<Result> Deactivate(string id)
    {
      throw new NotImplementedException();
    }

    public async Task<Result<DepartmentResponseDto>> GetById(string id)
    {
      var foundDepartment = await _dbContext.Departments
          .Where(d => d.Id == id)
          .Select(u => new DepartmentResponseDto
          {
            Id = u.Id,
            Name = u.Name,
            Description = u.Description,
            IsActive = u.IsActive
          })
          .FirstOrDefaultAsync();

      if (foundDepartment != null)
      {
        // Explicitly create the generic result
        return new Result<DepartmentResponseDto>
        {
          IsSuccess = true,
          Message = "Found",
          Data = foundDepartment
        };
      }
      else
      {
        // Explicitly return the failure generic result
        return new Result<DepartmentResponseDto>
        {
          IsSuccess = false,
          Message = "Department could not be found"
        };
      }
    }

    public Task<Result<List<DepartmentListItemDto>>> GetDepartment(DepartmentFilterDto filter)
    {
      throw new NotImplementedException();
    }


    //public async Task<Result<List<DepartmentListItemDto>>> GetDepartment(DepartmentFilterDto filter)
    //{
    //  var foundDepartment = await _dbContext.Departments
    //    .Select(u => new DepartmentResponseDto
    //    {
    //      Id = u.Id,
    //      Name = u.Name,
    //      Description = u.Description,
    //      IsActive = u.IsActive
    //    }).ToListAsync();



    //  return foundDepartment;
    //}

    public Task<Result<DepartmentResponseDto>> UpdateDepartment(DepartmentUpdateRequestDto updatedData)
    {
      throw new NotImplementedException();
    }
  }
}
