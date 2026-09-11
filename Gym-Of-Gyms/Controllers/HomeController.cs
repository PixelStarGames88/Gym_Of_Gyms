using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Gym_Of_Gyms.Controllers;

public class HomeController : Controller
{
    [AllowAnonymous]
    public IActionResult Autorisation()
    {
        return View();
    }
    [AllowAnonymous]
    public IActionResult Registration()
    {
        return View();
    }

    [Authorize]
    [HttpGet("Home/{username}/Workouts")]
    public IActionResult Workouts(string username)
    {
        return View();
    }
    [Authorize]
    [HttpGet("Home/{username}/Food")]
    public IActionResult Food(string username)
    {
        return View();
    }
    [AllowAnonymous]
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error(int? id = null)
    {
        int statusCode = id.HasValue && id.Value >= 400 && id.Value <= 599
            ? id.Value
            : 500;

        ViewData["StatusCode"] = statusCode;
        Response.StatusCode = statusCode;

        return View();
    }

}