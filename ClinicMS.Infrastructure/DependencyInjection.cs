using Microsoft.AspNetCore.Identity;
using ClinicMS.Domain.Entities;
using ClinicMS.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ClinicMS.Infrastructure
{
  public static class DependencyInjection
  {
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration config)
    {
      services.AddDbContext<ApplicationDbContext>(options =>
      {
        options.UseSqlServer(config.GetConnectionString("DefaultConnection"));
      });

      services.AddIdentity<ApplicationUser, ApplicationRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddDefaultTokenProviders();

      // Service        Interfaces                 services

      return services;
    }
  }
}
