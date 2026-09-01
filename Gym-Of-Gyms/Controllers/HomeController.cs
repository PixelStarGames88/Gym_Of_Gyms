using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Gym_Of_Gyms.Controllers;

public class HomeController : Controller
{
    public IActionResult Autorisation()
    {
        return View();
    }
    public IActionResult Registration()
    {
        return View();
    }
    //[Authorize]
    public IActionResult ProductLine()
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