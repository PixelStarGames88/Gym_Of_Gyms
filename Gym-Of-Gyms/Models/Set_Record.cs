namespace Gym_Of_Gyms.Models;

public class Set_Record
{
    public int Set_Record_Id { get; set; }
    public TimeOnly Start_Time { get; set; }
    public TimeOnly End_Time { get; set; }
    public int Repetitions { get; set; }
    public decimal? Weight { get; set; }
    public int Exercise_Record_Id { get; set; }
    public int Exercise_Id { get; set; }
    public Exercise_Record Exercise_Record { get; set; } = null!;
    public Exercise Exercise { get; set; } = null!;
}