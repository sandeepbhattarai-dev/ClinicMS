using ClinicMS.Application.DTOs.Auth;
using ClinicMS.Application.Interfaces;
using ClinicMS.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ClinicMS.Infrastructure.Services
{
  public class AuthService(
      UserManager<ApplicationUser> userManager,
      IConfiguration configuration) : IAuthService
  {
    private readonly UserManager<ApplicationUser> _userManager = userManager;
    private readonly IConfiguration _configuration = configuration;

    public async Task<LoginResponseDto?> LoginAsync(
        LoginRequestDto request)
    {
      // 1. Find user
      var user = await _userManager.FindByEmailAsync(request.Email);

      if (user == null)
      {
        return null;
      }

      // 2. Check password
      var passwordValid = await _userManager.CheckPasswordAsync(
          user,
          request.Password);

      if (!passwordValid)
      {
        return null;
      }

      // 3. Get user's roles
      var roles = await _userManager.GetRolesAsync(user);

      // 4. Create claims
      var claims = new List<Claim>
            {
                new(
                    ClaimTypes.NameIdentifier,
                    user.Id),

                new(
                    ClaimTypes.Name,
                    user.UserName ?? string.Empty),

                new(
                    ClaimTypes.Email,
                    user.Email ?? string.Empty)
            };

      foreach (var role in roles)
      {
        claims.Add(
            new Claim(ClaimTypes.Role, role));
      }

      // 5. Read JWT configuration
      var jwtKey = _configuration["Jwt:Key"]
          ?? throw new InvalidOperationException(
              "JWT Key is not configured.");

      var jwtIssuer = _configuration["Jwt:Issuer"]
          ?? throw new InvalidOperationException(
              "JWT Issuer is not configured.");

      var jwtAudience = _configuration["Jwt:Audience"]
          ?? throw new InvalidOperationException(
              "JWT Audience is not configured.");

      var expiryMinutes = int.Parse(
          _configuration["Jwt:ExpiryMinutes"]
          ?? throw new InvalidOperationException(
              "JWT ExpiryMinutes is not configured."));

      // 6. Create signing key
      var key = new SymmetricSecurityKey(
          Encoding.UTF8.GetBytes(jwtKey));

      var credentials = new SigningCredentials(
          key,
          SecurityAlgorithms.HmacSha256);

      // 7. Calculate expiration
      var expiresAt = DateTime.UtcNow.AddMinutes(
          expiryMinutes);

      // 8. Create JWT
      var token = new JwtSecurityToken(
          issuer: jwtIssuer,
          audience: jwtAudience,
          claims: claims,
          expires: expiresAt,
          signingCredentials: credentials);

      // 9. Convert JWT object to string
      var tokenString = new JwtSecurityTokenHandler()
          .WriteToken(token);

      // 10. Return response
      return new LoginResponseDto
      {
        Token = tokenString,
        ExpiresAt = expiresAt
      };
    }
  }
}