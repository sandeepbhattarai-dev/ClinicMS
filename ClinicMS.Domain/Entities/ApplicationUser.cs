using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace ClinicMS.Domain.Entities
{
  public class ApplicationUser : IdentityUser<string>
  {
    //FullName, IsActive, CreatedOn, and nullable LastLogin
    [Required]
    public string FullName { get; set; } = string.Empty;
    public bool IsActive { get; set; } = true;
    [Required]
    public DateTime CreatedOn { get; set; }
    public DateTime? LastLogIn { get; set; }
  }
}
