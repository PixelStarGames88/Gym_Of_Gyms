using Gym_Of_Gyms.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Gym_Of_Gyms.Controllers;

public class FoodController : Controller
{
    readonly ApplicationDbContext _context;

    public FoodController(ApplicationDbContext context)
    {
        _context = context;
    }
    [Authorize]
    [HttpPost("home/{username}/eating/food-add")]
    public async Task<IActionResult> CreateFood(string username, string foodName, double calories, double mass, double protein, double fat, double carbohydrates)
    {
        var newFood = new Food
        {
            Name = foodName,
            Calories = calories * 100 / mass,
            Protein = protein * 100 / mass,
            Fat = fat * 100 / mass,
            Carbohydrates = carbohydrates * 100 / mass
        };

        _context.UserFood.Add(newFood);
        await _context.SaveChangesAsync();

        return RedirectToAction("Food_List", "Home", new { username });
    }
}
