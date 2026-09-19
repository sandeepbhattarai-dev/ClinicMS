using System.ComponentModel.DataAnnotations;

namespace ClinicMS.Application.DTOs.Auth
{
  public class LoginRequestDto
  {
    [Required]
    [EmailAddress]
    public string Email { get; set; } = string.Empty;

    [Required]
    public string Password { get; set; } = string.Empty;
  }
}