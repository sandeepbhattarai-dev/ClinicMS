using ClinicMs.Shared.Models;
using ClinicMS.Application.DTOs.Auth;
using ClinicMS.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ClinicMS.Api.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class AuthController(IAuthService authService) : ControllerBase
  {
    private readonly IAuthService _authService = authService;

    [HttpPost("login")]
    public async Task<IActionResult> Login(
        [FromBody] LoginRequestDto request)
    {
      var result = await _authService.LoginAsync(request);

      if (result == null)
      {
        return Unauthorized(
            ApiResponseDto<LoginResponseDto>.Error(
                "Invalid email or password."));
      }

      return Ok(
          ApiResponseDto<LoginResponseDto>.Ok(
              result,
              "Login successful."));
    }
  }
}