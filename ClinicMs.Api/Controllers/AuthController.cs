using ClinicMs.Shared.Models;
using ClinicMS.Application.DTOs.Auth;
using ClinicMS.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

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
            result, "Login successful."));
    }

    [Authorize]
    [HttpGet("me")]
    public IActionResult Me()
    {
      var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
      var email = User.FindFirstValue(ClaimTypes.Email);
      var role = User.FindFirstValue(ClaimTypes.Role);

      var data = new
      {
        UserId = userId,
        Email = email,
        Role = role
      };

      return Ok(
          ApiResponseDto<object>.Ok(
              data,
              "Authenticated user retrieved successfully."));
    }

  }
}