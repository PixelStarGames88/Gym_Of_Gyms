namespace Gym_Of_Gyms.Models;

public class Exercise
{
    public int Exercise_Id { get; set; }
    public string Name { get; set; } = null!;
    public double? Energy_Cost { get; set; }
    public double? Height_Mass { get; set; }

}