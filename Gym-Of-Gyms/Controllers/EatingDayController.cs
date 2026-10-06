using Gym_Of_Gyms.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Globalization;

namespace Gym_Of_Gyms.Controllers;

[Authorize]
[Route("eating-day/{username}")]
public class EatingDayController : Controller
{
    private readonly ApplicationDbContext _context;

    public EatingDayController(ApplicationDbContext context)
    {
        _context = context;
    }
    
    [HttpGet("{dateStr}")]
    public async Task<IActionResult> EatingDay(string username, string dateStr)
    {
        var user = await _context.Users.FirstOrDefaultAsync(u => u.UserName == username);

        if (user == null)
            return NotFound("Пользователь не найден");

        if (!DateOnly.TryParseExact(dateStr, "ddMMyyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateOnly selectedDate))
        {
            string todayFormatted = DateTime.Now.ToString("ddMMyyyy");
            return RedirectToAction(nameof(EatingDay), new { username, dateStr = todayFormatted });
        }
        var eatingDay = await _context.Eating_Days.FirstOrDefaultAsync(e => e.ApplicationUser.Id == user.Id && e.Date == selectedDate);

        ViewData["SelectedDate"] = selectedDate.ToString("dd.MM.yyyy");
        ViewData["DateStr"] = dateStr;

        return View(eatingDay);
    }
}