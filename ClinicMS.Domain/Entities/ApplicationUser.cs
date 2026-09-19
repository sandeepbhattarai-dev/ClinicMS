
using Microsoft.AspNetCore.Identity;

namespace ClinicMS.Domain.Entities
{
  public class ApplicationUser : IdentityUser
  {
    //FullName, IsActive, CreatedOn, and nullable LastLogin
    public string FullName { get; set; } = string.Empty;
    public bool IsActive { get; set; } = true;
    public DateTime CreatedOn { get; set; }
    public DateTime? LastLogIn { get; set; }
  }
}
