using Gym_Of_Gyms.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Gym_Of_Gyms.Controllers;

[Authorize]
[Route("food-record/{username}")]
public class FoodRecordController : Controller
{
    readonly ApplicationDbContext _context;

    public FoodRecordController(ApplicationDbContext context)
    {
        _context = context;
    }
    [HttpGet]
    public async Task<IActionResult> Food_Record(string username, int food_Id)
    {
        if (food_Id <= 0)
            return RedirectToAction("Food_List", "Nutrition", new { username });


        var product = await _context.UserFood.FirstOrDefaultAsync(f => f.Food_Id == food_Id);

        if (product == null)
            return RedirectToAction("Food_List", "Nutrition", new { username });

        return View(product);
    }
    [HttpGet]
    public IActionResult Food_Add(string username)
    {
        return View();
    }
}