using System.ComponentModel;

namespace AccountManagement.WEB.Models;

public class ApplicationUserViewModel
{
    [DisplayName("Id")]
    public string Id { get; init; }
    
    [DisplayName("Registration Date")]
    public DateTimeOffset RegistrationDate { get; set; }

    [DisplayName("Login Date")]
    public DateTimeOffset LastLoginDate { get; set; }

    [DisplayName("Name")]
    public string FullName { get; init; }
    
    [DisplayName("E-mail")]
    public string Email { get; init; }
    
    [DisplayName("Status")]
    public string Status { get; set; }
    
    public bool IsSelected { get; set; }
}