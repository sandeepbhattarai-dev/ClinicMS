using ClinicMS.Domain.Entities;
using ClinicMS.Infrastructure;
using ClinicMS.Infrastructure.Data.SeedData;
using Microsoft.AspNetCore.Identity;
using Microsoft.OpenApi;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
  options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
  {
    Type = SecuritySchemeType.Http,
    Scheme = "bearer",
    BearerFormat = "JWT",
    Description = "Enter your JWT token."
  });

  options.AddSecurityRequirement(document =>
      new OpenApiSecurityRequirement
      {
        [new OpenApiSecuritySchemeReference(
              "Bearer",
              document)] = []
      });
});

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
  app.UseSwagger();
  app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();