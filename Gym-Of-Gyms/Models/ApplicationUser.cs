using Microsoft.AspNetCore.Identity;

namespace Gym_Of_Gyms.Models;

public class ApplicationUser : IdentityUser
{
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? FatherName { get; set; }
    public double Weight { get; set; }
    public double Height { get; set; }
}
