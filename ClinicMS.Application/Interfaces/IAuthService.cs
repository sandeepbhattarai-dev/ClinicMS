using ClinicMS.Application.DTOs.Auth;

namespace ClinicMS.Application.Interfaces
{
  public interface IAuthService
  {
    Task<LoginResponseDto?> LoginAsync(LoginRequestDto request);
  }
}