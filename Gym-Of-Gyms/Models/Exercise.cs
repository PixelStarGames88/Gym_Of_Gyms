namespace Gym_Of_Gyms.Models;

public class Exercise
{
    public int Exercise_Id { get; set; }
    public string Name { get; set; } = null!;
    public decimal? Energy_Cost { get; set; }
    public decimal? Height_Mass { get; set; }

}