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
    [HttpGet("home/{username}/workouts")]
    public IActionResult Workouts(string username)
    {
        return View();
    }
    [Authorize]
    [HttpGet("home/{username}/eating")]
    public IActionResult Eating(string username)
    {
        return View();
    }
    [Authorize]
    [HttpGet("home/{username}/eating/food-list")]
    public IActionResult Food_List(string username)
    {
        return View();
    }
    [Authorize]
    [HttpGet("home/{username}/eating/food-add")]
    public IActionResult Food_Add(string username)
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