using Supabase.Postgrest.Attributes;
using Supabase.Postgrest.Models;

namespace Gym_Of_Gyms.Models.DataBaseModels;

[Table("user_gym")]
public class UserGymModel : BaseModel
{
    [Column("user_gym_login")]
    public string Login { get; set; } = null!;
    [Column("user_gym_password")]
    public string Password { get; set; } = null!;
    [Column("user_gym_first_name")]
    public string FirstName { get; set; } = null!;
    [Column("user_gym_last_name")]
    public string LastName { get; set; } = null!;
    [Column("user_gym_father_name")]
    public string FatherName { get; set; } = null!;
    [Column("user_gym_weight")]
    public double Weight { get; set; }
    [Column("user_gym_height")]
    public double Height { get; set; }
}