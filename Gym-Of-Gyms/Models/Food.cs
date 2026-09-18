namespace Gym_Of_Gyms.Models;

public class Food
{
    public int Food_Id { get; set; }
    public string Name { get; set; } = null!;
    public double Calories { get; set; }
    public double Protein { get; set; }
    public double Fat { get; set; }
    public double Carbohydrates { get; set; }
}