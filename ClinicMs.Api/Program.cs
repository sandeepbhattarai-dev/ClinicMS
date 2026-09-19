using ClinicMS.Domain.Entities;
using ClinicMS.Infrastructure;
using ClinicMS.Infrastructure.Data.SeedData;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddInfrastructure(builder.Configuration);

var app = builder.Build();

// ============================================
// Seed Identity Data
// ============================================

using (var scope = app.Services.CreateScope())
{
  var userManager = scope.ServiceProvider
      .GetRequiredService<UserManager<ApplicationUser>>();

  var roleManager = scope.ServiceProvider
      .GetRequiredService<RoleManager<ApplicationRole>>();

  await IdentityDataInitializer.SeedData(
      userManager,
      roleManager);
}


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
  app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
