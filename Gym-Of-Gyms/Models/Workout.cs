namespace Gym_Of_Gyms.Models;

public class Workout
{
    public int Workout_Id { get; set; }
    public DateOnly Date { get; set; }
    public string User_Id { get; set; } = null!;
    public ApplicationUser ApplicationUser { get; set; } = null!;
}