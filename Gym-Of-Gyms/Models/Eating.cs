using Microsoft.EntityFrameworkCore;

namespace Gym_Of_Gyms.Models;

public class Eating
{
    public int Eating_Id { get; set; }
    public string? Name { get; set; }
    public TimeOnly Eating_Time { get; set; }
    public int Day_Id { get; set; }
    public Eating_Day Eating_Day { get; set; } = null!;
}