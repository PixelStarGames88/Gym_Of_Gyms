namespace Gym_Of_Gyms.Models;

public class Record_Food
{
    public int Record_Food_Id { get; set; }
    public decimal Mass { get; set; }
    public int Eating_Id { get; set; }
    public int Food_Id { get; set; }
    public Eating Eating { get; set; } = null!;
    public Food Food { get; set; } = null!;
}