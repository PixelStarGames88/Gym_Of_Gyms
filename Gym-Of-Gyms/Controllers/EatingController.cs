using Gym_Of_Gyms.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Globalization;

namespace Gym_Of_Gyms.Controllers;

[Authorize]
[Route("eating/{username}")]
public class EatingController : Controller
{
    readonly ApplicationDbContext _context;
    public EatingController(ApplicationDbContext context)
    {
        _context = context;
    }
    [HttpPost("save-day")]
    public async Task<IActionResult> SaveDay(string username, string dayid, string daydata)
    {
        var user = await _context.Users.FirstOrDefaultAsync(u => u.UserName == username);
        if (user == null)
            return NotFound("Пользователь не найден");

        if (!DateOnly.TryParseExact(dayid, "ddMMyyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateOnly date))
        {
            return BadRequest("Неверный формат даты");
        }

        int maxEatingId = await _context.Eatings.AnyAsync()
        ? await _context.Eatings.MaxAsync(e => e.Eating_Id)
        : 0;

        int nextEatingId = maxEatingId + 1;

        HttpContext.Session.SetInt32("dayId", int.Parse(dayid));
        HttpContext.Session.SetString("userId", username);
        HttpContext.Session.SetString("dayData", date.ToString("dd.MM.yyyy"));

        return RedirectToAction(nameof(Eating), new { username, eatingId = nextEatingId.ToString() });
    }
    [HttpGet("{eatingId}")]
    public async Task<IActionResult> Eating(string username, string eatingId)
    {
        var user = await _context.Users.FirstOrDefaultAsync(u => u.UserName == username);
        if (user == null)
            return NotFound("Пользователь не найден");
        
        int numEatingId;

        if (!int.TryParse(eatingId, out numEatingId))
        {
            int maxEatingId = await _context.Eatings.AnyAsync() ? await _context.Eatings.MaxAsync(e => e.Eating_Id) : 0;
            int nextEatingId = maxEatingId + 1;
            return RedirectToAction(nameof(Eating), new { username, eatingId = nextEatingId.ToString() });
        }

        var eating = await _context.Eatings.FirstOrDefaultAsync(e => e.Eating_Id == numEatingId);

        ViewData["eatingId"] = eatingId;

        return View(eating);
    }



}