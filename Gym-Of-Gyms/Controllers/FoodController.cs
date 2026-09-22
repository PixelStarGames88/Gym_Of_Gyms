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
    public async Task<IActionResult> CreateFood(string username, string foodName, string calories, string mass, string protein, string fat, string carbohydrates)
    {
        decimal caloriesNumber, massNumber, proteinNumber, fatNumber, carbohydratesNumber;

        if(string.IsNullOrEmpty(foodName) || string.IsNullOrEmpty(calories) || string.IsNullOrEmpty(mass) || 
           string.IsNullOrEmpty(protein) || string.IsNullOrEmpty(fat) || string.IsNullOrEmpty(carbohydrates))
            return RedirectToAction("Food_Add", "Home", new { username });

        if (!decimal.TryParse(calories.Replace(',', '.'), System.Globalization.CultureInfo.InvariantCulture, out caloriesNumber) ||
            !decimal.TryParse(mass.Replace(',', '.'), System.Globalization.CultureInfo.InvariantCulture, out massNumber) ||
            !decimal.TryParse(protein.Replace(',', '.'), System.Globalization.CultureInfo.InvariantCulture, out proteinNumber) ||
            !decimal.TryParse(fat.Replace(',', '.'), System.Globalization.CultureInfo.InvariantCulture, out fatNumber) ||
            !decimal.TryParse(carbohydrates.Replace(',', '.'), System.Globalization.CultureInfo.InvariantCulture, out carbohydratesNumber)) 
            return RedirectToAction("Food_Add", "Home", new { username });

        var newFood = new Food
        {
            Name = foodName,
            Calories = caloriesNumber * 100m / massNumber,
            Protein = proteinNumber * 100m / massNumber,
            Fat = fatNumber * 100m / massNumber,
            Carbohydrates = carbohydratesNumber * 100m / massNumber
        };

        _context.UserFood.Add(newFood);
        await _context.SaveChangesAsync();

        return RedirectToAction("Food_List", "Home", new { username });
    }
}
