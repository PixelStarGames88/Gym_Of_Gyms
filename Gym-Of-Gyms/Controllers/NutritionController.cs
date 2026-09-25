using Gym_Of_Gyms.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Gym_Of_Gyms.Controllers;

public class NutritionController : Controller
{
    readonly ApplicationDbContext _context;

    public NutritionController(ApplicationDbContext context)
    {
        _context = context;
    }
    [Authorize]
    [HttpGet("nutrition/{username}/eating-day")]
    public IActionResult Eating_Day(string username)
    {
        return View();
    }
    [Authorize]
    [HttpGet("nutrition/{username}/eating-day/food-list")]
    public async Task<IActionResult> Food_List(string username)
    {
        var foodList = await _context.UserFood.ToListAsync();
        return View(foodList);
    }
    [Authorize]
    [HttpGet("nutrition/{username}/eating-day/eating")]
    public IActionResult Eating(string username)
    {
        return View();
    }
    [Authorize]
    [HttpGet("nutrition/{username}/eating-day/food-record")]
    public async Task<IActionResult> Food_Record(string username, int food_Id)
    {
        if (food_Id <= 0)
            return RedirectToAction("Food_List", "Nutrition", new { username });


        var product = await _context.UserFood.FirstOrDefaultAsync(f => f.Food_Id == food_Id);

        if (product == null)
            return RedirectToAction("Food_List", "Nutrition", new { username });

        return View(product);
    }
    [Authorize]
    [HttpGet("nutrition/{username}/eating-day/food-add")]
    public IActionResult Food_Add(string username)
    {
        return View();
    }
}