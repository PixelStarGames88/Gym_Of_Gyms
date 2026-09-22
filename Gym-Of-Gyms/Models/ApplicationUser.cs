using Microsoft.AspNetCore.Identity;

namespace Gym_Of_Gyms.Models;

public class ApplicationUser : IdentityUser
{
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? FatherName { get; set; }
    public decimal Weight { get; set; }
    public decimal Height { get; set; }
    public DateOnly BirthDay { get; set; }
}
