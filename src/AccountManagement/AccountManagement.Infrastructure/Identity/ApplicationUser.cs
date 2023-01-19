using Microsoft.AspNetCore.Identity;

namespace AccountManagement.Infrastructure.Identity;

public class ApplicationUser : IdentityUser
{
    public string FirstName { get; set; }
    
    public string LastName { get; set; }
    
    public DateTimeOffset RegistrationDate { get; set; }
    
    public DateTimeOffset LastLoginDate { get; set; }
    
    public string FullName => $"{FirstName} {LastName}";
    
    public string Status => LockoutEnd == null ? "Active" : "Locked";
}