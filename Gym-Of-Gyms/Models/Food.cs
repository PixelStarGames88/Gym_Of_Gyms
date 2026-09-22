namespace Gym_Of_Gyms.Models;

public class Food
{
    public int Food_Id { get; set; }
    public string Name { get; set; } = null!;
    public decimal Calories { get; set; }
    public decimal Protein { get; set; }
    public decimal Fat { get; set; }
    public decimal Carbohydrates { get; set; }
}