namespace Gym_Of_Gyms.Models;

public class Exercise_Record
{
    public int Exercise_Record_Id { get; set; }
    public int Set_Count { get; set; }
    public int Workout_Id { get; set; }
    public Workout Workout { get; set; } = null!;
}
