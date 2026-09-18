using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using ClinicMS.Domain.Entities;
using ClinicMS.Infrastructure.Data;
using System.Text;
using ClinicMS.Application.Interfaces;
using ClinicMS.Infrastructure.Services;

namespace ClinicMS.Infrastructure
{
  public static class DependencyInjection
  {
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services,
        IConfiguration config)
    {
      // ============================================
      // Database
      // ============================================

      services.AddDbContext<ApplicationDbContext>(options =>
      {
        options.UseSqlServer(
            config.GetConnectionString("DefaultConnection"));
      });


      // ============================================
      // ASP.NET Core Identity
      // ============================================

      services.AddIdentity<ApplicationUser, ApplicationRole>()
          .AddEntityFrameworkStores<ApplicationDbContext>()
          .AddDefaultTokenProviders();


      // ============================================
      // JWT Authentication
      // ============================================

      services.AddAuthentication(options =>
      {
        options.DefaultAuthenticateScheme =
            JwtBearerDefaults.AuthenticationScheme;

        options.DefaultChallengeScheme =
            JwtBearerDefaults.AuthenticationScheme;
      })
      .AddJwtBearer(options =>
      {
        options.TokenValidationParameters = new TokenValidationParameters
        {
          ValidateIssuer = true,
          ValidateAudience = true,
          ValidateLifetime = true,
          ValidateIssuerSigningKey = true,

          ValidIssuer = config["Jwt:Issuer"],
          ValidAudience = config["Jwt:Audience"],

          IssuerSigningKey = new SymmetricSecurityKey(
                      Encoding.UTF8.GetBytes(config["Jwt:Key"]!))
        };
      });


      // ============================================
      // Application / Infrastructure Services
      // ============================================

      // Service          Interfaces            services
      services.AddScoped<IAuthService, AuthService>();


      return services;
    }
  }
}